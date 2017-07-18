using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalObject {


	protected bool debug = false;
	protected Transform_4D transform = new Transform_4D();

	Transform parent;	// A transform and mesh to be acted upon by the projections
	Mesh renderedMesh;	// to be constructed on the fly as a projection of 4d space, with center of mass at `position`
	Mesh_4D mesh;



	public PhysicalObject (Transform parent) {
		
		if(debug)
			Debug.Log ("PhysicalObject initialized. Parent position: " + parent.position);
		
		this.parent = parent;
		transform = parent;			// mainly for testing, may changes, don't know

		renderedMesh = parent.GetComponent<MeshFilter> ().mesh;
		mesh = parent.GetComponent<Mesh_4D> ();
	}

	public void Render(Transform_4D camera) {

		if(debug)
			Debug.Log ("PhysicalObject Render(). New position: " + transform.position);

		// just for testing, ignores 4d component
		parent.position = transform.position;

		//mesh.Render (camera, transform, renderedMesh);		// does this work? TODO
	}
}
