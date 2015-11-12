using UnityEngine;
using System.Collections;
using GameSystems;
using System;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> remotes/origin/kyon

public class EnemyA : MonoBehaviour
{

    //プレイヤー座標取得用
    private GameObject player;
    private Vector3 playerPos;

    //調整用スピード
    public float speed = 1;

    //ステート
    private string[] enemyState = new string[3] { "wonder", "attack", "explode" };
    //ステート変更用
    private string nowState;

    //プレイヤーとの距離
<<<<<<< HEAD
    private float limitDistanse = 5;
=======
    private float limitDistanse = 3;
>>>>>>> remotes/origin/kyon
    private float distance;

    StageManager sm;

    ScenChanger sc = new ScenChanger();

    Controller con;

    //アイテム関連
<<<<<<< HEAD
    public GameObject[] item;
    public int itemTmp;
=======
    private GameObject[] item = new GameObject[5];
    private int itemTmp;
>>>>>>> remotes/origin/kyon

    //音
    public AudioClip[] audioSorce;
    private AudioSource audio;

    //コライダー
    BoxCollider bcol;

    //アニメーター
    Animator anim;

    //波動
<<<<<<< HEAD
    public GameObject hado;
=======
    private GameObject hado;
>>>>>>> remotes/origin/kyon

    //プレイヤーの更生力
    private float jabAtk;
    private float smashAtk;
    private bool attackOk;
<<<<<<< HEAD

    public float evilPoint = 25f;

=======
    
    //悪意
    public float evilPoint = 25f;

    //カメラオブジェクト
    GameObject camera;

    //悪意バー
    GameObject bar;
    Slider slider;


>>>>>>> remotes/origin/kyon
    void Start()
    {
        //プレイヤー取得
        player = GameObject.FindGameObjectWithTag("Player");
        con = player.GetComponent<Controller>();

<<<<<<< HEAD
        //徘徊モードにする
        nowState = enemyState[0];

        //ステージマネージャーコンポーネント
        sm = FindObjectOfType<StageManager>();
=======
        //波動
        hado = transform.GetChild(4).gameObject;

        //徘徊モードにする
        nowState = enemyState[0];

        //アイテムをリソースフォルダから取得
        for(int i = 0; i < item.Length; i++)
        {
            item[i] = (GameObject)Resources.Load("Items/" + i);
        }

        //ステージマネージャーコンポーネント
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
>>>>>>> remotes/origin/kyon

        //音を鳴らすコンポーネント
        audio = GetComponent<AudioSource>();

        //コライダー
        bcol = gameObject.GetComponent<BoxCollider>();

        //アニメーション
        anim = GetComponent<Animator>();
<<<<<<< HEAD

        anim.SetLayerWeight(1, 1f);

=======
        //アニメーターレイヤー指定
        anim.SetLayerWeight(1, 1f);

        //カメラ
        camera = GameObject.Find("Camera");

        //悪意バー
        bar = transform.GetChild(5).gameObject;
        slider = bar.GetComponent<Slider>();
        slider.maxValue = evilPoint;

>>>>>>> remotes/origin/kyon
    }

    void Update()
    {
<<<<<<< HEAD
=======
        //悪意バーがカメラを向く
        bar.transform.LookAt(camera.transform);
        slider.value = evilPoint;

>>>>>>> remotes/origin/kyon
        //プレーヤーの位置
        playerPos = player.transform.position;

        //プレイヤーとの距離
        distance = Vector3.Distance(transform.position, playerPos);

        //プレーヤーの方を向く
        transform.LookAt(player.transform);

        //wonderモード
        if (distance > limitDistanse && evilPoint >= 0)
        {
            nowState = enemyState[0];
            anim.SetBool("Move", true);
        }
        //attackモード
        else if (distance <= limitDistanse && evilPoint >= 0)
        {
            nowState = enemyState[1];
            anim.SetBool("Move", false);
        }
        else
        //悪意0でアイテムポップ
        if (evilPoint <= 0)
        {
            //Controllerのターゲットリストから削除
            con.list.Remove(gameObject);
            nowState = enemyState[2];
        }

        //print(nowState);
        //ステートによりモード切替
        switch (nowState)
        {
            case "wonder":
                wonder();
                attackOk = false;
                break;
            case "attack":
                //attack();
                if (attackOk == false)
                {
                    StartCoroutine(attack());
                    attackOk = true;
                }
                break;
            case "explode":
                bcol.enabled = false;
                StartCoroutine(explode());
                break;
        }
    }

    //やられたらカウント。
    void OnDisable()
    {
<<<<<<< HEAD
        sm.Counter(1);
=======
        try
        {
            sm.Counter(1);
        }catch(Exception e)
        {
            print(e);
        }
>>>>>>> remotes/origin/kyon
    }

