using UnityEngine;
using System.Collections;

public class MoveSibo : MonoBehaviour {
	private Vector3 siboPos ;
	private Vector3 startPos;
	private Vector3 startRot;
	private int Ltime ;
	public GameObject camera ;
	Animator anim;
	
	// Use this for initialization
	/*
	void Start () {
		//camera = GameObject.Find("Main Camera");
		print (camera);
		//rb = GetComponent<Rigidbody> ();
		//siboPos = transform.localPosition;
		siboPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround (camera.transform.position, new Vector3(0, 10f), 0.1f);
		//transform.localPosition = new Vector3(siboPos.x, siboPos.y, 0);
		transform.position = siboPos; 
		//transform.LookAt (Vector3.zero);
		//transform.rotation.y += 0.1f;
		siboPos.x += 0.01f;
		//transform.Rotate(new Vector3(0, 90, 0) * 0.1f);
	}
}
*/
	
	
	
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetLayerWeight(6, 1);
		//camera = GameObject.Find("Main Camera");
		print (camera);
		//rb = GetComponent<Rigidbody> ();
		//siboPos = transform.localPosition;
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