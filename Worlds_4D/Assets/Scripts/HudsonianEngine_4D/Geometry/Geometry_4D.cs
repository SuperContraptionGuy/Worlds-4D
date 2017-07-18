using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry_4D {			// TODO add a file reader for 4D geometry files.  Maybe include UVs?
									// 4D Files:
									//		Vertecies
									//		Tetrahedra
									//		3D UV map	

	public List<Vector4> points = new List<Vector4>();
	public List<int> tetrahedra = new List<int>();

	public Geometry_4D(string shape) {

		switch (shape) {

		case "Hypercube":
			generateHypercube ();
			break;

		case "Hypersphere":
			generateHypersphere ();
			break;
			
		}
	}

	public void generateHypercube() {

		List<Vector4> hypercube_points = new List<Vector4>();
		List<int> hypercube_tetrahedra = new List<int>();



		// shape definition:

		//	hypercube
		//	(x, y, z, w)
		hypercube_points.Add (new Vector4(0.5f, 0.5f, 0.5f, 0.5f));
		hypercube_points.Add (new Vector4(-0.5f, 0.5f, 0.5f, 0.5f));
		hypercube_points.Add (new Vector4(0.5f, -0.5f, 0.5f, 0.5f));
		hypercube_points.Add (new Vector4(-0.5f, -0.5f, 0.5f, 0.5f));
		hypercube_points.Add (new Vector4(0.5f, 0.5f, -0.5f, 0.5f));
		hypercube_points.Add (new Vector4(-0.5f, 0.5f, -0.5f, 0.5f));
		hypercube_points.Add (new Vector4(0.5f, -0.5f, -0.5f, 0.5f));
		hypercube_points.Add (new Vector4(-0.5f, -0.5f, -0.5f, 0.5f));
		hypercube_points.Add (new Vector4(0.5f, 0.5f, 0.5f, -0.5f));
		hypercube_points.Add (new Vector4(-0.5f, 0.5f, 0.5f, -0.5f));
		hypercube_points.Add (new Vector4(0.5f, -0.5f, 0.5f, -0.5f));
		hypercube_points.Add (new Vector4(-0.5f, -0.5f, 0.5f, -0.5f));
		hypercube_points.Add (new Vector4(0.5f, 0.5f, -0.5f, -0.5f));
		hypercube_points.Add (new Vector4(-0.5f, 0.5f, -0.5f, -0.5f));
		hypercube_points.Add (new Vector4(0.5f, -0.5f, -0.5f, -0.5f));
		hypercube_points.Add (new Vector4(-0.5f, -0.5f, -0.5f, -0.5f));

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (0);
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (7);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (7);
		// tetrahedron
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (7);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (7);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (12);
		// tetrahedron
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (11);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (13);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (14);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (15);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (0);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (8);
		// tetrahedron
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (14);
		// tetrahedron
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (14);
		// tetrahedron
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (14);
		// tetrahedron
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (14);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (9);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (11);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (13);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (7);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (15);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (7);
		hypercube_tetrahedra.Add (8);
		// tetrahedron						///			-------------------ashton read
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (13);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (7);
		// tetrahedron
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (13);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (4);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (13);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (2);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (15);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (11);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (7);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (14);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (15);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (0);
		hypercube_tetrahedra.Add (8);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (3);
		hypercube_tetrahedra.Add (11);
		// tetrahedron
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (9);
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (11);
		// tetrahedron
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (10);
		hypercube_tetrahedra.Add (11);
		// tetrahedron
		hypercube_tetrahedra.Add (1);
		hypercube_tetrahedra.Add (8);
		hypercube_tetrahedra.Add (2);
		hypercube_tetrahedra.Add (11);

		// cube
		// tetrahedron
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (4);
		// tetrahedron
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (7);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (13);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (14);
		hypercube_tetrahedra.Add (15);
		// tetrahedron
		hypercube_tetrahedra.Add (5);
		hypercube_tetrahedra.Add (12);
		hypercube_tetrahedra.Add (6);
		hypercube_tetrahedra.Add (15);

		this.points = hypercube_points;
		this.tetrahedra = hypercube_tetrahedra;
	}

	public void generateHypersphere() {




	}
}
