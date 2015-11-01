using UnityEngine;
using System.Collections;
using GameSystems;
using System;

public class EnemyA : MonoBehaviour {

    //プレイヤー座標取得用
    private GameObject player;
    private Vector3 playerPos;

    //調整用スピード
    public float speed = 1;

    //ステート
    private string[] enemyState = new string[2] {"wonder", "attack"};
    //ステート変更用
    private string nowState;

    //プレイヤーとの距離
    private float limitDistanse = 5;
    private float distance;

    StageManager sm;

    ScenChanger sc = new ScenChanger();

    Controller con;

    //アイテム関連
    public GameObject[] item;
    public int itemTmp;

    //音
    public AudioClip[] audioSorce;
    private AudioSource audio;

    void Start()
    {
        //プレイヤー取得
        player = GameObject.FindGameObjectWithTag("Player");
        con = player.GetComponent<Controller>();

        //徘徊モードにする
        nowState = enemyState[0];

        //ステージマネージャーコンポーネント
        sm = FindObjectOfType<StageManager>();

        //弾ポジション
        bullet.transform.position = new Vector3(transform.position.x, 2, 10);
        bullet.SetActive(false);

        //音を鳴らすコンポーネント
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //print(evilPoint);
        //プレーヤーの位置
        playerPos = player.transform.position;

        //プレイヤーとの距離
        distance = Vector3.Distance(transform.position, playerPos);
        //wonderモード
        if(distance > limitDistanse)
        {
            nowState = enemyState[0];
        }
        //attackモード
        else
        {
            nowState = enemyState[1];
            try
            {
                bullet.SetActive(true);
            }catch(Exception)
            {
                
            }

        }
        //ステートによりモード切替
        switch (nowState)
        {
            case "wonder":
                wonder();
                break;
            case "attack":
                //attack();
                StartCoroutine(shot());
                break;
        }

        //悪意0でアイテムポップ
        if(evilPoint <= 0)
        {
            //非表示、Controllerのターゲットリストから削除
            gameObject.SetActive(false);
            con.list.Remove(gameObject);

            //アイテム抽選、アイテムドロップ
            itemRnd();
            itemPop();
        }
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
    public GameObject bullet;
    //2秒間弾を出す
    IEnumerator shot()
    {
        try
        {

            //方向
            Vector3 direction = playerPos - bullet.transform.position;

            //単位化（距離要素を取り除く
            direction = direction.normalized;

            //プレイヤーに向かって移動
            bullet.transform.position = bullet.transform.position + (direction * speed * Time.deltaTime);

            //プレーヤーの方を向く
            transform.LookAt(player.transform);

        }
        catch (Exception)
        {
            yield break;
        }
    }
    public void attack()
    {
        try
        {

            //方向
            Vector3 direction = playerPos - bullet.transform.position;

            //単位化（距離要素を取り除く
            direction = direction.normalized;

            //プレイヤーに向かって移動
            bullet.transform.position = bullet.transform.position + (direction * speed * Time.deltaTime);

            //プレーヤーの方を向く
            transform.LookAt(player.transform);

        }
        catch (Exception)
        {

        }

    }

    //悪意（体力）外用
    public float evilPoint = 25f;
    public float getEvil()
    {
        return evilPoint;
    }
    public void setEvil(float e)
    {
        evilPoint += e;
    }

    //プレイヤーの更生力
    private float jabAtk;
    private float smashAtk;
    void OnTriggerEnter(Collider c)
    {
        //音量調整
        audio.volume = 0.1f;

        jabAtk = con.getJabAtk();
        smashAtk = con.getSmashAtk();
        switch (c.tag)
        {
            case "Jab":
                print("Hit Jab");
                //ジャブのヒット音
                audio.PlayOneShot(audioSorce[0]);

                evilPoint -= jabAtk;
                break;
            case "Smash":
                print("Hit Smash");
                //スマッシュのヒット音
                audio.PlayOneShot(audioSorce[1]);

                evilPoint -= smashAtk;
                break;
        }
    }

    //アイテムドロップ
    void itemPop()
    {
        Instantiate(item[itemTmp], transform.position, Quaternion.identity).name = itemTmp.ToString();
    }

    //アイテムの抽選メソッド
    public int itemRnd()
    {
        itemTmp = UnityEngine.Random.Range(0, 3);
        return itemTmp;
    }
}
