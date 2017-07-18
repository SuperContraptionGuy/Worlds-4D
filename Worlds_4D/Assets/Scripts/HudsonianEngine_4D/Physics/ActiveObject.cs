using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : PhysicalObject {

	// linear
	float mass;
	Vector4 velocity = new Vector4();
	List<Vector4> forces = new List<Vector4> ();	// list of forces
	Vector4 acceleration = new Vector4();	// sum of forces

	// rotational		// need to review types, has to relate to rotation values
	float moment;	// moment of inertia

	Vector3 angularVelocity = new Vector3();		//		angular velocity
	List<Vector3> torques = new List<Vector3>();		//		angular forces (list of torques)
	Vector3 angularAcceleration = new Vector3();	//		angular acceleration	(sum of torques)


	public ActiveObject (Transform parent) : base (parent) {

		if (debug)
			Debug.Log ("ActiveObject initialized");

		mass = parent.GetComponent<ActiveObjectHook> ().mass;

		// calculate moment based on mesh, maybe in update or something		TODO
		//moment = something...
	}

	public void applyForce(Vector4 force) {  // applies a force for one frame

		if(debug)
			Debug.Log ("ActiveObject applyForce().");

		forces.Add (force);
	}

	public void applyTorque(Vector3 torque) {		// needs a different unit, ve

		if(debug)
			Debug.Log ("ActiveObject applyTorque().");

		torques.Add (torque);
	}

	public void applyGravitationalForce(Vector4 ga) {

		//	Gf = m * Ga
		applyForce (mass * ga);
	}

	public void Update(float dt) {	// calculate

		if(debug)
			Debug.Log ("ActiveObject Update().");
		if (debug)
			Debug.Log ("BEFORE: Acceleration: " + acceleration + "Velocity: " + velocity + "position: " + transform.position);

		//		Linear
		//	1:	a = ( 1 / m ) * SUM( f )
		//	2:	dv = da * t
		//	3:	dp = dv * t
		//				

		//	1:
		acceleration = Vector4.zero;
		foreach (Vector4 force in forces) {

			if(debug)
				Debug.Log ("checked for force.");

			acceleration += force;			// SUM( f )		Sum of all forces
		}
		acceleration /= mass;		// * ( 1 / m )	times the reciprical of the mass

		//	2:
		velocity += acceleration * dt;

		//	3:
		transform.position += velocity * dt;

		if (debug)
			Debug.Log ("AFTER: Acceleration: " + acceleration + "Velocity: " + velocity + "position: " + transform.position);



		//			Rotational
		//	1:	a = ( 1 / I ) * SUM( t )
		//	2:	dv = da * t
		//	3:	dr = dv * t
		//				

		//	1:
		angularAcceleration = Vector3.zero;
		foreach (Vector3 torque in torques) {

			angularAcceleration += torque;
		}
		angularAcceleration /= moment;

		//	2:
		angularVelocity += angularAcceleration * dt;

		//	3:
		//rotation += angularVelocity * dt;						// not quite right, going to have to delv into the rotation physics and revemp types to accept quaternians in 4 dimensions TODO
		transform.Ql *= new Quaternion(0, 0, 0, 1);		// testing rotation, not working correcctly 
		transform.Qr *= new Quaternion(0, 0, 0, 1);



		forces.Clear ();	// clear the forces

	}
}
