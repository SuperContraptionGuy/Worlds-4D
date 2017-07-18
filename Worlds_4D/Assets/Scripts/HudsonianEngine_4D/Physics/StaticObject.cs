using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : PhysicalObject {

	public StaticObject(Transform parent) : base (parent) {

		if (debug)
			Debug.Log ("StaticObject initialized");
	}
}
