using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using StageState;

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
    
    //タイマーオブジェクト
    private GameObject timer;

    //現在のタイム
    private float nowTime;
    //テキスト用の分・秒
    private int minuts;
    private int seconds;

    //シーンチェンジャーコンポーネント
    private SceneChanger scene;

    //BMIManagerコンポーネント
    private BMIManager bmiManager;

    //リザルトテロップコンポーネント
    private GameObject resultTelop;

    void Start()
    {
        
        startTime = Time.time;
        outTime = 5;
        timer = GameObject.Find("Timer");
        scene = FindObjectOfType<SceneChanger>();
        resultTelop = GameObject.Find("ResultTelop");
        bmiManager = FindObjectOfType<BMIManager>();

    }

    void Update()
    {
        setTimer();
        resultManager(clear);
    }

    //リザルト管理
    void resultManager(bool c)
    {
        if (clear == c)
        {
            resultTelop.GetComponent<Text>().text = "ステージクリア！！";
            scene.toResult();
        }
        else if(clear == c)
        {
            resultTelop.GetComponent<Text>().text = "ゲームオーバー";
            scene.toResult();
        }
        else
        {
            //何もしない
        }
    }

    //タイマー書き換え
    void setTimer()
    {
        parseTime += Time.deltaTime;
        nowTime = outTime - parseTime;
        if (nowTime <= 0)
        {
            clear = false;
        }
        mathTime(nowTime);
        timer.GetComponent<Text>().text = "残タイム　" + minuts + ":" + seconds;
    }

    //タイマー計算
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

    //ポーズ中かどうか変更する
    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    //他で呼ぶ用ポーズ中かどうか取得
    public bool getPause()
    {
        return pause;
    }

    //リザルトを変更する
    public bool setResult(bool c)
    {
        clear = c;
        return clear;
    }

    //他で呼ぶ用リザルト
    public bool getResult()
    {
        return clear;
    }

    //リザルト画面に遷移する前にステージシーンでテロップを出す
    IEnumerator telop()
    {
        resultTelop.SetActiveRecursively(true);
        yield return new WaitForSeconds(3.0f);
        resultTelop.SetActive(false);
        yield break;
    }
}
