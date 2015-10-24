using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

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


    //ステージ1へ
    public void toStage1()
    {
        Application.LoadLevel("main");
    }
}