using UnityEngine;
using System.Collections;

public class EnemyB : MonoBehaviour {

	public Transform player;    //プレイヤーを代入
	public Transform punch;
	public float speed = 5; //移動速度
	public float limitDistance = 10f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）
	public int hp = 10;
	public GameObject bulletPrefab;
	private float lastAttackTime;
	private float attackInterval = 2f;
	//private bool isGround = false;
	
	//ゲーム開始時に一度
	void Start () {
		//Playerオブジェクトを検索し、参照を代入
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	//毎フレームに一度
	void Update () {
		Vector3 playerPos = player.position;                 //プレイヤーの位置
		Vector3 direction = playerPos - transform.position; //方向と距離を求める。
		float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
		direction = direction.normalized;                   //単位化（距離要素を取り除く）
		direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。
		
		//プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
		if (distance >= limitDistance) {
			
			//プレイヤーとの距離が制限値以上なので普通に近づく
			transform.position = transform.position + (direction * speed * Time.deltaTime);
			
		} else if (distance < limitDistance) {
			if (Time.time > lastAttackTime + attackInterval){
			//プレイヤーとの距離が制限値いないなので攻撃
			Instantiate(bulletPrefab, punch.position, punch.rotation);
			lastAttackTime = Time.time;
			}
		}
		
		//プレイヤーの方を向く
		transform.rotation = Quaternion.LookRotation(direction);


		/*//重力落下処理（プレイヤーの距離関係なく下に移動する）
		Vector3 rayPos = transform.position;
		rayPos.y -= 1f;
		
		//地面衝突判定処理。（今回は直接座標を操作しているため実装したが、直接座標操作はあまり好ましくないため
		//後でUnityのキャラクター操作機能を用いた敵キャラクターの実装を紹介する。）
		if (!Physics.Raycast(rayPos, Vector3.down, 0.5f)) {
			//地面からわずかに浮くのは、わざとである。（キャラクター操作機能（CharacterControllerを用いれば起きない））
			transform.position = transform.position + (Vector3.down * 9.8f * Time.deltaTime);
		}
		//地面判定線を見れるようにする
		Debug.DrawRay (rayPos, Vector3.down*1/10);
		
		//敵のY座標が-5以下の時自身を削除
		if (transform.position.y <= -5f) {
			Destroy(gameObject);
		}*/
	}
	/*void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			//Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
		}
	}*/
}
