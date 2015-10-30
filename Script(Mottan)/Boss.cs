using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	//public bool BD = GameObject.FindGameObjectWithTag("Boss");
	// Use this for initialization
	private SceneChanger SC;
	public int BossHP = 1;
	public int PlayerHP = 1;
	public bool clear;
	void Start () {
		
	}
	void Update () {
		SC = FindObjectOfType<SceneChanger> ();
		if (Input.GetKey(KeyCode.X)) {
			PlayerHP = 0;
		}else if (Input.GetKey (KeyCode.Z)) {
			BossHP = 0;
			Debug.Log ("くりあはんていないよ");
			
		}
		if (PlayerHP == 0) {
			SC.toResult();
		} else if (BossHP == 0) {
		}
	}
	/*void OnCollisionEnter (Collision collision ) {
		if (collision.gameObject.tag == "Player") {
			SC.toResult ();
		}
	}*/
}