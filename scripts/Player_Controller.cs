using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary 
{
	public float xMin,xMax,zMin,zMax;


}

public class Player_Controller : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform Shot_Spawn;
	public float fireRate;


	private float nextFire;

	void Update(){

		if (Input.GetButton ("Fire1") && Time .time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, Shot_Spawn.position, Shot_Spawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate(){
			//float moveHorizontal = Input.GetAxis ("Horizontal");
			//float moveVertical = Input.GetAxis("Vertical");
		Vector3  acceleration = Input.acceleration;
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
		GetComponent<Rigidbody>().velocity = movement*speed;
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),

			 	0.0f, 

				Mathf.Clamp (GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)



			 );
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x*-tilt);

	}

}
