using UnityEngine;
using System.Collections;
using GameSystems;

public class StageManager : MonoBehaviour {

    //ゲームの状態
    State state = new State();

    ScenChanger sc = new ScenChanger();

    public GameObject[] enemys;

    public GameObject boss;

    void Start()
    {
        state.setState(GameState.Playing);
    }

    void Update()
    {
        if(boss.activeSelf == false)
        {
            setResult(false);
            sc.toResult();
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
            state.setState(GameState.StageClear);
        }
        else
        {
            //ゲームオーバー
            state.setState(GameState.GameOver);
        }
    }
}
