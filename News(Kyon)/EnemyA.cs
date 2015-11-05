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
    private string[] enemyState = new string[3] {"wonder", "attack","explode"};
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
        if(distance > limitDistanse && evilPoint >= 0)
        {
            nowState = enemyState[0];
        }
        //attackモード
        else if(distance <= limitDistanse && evilPoint >= 0)
        {
            nowState = enemyState[1];
            try
            {
                bullet.SetActive(true);
            }
            catch (Exception)
            {
                
            }
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
                break;
            case "attack":
                //attack();
                StartCoroutine(shot());
                break;
            case "explode":
                StartCoroutine(explode());
                break;
        }
    }

    //やられたらカウント。
    void OnDisable()
    {
        sm.Counter(1);
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
        try
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
                case "Hado":
                    print("Hado");
                    //スマッシュのヒット音
                    audio.PlayOneShot(audioSorce[1]);
                    evilPoint -= smashAtk;
                    break;
            }

        }
        catch (Exception) { }
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

    //吹き飛ぶ
    IEnumerator explode()
    {
        // ランダムな吹き飛ぶ力を加える
        Vector3 force = Vector3.up * 1000f + UnityEngine.Random.insideUnitSphere * 300f;
        GetComponent<Rigidbody>().AddForce(force);

        // ランダムに吹き飛ぶ回転力を加える
        Vector3 torque = new Vector3(UnityEngine.Random.Range(-10000f, 10000f), UnityEngine.Random.Range(-10000f, 10000f), UnityEngine.Random.Range(-10000f, 10000f));
        GetComponent<Rigidbody>().AddTorque(torque);

        // 1秒後に自身を消去する
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
        //アイテム抽選、アイテムドロップ
        itemRnd();
        itemPop();
        
    }
}
