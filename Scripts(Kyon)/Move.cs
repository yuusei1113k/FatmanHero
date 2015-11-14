using UnityEngine;
using System.Collections;
using GameSystems;

public class Move : MonoBehaviour {
    //移動判定かどうか
    private bool moveOk = false;

    //タップ判定かどうか
    private bool tapOk = false;

    //フリック用フリックなのか判定
    private bool flickOk = false;

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

    //Buttonコンポーネント
    Buttons button;

    //アニメーション
    Animator anim;

    //Stateクラス
    State state = new State();

    //更生力
    private float attack;

    //アクションカウント
    private int tapCount = 0;

    //オーディオソース
    private string[] audioList = new string[3] { "punch-swing", "jabpunch", "itemget" };
    private AudioClip[] audioSorce = new AudioClip[3];
    private AudioSource audio;

    //波動
    private GameObject hado;

    //BMIManager
    private BMIManager bmiManager;

    //攻撃判定オンオフ用コライダー
    SphereCollider jab;
    SphereCollider smash;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
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
            tapOk = false;
            moveOk = false;
        }
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

                    //反転用
                    if (reverse == true)
                    {
                        direction = new Vector3(-direction.x, 0, -direction.z);
                    }

                    //移動
                    transform.Translate(direction.normalized * 0.1f * speed, Space.World);
                }
                //移動でもフリックでもなければ
                else if (touchTime < touchJdg)
                {
                    flickOk = false;
                    moveOk = false;
                    tapOk = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Move", false);
            }

        //フリックアクション
        if (flickOk == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                print("Flick");
                anim.SetTrigger("Flick");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

                //反転用
                if (reverse == true)
                {
                    direction = new Vector3(-direction.x, 0, direction.z);
                }

                transform.Translate(direction * 100, Space.World);
                flickOk = false;
                //print(flickOk);
            }
        }

        //タップアクション
        if (tapOk == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                print("Tap");
                tapCount++;
                anim.SetBool("Move", false);
                anim.SetTrigger("Attack");
                //攻撃モーション時に全身
                if (tapCount / 3 != 1)
                {
                    transform.Translate(transform.forward * 2 * Time.deltaTime);
                }
                else
                {
                    transform.Translate(transform.forward / 10);
                    tapCount = 0;
                }
                tapOk = false;
            }
        }
    }

}
