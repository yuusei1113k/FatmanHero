using UnityEngine;
using System.Collections;

//プレーヤー目指して一直線タイプ
public class EnemyEx : MonoBehaviour {

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

	//アイテム関連
	public GameObject[] item ;
	public int itemTmp;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyState = state [0];
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
	

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Player") {
			hp = 0;
			Destroy(gameObject);
			itemPop();
			}
	}

	void itemPop(){
		Instantiate(item[itemTmp] , transform.position , transform.rotation);
	}

	//アイテムの抽選メソッド
	public void itemRnd(){
		itemTmp = Random.Range (0, 3);
		//Debug.Log ("アイテム抽選：" + itemTmp);
	}

	public int hpDown(){
		return hp;
	}


}
