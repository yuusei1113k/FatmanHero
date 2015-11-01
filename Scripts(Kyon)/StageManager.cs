using UnityEngine;
using System.Collections;
using GameSystems;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

    //残タイム
    int outTime;

    //開始時間
    float startTime;

    //経過時間
    float parseTime;

    //現在のタイム
    private float nowTime;
    //テキスト用の分・秒
    private int minuts;
    private int seconds;

    //タイマーオブジェクト
    private GameObject timer;

    //ゲームの状態
    State state = new State();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //エネミー格納
    public GameObject enemys;

    //ボス格納
    public GameObject boss;

    //リザルトテロップ
    private GameObject resultTelop;

    //音
    public AudioClip[] audioSorce;
    private AudioSource audio;

    void Start()
    {
        //タイマー関係
        startTime = Time.time;
        outTime = 60;
        timer = GameObject.Find("Timer");

        //ゲームステート
        state.setState(GameState.Playing);

        //テロップ
        resultTelop = GameObject.Find("ResultTelop");
        resultTelop.SetActive(false);

        //音
        audio = GetComponent<AudioSource>();

        state.setState(GameState.Playing);
    }

    void Update()
    {
        //タイマー
        setTimer();

        //スポナー
        Sporner();
    }
    
    void Sporner()
    {
        if(enemys.activeSelf == false)
        {
            audio.clip = audioSorce[0];
            audio.Stop();
            audio.Play();
        }        
        //ボスを倒したかどうか
        if (boss.activeSelf == false)
        {
            print("joge");
            setResult(true);
            StartCoroutine(telop());
        }

    }

    //タイマー書き換え
    void setTimer()
    {
        parseTime += Time.deltaTime;
        nowTime = outTime - parseTime;
        if (nowTime <= 0)
        {
            setResult(false);
            StartCoroutine(telop());
        }
        mathTime(nowTime);
        timer.GetComponent<Text>().text = "残タイム　" + minuts + ":" + seconds;
    }

    //タイマー計算
    void mathTime(float t)
    {
        if (t < 60)
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

    //ポーズ状態の遷移
    public void setPause(bool p)
    {
        if(p == false)
        {
            //ポーズ中にする
            state.setState(GameState.Pausing);
        }
        else
        {
            //プレイ中にする
            state.setState(GameState.Playing);
        }
    }

    //リザルト状態の遷移
    public void setResult(bool c)
    {
        if(c == true)
        {
            //クリア
            audio.clip = audioSorce[1];
            state.setState(GameState.StageClear);
            resultTelop.GetComponent<Text>().text = "ステージクリア";
        }
        else
        {
            //ゲームオーバー
            audio.clip = audioSorce[2];
            state.setState(GameState.GameOver);
            resultTelop.GetComponent<Text>().text = "ゲームオーバー";
        }
    }

    IEnumerator telop()
    {
        audio.loop = false;
        audio.PlayOneShot(audioSorce[0]);
        resultTelop.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        resultTelop.SetActive(false);
        sc.toResult();
    }
}
