﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using GameSystems;

public class Button : MonoBehaviour {

    //モーダル
    private GameObject modal;

    //TFiP発動中かどうか
    private bool tfip;
    private bool pushButton;

    //BMIManagerコンポーネント
    BMIManager bmiManager;

<<<<<<< HEAD
    State state = new State();
    
=======
    StageManager stage;
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f

    void Start()
    {
        //モーダル取得・非表示
        modal = GameObject.Find("Modal");
<<<<<<< HEAD
        //print(modal);
=======
        print(modal);
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f
        modal.SetActive(false);

        //BMIManagerコンポーネント
        bmiManager = FindObjectOfType<BMIManager>();
<<<<<<< HEAD
=======
        stage = FindObjectOfType<StageManager>();
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f

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
<<<<<<< HEAD
        if(state.getState() == GameState.Playing)
=======
        if(stage.getPause() == false)
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f
        {
            //時間を止めてモーダルを出す
            Time.timeScale = 0f;
            print("timeScale = 0");
<<<<<<< HEAD
            state.setState(GameState.Pausing);
=======
            stage.setPause(true);
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f
            modal.SetActiveRecursively(true);
        }
        //ポーズ中だったら
        else
        {
            //時間を動かしモーダルを消す
            Time.timeScale = 1.0f;
            modal.SetActive(false);
<<<<<<< HEAD
            state.setState(GameState.Playing);
=======
            stage.setPause(false);
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f
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
