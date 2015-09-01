using UnityEngine;
using System.Collections;

public class conatct_Destroy : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;





	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController'");

		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Boundary"){


			return;

		}
		Instantiate (explosion, transform.position, transform.rotation);
		if(other.tag == "Player"){
		Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Debug.Log (other.name);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