    //徘徊モード
    public void wonder()
    {
        //方向
        Vector3 direction = playerPos - transform.position;

        //単位化（距離要素を取り除く
        direction = direction.normalized;

        //プレイヤーに向かって移動
        transform.position = transform.position + (direction * speed * Time.deltaTime);

        //プレーヤーの方を向く
        transform.LookAt(player.transform);
    }

    //攻撃モード
    //攻撃コルーチン
    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            anim.SetTrigger("Attack");
            hado.SetActive(true);
            if (nowState != "attack")
            {
                hado.SetActive(false);
                yield break;
            }
        }
    }


    //悪意（体力）外用
    public float getEvil()
    {
        return evilPoint;
    }
    public void setEvil(float e)
    {
        evilPoint += e;
    }

    void OnTriggerEnter(Collider c)
    {
        try
        {
<<<<<<< HEAD
        
      		hit = new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z - 0.5f);
			Transform camera = GameObject.Find("Camera").transform;
			hitefect.transform.LookAt(camera);
=======
>>>>>>> remotes/origin/kyon
            //音量調整
            audio.volume = 0.1f;

            //ジャブとスマッシュの攻撃力取得
            jabAtk = con.getJabAtk();
            smashAtk = con.getSmashAtk();
            switch (c.tag)
            {
                case "Jab":
<<<<<<< HEAD
                    print("Hit Jab");
=======
                    print("Hit to Enemy: Jab");
>>>>>>> remotes/origin/kyon
                    //ジャブのヒット音
                    audio.PlayOneShot(audioSorce[0]);
                    evilPoint -= jabAtk;
                    break;
                case "Smash":
<<<<<<< HEAD
                    print("Hit Smash");
=======
                    print("Hit to Enemy: Smash");
>>>>>>> remotes/origin/kyon
                    //スマッシュのヒット音
                    audio.PlayOneShot(audioSorce[1]);
                    evilPoint -= smashAtk;
                    break;
                case "Hado":
<<<<<<< HEAD
                    print("Hit Hado");
=======
                    print("Hit to Enemy: Hado");
>>>>>>> remotes/origin/kyon
                    //スマッシュのヒット音
                    audio.PlayOneShot(audioSorce[1]);
                    evilPoint -= smashAtk;
                    break;
                case "Sonic":
<<<<<<< HEAD
                    print("Hit Sonic");
=======
                    print("Hit to Enemy: Sonic");
>>>>>>> remotes/origin/kyon
                    //ジャブのヒット音
                    audio.PlayOneShot(audioSorce[0]);
                    evilPoint -= jabAtk;
                    break;
                case "Rush":
<<<<<<< HEAD
                    print("Hit Rush");
=======
                    print("Hit to Enemy: Rush");
>>>>>>> remotes/origin/kyon
                    //ジャブのヒット音
                    audio.PlayOneShot(audioSorce[0]);
                    evilPoint -= jabAtk * 2;
                    break;
                case "Havoc":
<<<<<<< HEAD
                    print("Hit Havoc");
=======
                    print("Hit to Enemy: Havoc");
>>>>>>> remotes/origin/kyon
                    //スマッシュのヒット音
                    audio.PlayOneShot(audioSorce[1]);
                    evilPoint -= smashAtk * 3;
                    break;
            }
        }
        catch (Exception) { }
    }

    //アイテムドロップ
    void itemPop()
    {
<<<<<<< HEAD
        Vector3 itemPos = new Vector3(transform.position.x, -2f, transform.position.z);
=======
        Vector3 itemPos = new Vector3(transform.position.x, -3f, transform.position.z);
>>>>>>> remotes/origin/kyon
        Instantiate(item[itemTmp], itemPos, Quaternion.identity).name = itemTmp.ToString();
    }

    //アイテムの抽選メソッド
    public int itemRnd()
    {
        itemTmp = UnityEngine.Random.Range(0, 3);
        return itemTmp;
    }

    //吹き飛ぶ
    IEnumerator explode()
    {
        // ランダムな吹き飛ぶ力を加える
        Vector3 force = Vector3.up * 1000f + UnityEngine.Random.insideUnitSphere * 300f;
        //GetComponent<Rigidbody>().AddForce(force);
        Vector3 up = new Vector3(0, 1f, 0);
        transform.Translate(up * Time.deltaTime * 15, Space.World);

        // ランダムに吹き飛ぶ回転力を加える
        Vector3 torque = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
        GetComponent<Rigidbody>().AddTorque(torque);

        //回転する
        transform.Rotate(force);

        // 1秒後に自身を消去する
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
        //アイテム抽選、アイテムドロップ
        itemRnd();
        itemPop();

    }
}
