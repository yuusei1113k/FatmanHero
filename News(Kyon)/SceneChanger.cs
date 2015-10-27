using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    private GameObject Stage01;

    private string stageName;

    //タイトル画面へ
    public void toTitle()
    {
        Application.LoadLevel("Title");
    }

    //ステージセレクト画面へ
    public void toStageSelect()
    {
        Application.LoadLevel("StageSelect");
    }

    //ステージ1ボタン
    public void stage01()
    {
        stageName = "Stage1";
        Application.LoadLevel("Stage1");

    }

    //ステージ2ボタン
    public void stage02()
    {
        stageName = "Stage2";
        Application.LoadLevel("Loading");

    }

    //ステージ3ボタン
    public void stage03()
    {
        stageName = "Stage3";
        Application.LoadLevel("Loading");
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