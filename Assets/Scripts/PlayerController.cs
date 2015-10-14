using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Rigidbody rigibody = GetComponent<Rigidbody>();
		rigibody.velocity = movement * speed;

		rigibody.position = new Vector3 
		(
				Mathf.Clamp (rigibody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
				Mathf.Clamp (rigibody.position.z, boundary.zMin, boundary.zMax)
		);

		rigibody.rotation = Quaternion.Euler (0.0f, 0.0f, rigibody.velocity.x * -tilt);
	}
}
