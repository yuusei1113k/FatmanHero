using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using GameSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    //モーダル
    private GameObject modal;

    //現在のステージ
    private GameObject nowStage;

    //TFiP発動中かどうか
    private bool tfip;
    private bool pushButton;

    //BMIManagerコンポーネント
    BMIManager bmiManager;

    //ステート
    State state = new State();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //パーティクル
    private ParticleSystem tEffect;

    //
    Animator anim;

    void Start()
    {
        //モーダル取得・非表示
        modal = GameObject.Find("PauseModal");
        nowStage = GameObject.Find("StageName");
        modal.SetActive(false);

        //BMIManagerコンポーネント
        bmiManager = FindObjectOfType<BMIManager>();

        //初期化
        tfip = false;
        pushButton = false;

        tEffect = GameObject.Find("TEffect").GetComponent<ParticleSystem>();

        tEffect.Stop();

        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    //ボタン押しているか
    public void buttonTrue()
    {
        if (pushButton == false)
        {
            pushButton = true;
        }
    }

    //ボタン話しているか
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
        if (state.getState() == GameState.Playing)
        {
            //時間を止めてモーダルを出す
            Time.timeScale = 0f;
            print("timeScale = 0");
            state.setState(GameState.Pausing);
            nowStage.GetComponent<Text>().text = "現在のステージ\n" + sc.getStageName();
            modal.SetActive(true);
        }
        //ポーズ中だったら
        else
        {
            //時間を動かしモーダルを消す
            Time.timeScale = 1.0f;
            modal.SetActive(false);
            state.setState(GameState.Playing);
        }
    }

    //タイトルボタン
    public void toTitle()
    {
        sc.toTitle();
    }

    //取得用ボタンを押しているかどうか
    public bool getPushButton()
    {
        return pushButton;
    }

    //T・FiPボタン
    public void startTFiP()
    {
        print("tfip: " + tfip);
        if (state.getState() == GameState.Playing)
        {
            //T・FiPが発動してなければ
            if (tfip == false)
            {
                //発動
                tfip = true;
                anim.SetBool("TFiP", true);
                //tEffect.Play();
            }
            //T・FiPが波動中だったら
            else
            {
                //停止
                tEffect.Stop();
                anim.SetBool("TFiP", false);
                tfip = false;
            }
        }
    }

    //スキルボタン
    public void useSkillSonic()
    {
        if (state.getState() == GameState.Playing)
        {
            //BMIManagerコンポーネントのスキルを発動
            bmiManager.useSkillSonic();
        }
    }
    //スキルボタン
    public void useSkillHundred()
    {
        if (state.getState() == GameState.Playing)
        {
            //BMIManagerコンポーネントのスキルを発動
            bmiManager.useSkillHundred();
        }
    }
    //スキルボタン
    public void useSkillGround()
    {
        if (state.getState() == GameState.Playing)
        {
            //BMIManagerコンポーネントのスキルを発動
            bmiManager.useSkillHavoc();
        }
    }


    void Update()
    {
        if (tfip == true)
        {
            bmiManager.tFiP();
        }
    }

    //ポーズAndroid用
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            //ホームボタンを押してアプリがバックグランドに移行した時
            state.setState(GameState.Playing);
            pushPause();
            Debug.Log("バックグランドに移行したよ");
        }
        else
        {
            //アプリを終了しないでホーム画面からアプリを起動して復帰した時
            Debug.Log("バックグランドから復帰したよ");
        }
    }
}
