using UnityEngine;
using System.Collections;

public class MoveSibo : MonoBehaviour {
	private Vector3 siboPos ;
	private Vector3 startPos;
	private Vector3 startRot;
	private int Ltime ;
	public GameObject camera ;
	Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetLayerWeight(6, 1);
		print (camera);
		siboPos = transform.position;
		startPos = transform.position;
		startRot = transform.localEulerAngles;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (camera.transform.position, new Vector3(0, 10f), 0.1f);
		transform.position = new Vector3(transform.position.x,transform.position.y, siboPos.z);
		
		if (transform.position.x > 45) {
			transform.position = startPos;
			transform.eulerAngles = startRot;
			
		}
		
		
	}
}