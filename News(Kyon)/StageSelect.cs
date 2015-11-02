using UnityEngine;
using System.Collections;
using GameSystems;

public class StageSelect : MonoBehaviour {
    
    State state = new State();

    ScenChanger sc = new ScenChanger();

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    //タイトルボタン
    public void toTitle()
    {
        state.setState(GameState.NotPlaying);
        sc.toTitle();
    }

    //ステージセレクトボタン
    public void toStageSelect()
    {
        state.setState(GameState.NotPlaying);
        sc.toStageSelect();
    }

    //ステージ1ボタン
    public void stage01()
    {
        sc.setStage(StageName.Stage1);
        sc.toLoading();
    }

    //ステージ2ボタン
    public void stage02()
    {
        sc.setStage(StageName.Stage2);
        sc.toLoading();

    }

    //ステージ3ボタン
    public void stage03()
    {
        sc.setStage(StageName.Stage3);
        sc.toLoading();
    }

    //次のステージボタン
    public void nextStage()
    {
        StageName current = sc.getStageName();
        switch (current)
        {
            case StageName.Stage1:
                sc.setStage(StageName.Stage2);
                break;
            case StageName.Stage2:
                sc.setStage(StageName.Stage3);
                break;
        }
        sc.toLoading();
    }

    //リトライボタン
    public void retry()
    {
        sc.toLoading();
    }

}