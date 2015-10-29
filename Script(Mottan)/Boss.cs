using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	//public bool BD = GameObject.FindGameObjectWithTag("Boss");
	// Use this for initialization
	private SceneChanger SC;
	void Start () {
		
	}
	void Update () {
		SC = FindObjectOfType<SceneChanger> ();
	}
	void OnCollisionEnter (Collision collision ) {
		if (collision.gameObject.tag == "Player") {
			SC.toResult ();
		}
	}
}