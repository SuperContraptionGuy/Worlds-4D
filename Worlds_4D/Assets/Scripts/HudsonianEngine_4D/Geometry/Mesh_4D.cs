using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_4D : MonoBehaviour {			// TODO add a file reader for 4D geometry files.  Maybe include UVs?
												// 4D Files:
												//		Vertecies
												//		Tetrahedra
												//		3D UV map

	Geometry_4D mesh;
	public string shape = "Hypercube";

	bool debug = false;

//	public Mesh_4D(string shape) {
//
//		if (debug)
//			Debug.Log ("Mesh_4D initialized.");
//
//		mesh = new Geometry_4D (shape);
//	}

	void Start() {

		if (debug)
			Debug.Log ("Mesh_4D Start().");

		mesh = new Geometry_4D (shape);	// just testing
	}

	public void Render(Transform_4D cameraTransform, Transform_4D meshTransform, Mesh renderedMesh) {

		if (debug)
			Debug.Log ("Mesh_4D Render().");

		Vector3[] newVertices = new Vector3[mesh.points.Count];
		int[] newTriangles = new int[mesh.tetrahedra.Count * 3];	// 4 points per tetrahedron, 4 triangles per tetrahedron, 3 points per triangle: x / 4 * 4 * 3

		Vector4 point;
		Vector4 projectedPoint;

		Vector4 cameraNormal = new Vector4 (0, 0, 0, 1);	// for testing only, should be normalized from the cameraTransform

		Vector4 X = new Vector4 (1, 0, 0, 0);
		Vector4 Y = new Vector4 (0, 1, 0, 0);
		Vector4 Z = new Vector4 (0, 0, 1, 0);

		// projection mechanics from 4D to 3D points
		for (int i = 0; i < mesh.points.Count; i++) {	// defign points
			
			point = Transform_4D.rotate(meshTransform, mesh.points [i]);	// rotate points first according to transform
			point += meshTransform.position;								// something wrong with translation


			if (debug)
				Debug.Log ("Quaternian left: " + meshTransform.Qr.ToString ());

			projectedPoint = (-Vector4.Dot (point, cameraNormal)) * cameraNormal + point;
			//newVertices[i] = new Vector3 (Vector4.Project(projectedPoint, X).magnitude, Vector4.Project(projectedPoint, Y).magnitude, Vector4.Project(projectedPoint, Z).magnitude);	// broken
			newVertices[i] = projectedPoint;	// temparary

			if (debug)
				Debug.Log ("origional: " + point + ", projected: " + projectedPoint + ", new Vertex: " + newVertices [i]);
		}

		int j;
		for (int i = 0; i < mesh.tetrahedra.Count; i += 4) {	// defign triangles to build tetrahedra
			j = i * 3;

			//if (debug)
				//Debug.Log ("Mesh_4D start i: " + i + ", j: " + j);

			newTriangles[j++] = mesh.tetrahedra[i + 0];
			newTriangles[j++] = mesh.tetrahedra[i + 1];
			newTriangles[j++] = mesh.tetrahedra[i + 2];

			newTriangles[j++] = mesh.tetrahedra[i + 0];
			newTriangles[j++] = mesh.tetrahedra[i + 1];
			newTriangles[j++] = mesh.tetrahedra[i + 3];

			newTriangles[j++] = mesh.tetrahedra[i + 0];
			newTriangles[j++] = mesh.tetrahedra[i + 2];
			newTriangles[j++] = mesh.tetrahedra[i + 3];

			newTriangles[j++] = mesh.tetrahedra[i + 1];
			newTriangles[j++] = mesh.tetrahedra[i + 2];
			newTriangles[j] = mesh.tetrahedra[i + 3];

			//if (debug)
				//Debug.Log ("Mesh_4D end i: " + i + ", j: " + j);

		}

		if (debug)
			Debug.Log ("Mesh_4D done");

		renderedMesh.Clear();
		renderedMesh.vertices = newVertices;
		renderedMesh.triangles = newTriangles;
		renderedMesh.RecalculateBounds ();
		renderedMesh.RecalculateNormals ();
	}
		
}
