using UnityEngine;
using System.Collections;
using GameSystems;

public class StageManager : MonoBehaviour {

    State state = new State();

    void Start()
    {
        state.setState(GameState.Playing);
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
