using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngineHook : MonoBehaviour {

	HudsonianPhysics engine = new HudsonianPhysics();

	//public Transform camera_3D;	// movement in 'image volume space' controlled by location and orientation of vive headset in 3D space.		 not important for 4D camera or physics.

	public Transform controlStick_1;	// 3D control 'sticks' used to control the 4D camera
	public Transform controlStick_2;

	public float fieldOfView = 60;
	public string renderType = "Othographic";

	Transform_4D camera_4D;		// 
	//						players character needs to be able to extend 4D 'apendeges' into the 4th dimension to interact with objects.  objects are kept a distance from the camera because of the 'players' 4D thickness
	//	use hopf cordinates(3 dof, 3 axis) for 4D camera orientation as an anolog for pitch-roll(2 dof, 2 axis) of 3D cameras

	bool debug = false;

	//public float gravity = 9.8f;
	//float timeStep = 1.0f / 60.0f;
	//public float timeScale = 1;

	// Use this for initialization
	void Start () {

		if(debug)
			Debug.Log ("PhysicsEngineHook Start().");
		engine.Start ();
	}

	// Update is called once per frame
	void Update () {

		if(debug)
			Debug.Log ("PhysicsEngineHook Update().");

		engine.Render (camera_4D); 	// orientation and location of 4D camera is controlled by the player with 2 3-axis control 'sticks'.  one for translation, one for rotation.

	}

	void FixedUpdate () {

		if(debug)
			Debug.Log ("PhysicsEngineHook FixedUpdate().");

		engine.Update ();
	}
}
