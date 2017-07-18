using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonianPhysics {

	List<ActiveObject> activeObjects = new List<ActiveObject> ();
	List<StaticObject> staticObjects = new List<StaticObject> ();

	List<Vector4> globalEnvironmentalForces = new List<Vector4>();

	Vector4 ga = new Vector4();	// gravitational constant of acceleration /s^2

	float dt = 1.0f / 60.0f;		// duration of each frame

	bool debug = false;

	public HudsonianPhysics () {

		if(debug)
			Debug.Log ("HudsonianPhysics Initialized.");

		ga.Set (0, -9.8f, 0, 0);

	}

	public void Start () {

		if(debug)
			Debug.Log ("HudsonianPhysics Start().");

		findActiveObjects ();	// move to later time
		findStaticObjects ();
	}

	// temparary find functions, should just attach the class to the objects instead.
	void findActiveObjects () {

		if(debug)
			Debug.Log ("HudsonianPhysics findActiveObjects().");

		ActiveObjectHook[] hooks = GameObject.FindObjectsOfType(typeof(ActiveObjectHook)) as ActiveObjectHook[];

		foreach (ActiveObjectHook hook in hooks) {

			ActiveObject newAObj = new ActiveObject (hook.transform);
			activeObjects.Add (newAObj);
		}
	}

	void findStaticObjects () {

		if(debug)
			Debug.Log ("HudsonianPhysics findStaticObjects().");

		StaticObjectHook[] hooks = GameObject.FindObjectsOfType (typeof(StaticObjectHook)) as StaticObjectHook[];

		foreach (StaticObjectHook hook in hooks) {

			StaticObject newSObj = new StaticObject (hook.transform);
			staticObjects.Add (newSObj);
		}
	}

	Vector4 randomForce() {

		Vector4 force = new Vector4 ();
		force.Set (Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);

		return force;
	}

	void handleActiveCollision (ActiveObject obj1, ActiveObject obj2){

		//	f = J / dt
		Vector4 J = new Vector4();	// Impulse

		Vector4 force = J / dt;

		obj1.applyForce (force);
		obj2.applyForce (-force);
	}

	void handleStaticCollision(ActiveObject obj1, StaticObject obj2) {


	}

	public void Update () {

		if(debug)
			Debug.Log ("HudsonianPhysics Update().");

		//	Update forces
		foreach (ActiveObject obj in activeObjects) {
			foreach (Vector4 force in globalEnvironmentalForces) {

				obj.applyForce(force);				// global environmental forces
			}

			//obj.applyGravitationalForce(ga);	// gravitational force
			obj.applyForce(randomForce());		// random test forces
		}

		// update physics
		foreach (ActiveObject obj in activeObjects) {

			obj.Update(dt);
		}

		//foreach (StaticObject obj in staticObjects) {			// static objects are not calculated
		//
		//	obj.Update();
		//}
	}


	public void Render(Transform_4D cameraTransform) {

		if(debug)
			Debug.Log ("HudsonianPhysics Render().");

		foreach (ActiveObject obj in activeObjects) {

			obj.Render (cameraTransform);
		}

		foreach (StaticObject obj in staticObjects) {

			obj.Render (cameraTransform);
		}
	}
}
