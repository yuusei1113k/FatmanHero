using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    //モーダル
    private GameObject modal;

    //TFiP発動中かどうか
    private bool tfip;
    private bool pushButton;

    //BMIManagerコンポーネント
    BMIManager bmiManager;

    StageManager stage;

    void Start()
    {
        //モーダル取得・非表示
        modal = GameObject.Find("Modal");
        print(modal);
        modal.SetActive(false);

        //BMIManagerコンポーネント
        bmiManager = FindObjectOfType<BMIManager>();
        stage = FindObjectOfType<StageManager>();

        //初期化
        tfip = false;
        pushButton = false;
    }

    public void buttonTrue()
    {
        if(pushButton == false)
        {
            pushButton = true;
        }
    }

    public void buttonFalse()
    {
        if (pushButton == true)
        {
            pushButton = false;
        }
    }

    //ポーズボタン
    public void pushPause()
    {
        print("Push");
        //ポーズ中でなければ
        if(stage.getPause() == false)
        {
            //時間を止めてモーダルを出す
            Time.timeScale = 0f;
            print("timeScale = 0");
            stage.setPause(true);
            modal.SetActiveRecursively(true);
        }
        //ポーズ中だったら
        else
        {
            //時間を動かしモーダルを消す
            Time.timeScale = 1.0f;
            modal.SetActive(false);
            stage.setPause(false);
        }
    }

    public bool getPushButton()
    {
        return pushButton;
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
