using UnityEngine;
using System.Collections;

public class Hitefect : MonoBehaviour {
	public GameObject playerattackHit;

	public void PlayerattackHit ()
	{
		Vector3 hit = new Vector3 (transform.position.x, 2.2f, transform.position.z-0.5f);
		Instantiate (playerattackHit, hit, playerattackHit.transform.rotation);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
