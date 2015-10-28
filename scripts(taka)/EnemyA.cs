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
	public float limitDistance = 10f;
	public Transform muzzle;
	public GameObject bullet;
	public Vector3 playerPos ;
	public float distance;
	public float waitForSeconds;



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
		playerPos = player.position; //プレーヤーの位置
		distance = Vector3.Distance(playerPos , transform.position); 
		Vector3 direction = playerPos - transform.position; //方向
		direction = direction.normalized; //単位化（距離要素を取り除く
		transform.position = transform.position + (direction * speed * Time.deltaTime);
		print (direction);//方向
		transform.LookAt (player);//プレーヤーの方を向く
		if (distance <= limitDistance) {

			enemyState = state [1];
		}
	}


	public void attack(){
		/*if (distance > limitDistance) {
			print("Hoge");
			enemyState = state [0];
		}*/

		playerPos = player.position;                 //プレイヤーの位置

		distance = Vector3.Distance(playerPos , transform.position); //方向
		StartCoroutine (attackstop ());

	}	





	IEnumerator attackstop(){
		/*Vector3 nowPosition = new Vector3 (transform.position.x, 5f, transform.position.z);
		transform.position = nowPosition;*/
		//Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
		bullet.SetActive (true);
		lastAttackTime = Time.time;
		//transform.position = transform.position;
		yield return new WaitForSeconds (waitForSeconds);
		enemyState = state [0];
		bullet.SetActive (false);
		yield break;
	}
	



	/*void OnTriggerEnter(Collider coll) {
		hp = hp - attackpower;
		
		if( hp <= 0){
			Destory(GameObject);
		}

		if (coll.gameObject.tag == "Player") {
			//Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
		}
	}*/
}
