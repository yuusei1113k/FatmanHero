using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

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
<<<<<<< HEAD
<<<<<<< HEAD
        Application.LoadLevel("LoadScene");
=======
        Application.LoadLevel("Stage1");
>>>>>>> remotes/origin/kyon
=======
        Application.LoadLevel("LoadScene");
>>>>>>> remotes/origin/kyon

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