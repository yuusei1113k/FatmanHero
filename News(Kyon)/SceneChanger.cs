using UnityEngine;
using System.Collections;
using StageState;

public class SceneChanger : MonoBehaviour {

    private string stageName;

    //タイトル画面へ
    public void toTitle()
    {
        State state = new State(GameState.NotPlaying);
        Application.LoadLevel("Title");
    }

    //ステージセレクト画面へ
    public void toStageSelect()
    {
        State state = new State(GameState.NotPlaying);
        Application.LoadLevel("StageSelect");
    }

    //ステージ1ボタン
    public void stage01()
    {
        stageName = "Stage1";
        Application.LoadLevel("LoadScene");

    }

    //ステージ2ボタン
    public void stage02()
    {
        stageName = "Stage2";
        Application.LoadLevel("LoadScene");

    }

    //ステージ3ボタン
    public void stage03()
    {
        stageName = "Stage3";
        Application.LoadLevel("LoadScene");
    }


    //ステージ
    public string toLoading()
    {
        return stageName;
    }

    //リザルトへ
    public void toResult()
    {
        Application.LoadLevel("Result");
    }

}