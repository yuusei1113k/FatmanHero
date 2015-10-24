using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    //ポーズ中かどうか
    private bool pause = false;

    //モーダル
    private GameObject modal;

    //TFiP発動中かどうか
    private bool tfip;
    
    //BMIManagerコンポーネント
    BMIManager bmiManager;

    void Start()
    {
        //モーダル取得・非表示
        modal = GameObject.Find("Modal");
        print(modal);
        modal.SetActive(false);

        //BMIManagerコンポーネント
        bmiManager = FindObjectOfType<BMIManager>();

        //初期化
        tfip = false;
        pause = false;
    }

    //ポーズボタン
    public void pushPause()
    {
        print("Push");
        //ポーズ中でなければ
        if(pause == false)
        {
            //時間を止めてモーダルを出す
            Time.timeScale = 0f;
            print("timeScale = 0");
            pause = true;
            modal.SetActiveRecursively(true);
        }
        //ポーズ中だったら
        else
        {
            //時間を動かしモーダルを消す
            Time.timeScale = 1.0f;
            modal.SetActive(false);
            pause = false;
        }
    }
    
    //T・FiPボタン
    public void startTFiP()
    {
        //T・FiPが発動してなければ
        if (tfip == false)
        {
            //発動
            tfip = true;
        }
        //T・FiPが波動中だったら
        else
        {
            //停止
            tfip = false;
        }
    }

    //スキルボタン
    public void useSkill()
    {
        //BMIManagerコンポーネントのスキルを発動
        bmiManager.skill();
    }

    
    void Update()
    {
        if(tfip == true)
        {
            bmiManager.tFiP();
        }
    }
}
