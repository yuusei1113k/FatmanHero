using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	//移動判定かどうか
	private bool moveOk;
	
	//タップ判定かどうか
	private bool tapOk;
	
	//フリック用フリックなのか判定
	private bool flickOk;
	
	//タップ時に呼び出すオブジェクト
	public GameObject pa;
	
	//プレイヤーの移動が逆になってしまった時用
	public bool reverse = false;
	
	//プレイヤーの移動スピード調整用変数
	public float speed = 1;
	
	//タッチされた座標
	private Vector2 touch;
	
	//移動先のワールド座標
	private Vector3 cm;
	private Vector3 moveTo;
	
	//フリック判定用タッチ判定時間
	private double touchJdg = 0.15;
	
	//フリック判定用タッチ判定移動量
	private double flickJdg = 30;
	
	//タッチ後移動した座標
	private Vector2 dragPoint;
	
	//フリック用タッチしている時間
	private double touchTime;
	
	//タッチした位置と移動した位置の差分ベクトル
	private Vector3 direction;
	
	//directionに入れる座標
	private double x;
	private double y;
	private double z;
	
	//回転速度
	private float rotationSpeed = 10000.0f;
	
	//Buttonコンポーネント取得（Pause中か確認するために）
	private StageManager stage;
	
	Button button;

    //アニメーション
    Animator anim;


    void Start () {
		//StageManagerコンポーネント取得
		stage = FindObjectOfType<StageManager>();

		//攻撃判定オフ
		pa.SetActive(false);
		button = FindObjectOfType<Button>();

        //モーションをいじるため
        anim = GetComponent<Animator>();

    }

    void Update () {
		if (stage.getPause() == false)
		{
			move();
		}
	}
	
	//コントローラー状態
	public bool getFlick()
	{
		return flickOk;
	}
	
	//コントローラー本体
	public void move()
	{
		//タッチされた瞬間のみ
		if (Input.GetMouseButtonDown(0))
		{
			//タッチされた座標を取得
			touch = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			touchTime = 0;
			//タッチされるたびにフリック判定を初期化
			flickOk = false;
			tapOk = false;
			moveOk = false;
		}
		if (button.getPushButton() == false && stage.getPause() == false)
		{
			//タッチされている間
			if (Input.GetMouseButton(0))
			{
				//タップ判定
				tapOk = false;
				
				//タッチ後移動した座標
				dragPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				
				//プレイヤーが移動するベクトル
				x = dragPoint.x - touch.x;
				y = 0;
				z = dragPoint.y - touch.y;
				
				//タッチされてる時間を計測
				touchTime += Time.deltaTime;
				
				//入力をVector3に変換/移動量を制限
				direction = new Vector3((float)x, (float)y, (float)z) / 1000;
				
				//フリック判定用
				Vector3 pointA = new Vector3(touch.x, 0, touch.y);
				Vector3 pointB = new Vector3(Mathf.Clamp(dragPoint.x, touch.x - 60, touch.x + 60), 0, Mathf.Clamp(dragPoint.y, touch.y - 60, touch.y + 60));
				//二点間の距離(float)
				float flickVector = Vector3.Distance(pointA, pointB);
				
				//フリックスピード
				double flickSpeed = flickVector / touchTime;
				
				//フリックスピードが800以上あればフリック
				if (flickSpeed > 800)
				{
					print("Flick stanby OK");
					//フリックであると判定する
					flickOk = true;
				}
				
				//タッチ位置と移動位置が同じなら移動
				else if (dragPoint != touch)
				{
					//移動判定オン
					moveOk = true;

                    //移動モーション
                    anim.SetBool("Move", true);
                    anim.SetTrigger("Move");
                    
                    //入力ベクトルをQuaternionに変換
                    Quaternion to = Quaternion.LookRotation(direction);
					
					//キャラクターを向かせる
					transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.deltaTime);
					
					//タッチされた座標を画面上の座標に変換
					cm = Camera.main.ScreenToWorldPoint(direction);
					moveTo = new Vector3(cm.x, 0, cm.z) / 100;
					if (reverse == true)
					{
						moveTo = new Vector3(cm.x * -1, 0, cm.z * -1) / 100;
					}
					
					//print(moveTo * speed);
					
					//移動
					transform.Translate(moveTo * speed);
				}
				//移動でもフリックでもなければ
				else if (touchTime < touchJdg)
				{
					print("TapOK");
					flickOk = false;
					moveOk = false;
					tapOk = true;
				}
			}
			
		}
		
		
		//フリックアクション
		if (flickOk == true)
		{
			if (Input.GetMouseButtonUp(0))
			{
				print("Flick");
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
				
				//瞬間移動
				cm = Camera.main.ScreenToWorldPoint(direction);
				moveTo = new Vector3(cm.x, 0, cm.z);
				if (reverse == true)
				{
					moveTo = new Vector3(cm.x * -1, 0, cm.z * -1);
				}
				
				transform.Translate(moveTo * 10);
				flickOk = false;
				print(flickOk);
			}
		}
		
		//タップアクション
		if(tapOk == true)
		{
			if (Input.GetMouseButtonUp(0))
			{
				print("TouchiTime: " + touchTime);
				
				print("Tap");
                anim.SetBool("Move", false);
                anim.SetTrigger("Attack");

                anim.SetBool("Move", false);
                anim.SetTrigger("Attack");

                //StartCoroutine(attack());
                tapOk = false;
				print(tapOk);
			}
		}
	}
	
	//アタックアクション
	IEnumerator attack()
	{
		//オブジェクト表示
		pa.SetActive(true);
		while (true)
		{
			//1.0f待機
			yield return new WaitForSeconds(1.0f);
			//非表示
			pa.SetActive(false);
			print("End of TapAction");
			//コルーチン終了
			yield break;
		}
	}
}
