using UnityEngine;
using System.Collections;

public class EnemyA : MonoBehaviour {

	public Transform player;
	public float speed =10;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.position; //プレーヤーの位置
		Vector3 direction = playerPos - transform.position; //方向
		direction = direction.normalized; //単位化（距離要素を取り除く
		transform.position = transform.position + (direction * speed * Time.deltaTime);
		transform.LookAt (player);//プレーヤーの方を向く
	}
}
