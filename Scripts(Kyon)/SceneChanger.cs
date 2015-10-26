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

    public void stage01()
    {
        stageName = "Stage1";
    }
    public void stage02()
    {
        stageName = "Stage2";
    }
    public void stage03()
    {
        stageName = "Stage3";
    }


    //ステージ1へ
    public string toLoading()
    {
        return stageName;
    }

}