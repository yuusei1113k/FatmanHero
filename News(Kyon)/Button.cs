using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using GameSystems;

<<<<<<< HEAD
public class Button : MonoBehaviour {
=======
public class Button : MonoBehaviour
{
>>>>>>> remotes/origin/kyon

    //モーダル
    private GameObject modal;

    //TFiP発動中かどうか
    private bool tfip;
    private bool pushButton;

    //BMIManagerコンポーネント
    BMIManager bmiManager;

    State state = new State();
<<<<<<< HEAD
    
=======

    ScenChanger sc = new ScenChanger();

    private ParticleSystem tEffect;
>>>>>>> remotes/origin/kyon

    void Start()
    {
        //モーダル取得・非表示
<<<<<<< HEAD
        modal = GameObject.Find("Modal");
=======
        modal = GameObject.Find("PauseModal");
>>>>>>> remotes/origin/kyon
        //print(modal);
        modal.SetActive(false);

        //BMIManagerコンポーネント
        bmiManager = FindObjectOfType<BMIManager>();

        //初期化
        tfip = false;
        pushButton = false;
<<<<<<< HEAD
=======

        tEffect = GameObject.Find("TEffect").GetComponent<ParticleSystem>();

        tEffect.Stop();

>>>>>>> remotes/origin/kyon
    }

    public void buttonTrue()
    {
<<<<<<< HEAD
        if(pushButton == false)
=======
        if (pushButton == false)
>>>>>>> remotes/origin/kyon
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
<<<<<<< HEAD
        if(state.getState() == GameState.Playing)
=======
        if (state.getState() == GameState.Playing)
>>>>>>> remotes/origin/kyon
        {
            //時間を止めてモーダルを出す
            Time.timeScale = 0f;
            print("timeScale = 0");
            state.setState(GameState.Pausing);
<<<<<<< HEAD
            modal.SetActiveRecursively(true);
=======
            modal.SetActive(true);
>>>>>>> remotes/origin/kyon
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

<<<<<<< HEAD
=======
    //タイトルボタン
    public void toTitle()
    {
        sc.toTitle();
    }

    //取得用ボタンを押しているかどうか
>>>>>>> remotes/origin/kyon
    public bool getPushButton()
    {
        return pushButton;
    }
<<<<<<< HEAD
    
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
=======

    //T・FiPボタン
    public void startTFiP()
    {
        if (state.getState() == GameState.Playing)
        {
            //T・FiPが発動してなければ
            if (tfip == false)
            {
                //発動
                tfip = true;
                tEffect.Play();
            }
            //T・FiPが波動中だったら
            else
            {
                //停止
                tEffect.Stop();
                tfip = false;
            }
>>>>>>> remotes/origin/kyon
        }
    }

    //スキルボタン
    public void useSkill()
    {
<<<<<<< HEAD
        //BMIManagerコンポーネントのスキルを発動
        bmiManager.skill();
    }

    
    void Update()
    {
        if(tfip == true)
=======
        if (state.getState() == GameState.Playing)
        {
            //BMIManagerコンポーネントのスキルを発動
            bmiManager.useSkill();
        }
    }


    void Update()
    {
        if (tfip == true)
>>>>>>> remotes/origin/kyon
        {
            bmiManager.tFiP();
        }
    }
<<<<<<< HEAD
=======

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
>>>>>>> remotes/origin/kyon
}
