using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_4D {

	public Quaternion Ql = new Quaternion();		//Left Isoclinical rotaions
	public Quaternion Qr = new Quaternion();		// right isoclinical rotations
	public Vector4 position = new Vector4();		// 4D position vector

	public Transform_4D() {

		Ql = Quaternion.identity;
		Qr = Quaternion.identity;
		position = Vector4.zero;
	}

//	public static implicit operator Transform (Transform_4D transform_4D) {

//		Transform transform_3D = new Transform();
//
//		transform_3D.position = transform_4D.position;	// Loss of information: bad conversion of position matrix from 4D to 3D
//		transform_3D.rotation = transform_4D.Ql;		// loss of information: bad conversion of rotation matrix from 4D to 3D
//	}

	public static implicit operator Transform_4D (Transform transform_3D) {

		Transform_4D transform_4D = new Transform_4D();

		transform_4D.position = transform_3D.position;	// lack of information
		transform_4D.Ql = transform_3D.rotation;		// lack of information: bad conversion of rotation from 3D to 4D
		//transform_4D.Qr = ...							// incomplete conversion

		return transform_4D;
	}

	public static Vector4 rotate (Transform_4D transform, Vector4 point) {

		point = new Vector4(
			point[0] * transform.Ql.w -
			point[0] * transform.Ql.x -
			point[0] * transform.Ql.y -
			point[0] * transform.Ql.z,

			point[1] * transform.Ql.x +
			point[1] * transform.Ql.w -
			point[1] * transform.Ql.z +
			point[1] * transform.Ql.y, 

			point[2] * transform.Ql.y +
			point[2] * transform.Ql.z +
			point[2] * transform.Ql.w -
			point[2] * transform.Ql.x, 

			point[3] * transform.Ql.z -
			point[3] * transform.Ql.y +
			point[3] * transform.Ql.x +
			point[3] * transform.Ql.w
		);

		point = new Vector4(
			point[0] * transform.Qr.w -
			point[0] * transform.Qr.x -
			point[0] * transform.Qr.y -
			point[0] * transform.Qr.z,

			point[1] * transform.Qr.x +
			point[1] * transform.Qr.w -
			point[1] * transform.Qr.z +
			point[1] * transform.Qr.y, 

			point[2] * transform.Qr.y +
			point[2] * transform.Qr.z +
			point[2] * transform.Qr.w -
			point[2] * transform.Qr.x, 

			point[3] * transform.Qr.z -
			point[3] * transform.Qr.y +
			point[3] * transform.Qr.x +
			point[3] * transform.Qr.w
		);

		return point;
	}

}
