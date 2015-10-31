using UnityEngine;
using System.Collections;
using GameSystems;

public class StageSelect : MonoBehaviour {
    
    State state = new State();

    ScenChanger sc = new ScenChanger();


    //タイトル画面へ
    public void toTitle()
    {
        state.setState(GameState.NotPlaying);
        Application.LoadLevel("Title");
    }

    //ステージセレクト画面へ
    public void toStageSelect()
    {
        state.setState(GameState.NotPlaying);
        Application.LoadLevel("StageSelect");
    }

    //ステージ1ボタン
    public void stage01()
    {
        sc.setStage(StageName.Stage1);
        Application.LoadLevel("LoadScene");

    }

    //ステージ2ボタン
    public void stage02()
    {
        sc.setStage(StageName.Stage2);
        Application.LoadLevel("LoadScene");

    }

    //ステージ3ボタン
    public void stage03()
    {
        sc.setStage(StageName.Stage3);
        Application.LoadLevel("LoadScene");
    }

    //リザルトへ
    public void toResult()
    {
        Application.LoadLevel("Result");
    }

}