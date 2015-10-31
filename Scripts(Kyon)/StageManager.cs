using UnityEngine;
using System.Collections;
<<<<<<< HEAD
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
=======

public class StageManager : MonoBehaviour {

    //ポーズ中かどうか
    private bool pause;

    //クリアかゲームオーバーか
    public static bool clear;

    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    public bool getPause()
    {
        return pause;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public bool setResult(bool c)
    {
        clear = c;
        return clear;
    }

    public bool getResult()
    {
        print(clear);
        return clear;
>>>>>>> 7da40c605093b1e8154f0c4ae6ad25b999042b2f
    }
}
