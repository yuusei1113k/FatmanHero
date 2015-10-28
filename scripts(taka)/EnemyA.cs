using UnityEngine;
using System.Collections;

//プレーヤー目指して一直線タイプ
public class EnemyA : MonoBehaviour {

	public Transform player;
	public float speed =1;
	public int hp = 10;
	public int atackpower = 2;
	private string enemyState;
	private string[] state = new string[2] {"MOVE", "ATTACK"};
	private float lastAttackTime;
	private float attackInterval = 2f;
	public float limitDistance = 5f;
	public Transform muzzle;
	public GameObject bulletPrefab;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		enemyState = state[0];
	}
	
	// Update is called once per frame
	void Update () {


		switch (enemyState){
		case "MOVE":	
			move();
			break;

		case "ATTACK":
			attack();
			break;
			}
	}

		
	public void move(){
		Vector3 playerPos = player.position; //プレーヤーの位置
		Vector3 direction = playerPos - transform.position; //方向
		direction = direction.normalized; //単位化（距離要素を取り除く
		transform.position = transform.position + (direction * speed * Time.deltaTime);
		transform.LookAt (player);//プレーヤーの方を向く
	}


	public void attack(){
		Vector3 playerPos = player.position;                 //プレイヤーの位置
		Vector3 direction = playerPos - transform.position; //方向と距離を求める。
		float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
		direction = direction.normalized;   

		if (Time.time > lastAttackTime + attackInterval) {
			Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
			lastAttackTime = Time.time;

			transform.LookAt (player);
		}
		


	}
	
	
	
	/*void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			//Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
		}
	}*/
}
