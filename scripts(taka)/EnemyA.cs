using UnityEngine;
using System.Collections;

//プレーヤー目指して一直線タイプ
public class EnemyA : MonoBehaviour {

	public Transform player;
	public float speed =1;
	public int hp = 10;
	public int attackpower = 1;
	private string enemyState;
	private string[] state = new string[2] {"MOVE", "ATTACK"};
	private float lastAttackTime;
	private float attackInterval = 2f;
	public float limitDistance = 10f;

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


		print (enemyState);
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
		playerPos = player.position;//プレーヤーの位置
		Vector3 mypos = new Vector3 (playerPos.x, 1, playerPos.z);
		distance = Vector3.Distance(playerPos , transform.position); 
		Vector3 direction = mypos - transform.position; //方向
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

		bullet.SetActive (true);//表示させる球の設定

		lastAttackTime = Time.time;

		yield return new WaitForSeconds (waitForSeconds);//待期時間
		enemyState = state [0];			//呼び出すスイッチ分の内容

		bullet.SetActive (false);//表示させた球を消す
		yield break;					//待期時間を終了させる
	}
	



	void OnCollisionEnter(Collision coll) {
		print (coll.gameObject);


		if (coll.gameObject.name != "zimen" && coll.gameObject.name != "kabe" ) {
			hp = hp - attackpower;
			
			if( hp <= 0){
			Destroy(this.gameObject);
			}
		} 
		
	



	}
}
