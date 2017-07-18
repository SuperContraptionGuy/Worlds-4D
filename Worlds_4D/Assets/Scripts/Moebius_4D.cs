using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moebius_4D : MonoBehaviour {

	public float rotationsPerSecond = 0.25f;

	public float p;
	public float q;
	public float t = 0;

	Mesh originalMesh;


	// Use this for initialization
	void Start () {

		originalMesh = GetComponent<MeshFilter> ().mesh;
		
	}
	
	// Update is called once per frame
	void Update () {

		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = originalMesh.vertices;
		Vector3[] normals = originalMesh.normals;

		t = (Time.time * rotationsPerSecond * Mathf.PI * 2) % (2 * Mathf.PI);

		rotate_4D (1, 1, t, vertices);
		mesh.vertices = vertices;
		
	}

	Vector3 rotate_4D(float p, float q, float t, Vector3 Point) {

		//getting the coordinates of the input point
		double xa = Point.x;
		double ya = Point.y;
		double za = Point.z;
		double wa = 0;

		//reverse stereographically project to Riemann hypersphere
		double xb = 2 * xa / (1 + xa * xa + ya * ya + za * za);
		double yb = 2 * ya / (1 + xa * xa + ya * ya + za * za);
		double zb = 2 * za / (1 + xa * xa + ya * ya + za * za);
		double wb = (-1 + xa * xa + ya * ya + za * za) / (1 + xa * xa + ya * ya + za * za);

		//now rotate the hypersphere (use p = q = 1 for isoclinic rotations)
		//and vary t between 0 and 2*PI
		double xc = +(xb) * (Mathf.Cos((p) * (t))) + (yb) * (Mathf.Sin((p) * (t)));
		double yc = -(xb) * (Mathf.Sin((p) * (t))) + (yb) * (Mathf.Cos((p) * (t)));
		double zc = +(zb) * (Mathf.Cos((q) * (t))) - (wb) * (Mathf.Sin((q) * (t)));
		double wc = +(zb) * (Mathf.Sin((q) * (t))) + (wb) * (Mathf.Cos((q) * (t)));

		//then project stereographically back to flat 3D
		double xd = xc / (1 - wc);
		double yd = yc / (1 - wc);
		double zd = zc / (1 - wc);

		Vector3 outPoint = new Vector3((float)xd, (float)yd, (float)zd);

		return outPoint;

	}

	void rotate_4D(float p, float q, float t, Vector3[] points) {

		for (int i = 0; i < points.Length; i++) {

			points[i] = rotate_4D (p, q, t, points [i]);

		}
	}
}
