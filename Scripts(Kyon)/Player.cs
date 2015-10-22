using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //プレイヤーの移動スピード調整用変数
    public float speed = 1;

    //タッチされた座標
    private Vector2 touch;

    //フリック判定用タッチ判定時間
    private double touchJdg = 0.08;

    //フリック判定用タッチ判定移動量
    private double flickJdg = 30;

    //タッチ後移動した座標
    private Vector2 dragPoint;

    //フリック用タッチしている時間
    private double touchTime;

    //フリック用フリックなのか判定
    private bool flickOk;

    //タッチした位置と移動した位置の差分ベクトル
    private Vector3 direction;

    private Vector3 flickJump;

    //directionに入れる座標
    private double x;
    private double y;
    private double z;
    
    //回転速度
    private float rotationSpeed = 10000.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        move();
    }

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
        }

        //タッチされている間
        if (Input.GetMouseButton(0))
        {
            //タッチ後移動した座標
            dragPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //プレイヤーが移動するベクトル
            x = dragPoint.x - touch.x;
            y = 0;
            z = dragPoint.y - touch.y;

            //タッチされてる時間を計測
            touchTime += Time.deltaTime;

            //フリック判定
            //時間
            if (touchTime < touchJdg)
            {
                print("touchTime: " + touchTime);

                print("touchTime is short");
                
                //指移動量Mathf.Abs(float value)でvalueの絶対値を返す
                if (Mathf.Abs((float)x) > flickJdg || Mathf.Abs((float)z) > flickJdg)
                {
                    print("Flick stanby OK");
                    //フリックであると判定する
                    flickOk = true;
                }
                /*//必要か微妙
                else
                {
                    return;
                }
                */
            }

            //タッチ位置と移動位置が同じなら移動
            else if (dragPoint != touch)
            {
                //入力をVector3に変換/移動量を制限
                direction = new Vector3((float)x, (float)y, (float)z) / 1000;

                //入力ベクトルをQuaternionに変換
                Quaternion to = Quaternion.LookRotation(direction);

                //キャラクターを向かせる
                transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.deltaTime);

                //タッチされた座標を画面上の座標に変換
                Vector3 cm = Camera.main.ScreenToWorldPoint(direction);
                Vector3 moveTo = new Vector3(cm.x * -1, 0, cm.z * -1) / 100;

                //移動
                transform.Translate(moveTo * speed);
            }
        }

        if (flickOk == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                print("Flick");
                //
                flickJump = new Vector3((float)x, 5f, (float)z);
                //Rigitbodyの影響で少しずつ傾くのを逐一初期化する
                //初期化しないとそのうちコケる
                transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, 0f));

                //ジャンプ
                //transform.Translate(flickJump / 10);
            }
        }
    }
}
