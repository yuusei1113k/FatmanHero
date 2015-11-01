using UnityEngine;
using System.Collections;
using GameSystems;

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

    void Start()
    {
        //プレイヤー取得
        player = GameObject.FindGameObjectWithTag("Player");
        con = player.GetComponent<Controller>();

        //徘徊モードにする
        nowState = enemyState[0];

        sm = FindObjectOfType<StageManager>();
    }

    void Update()
    {
        //print(evilPoint);
        //プレーヤーの位置
        playerPos = player.transform.position;

        //プレイヤーとの距離
        distance = Vector3.Distance(transform.position, playerPos);
        if(distance > limitDistanse)
        {
            nowState = enemyState[0];
        }
        else
        {
            nowState = enemyState[1];
        }
        //ステートによりモード切替
        switch (nowState)
        {
            case "wonder":
                wonder();
                break;
            case "attack":
                attack();
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
    //2秒間弾を出す
    public GameObject bullet;
    public void attack()
    {
        //bullet.SetActive(true);
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
    void OnCollisionEnter(Collision c)
    {
        jabAtk = con.getJabAtk();
        smashAtk = con.getSmashAtk();
        switch (c.collider.tag)
        {
            case "Jab":
                evilPoint -= jabAtk;
                break;
            case "Smash":
                evilPoint -= smashAtk;
                break;
        }
    }

    void itemPop()
    {
        Instantiate(item[0], transform.position, Quaternion.identity).name = itemTmp.ToString();
    }

    //アイテムの抽選メソッド
    public int itemRnd()
    {
        itemTmp = Random.Range(0, 3);
        return itemTmp;

        //Debug.Log ("アイテム抽選：" + itemTmp);
    }
}
