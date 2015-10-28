﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

    //残タイム
    int outTime;

    //開始時間
    float startTime;

    //経過時間
    float parseTime;

    //ポーズ中かどうか
    private bool pause;

    //クリアかゲームオーバーか
    public static bool clear;
    

    private GameObject timer;

    private float nowTime;

    private int minuts;
    private int seconds;

    SceneChanger scene;

    void Start()
    {
        startTime = Time.time;
        outTime = 5;
        timer = GameObject.Find("Timer");
        scene = FindObjectOfType<SceneChanger>();
    }

    void Update()
    {
        setTimer();
    }

    void setTimer()
    {
        parseTime += Time.deltaTime;
        nowTime = outTime - parseTime;
        if (nowTime <= 0)
        {
            clear = false;
            scene.toResult();
        }
        mathTime(nowTime);
        timer.GetComponent<Text>().text = "残タイム　" + minuts + ":" + seconds;
    }

    void mathTime(float t)
    {
        if(t < 60)
        {
            minuts = 0;
            seconds = (int)t;
        }
        else
        {
            seconds = (int)t;
            seconds %= 60;
            minuts = ((int)t - seconds) / 60;
        }
    }

    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    public bool getPause()
    {
        return pause;
    }

    public bool setResult(bool c)
    {
        clear = c;
        return clear;
    }

    public bool getResult()
    {
        return clear;
    }
}
