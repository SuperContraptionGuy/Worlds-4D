using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectHook : MonoBehaviour {

	public float mass;

	Transform parent;

	// Use this for initialization
	void Start () {

		parent = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
