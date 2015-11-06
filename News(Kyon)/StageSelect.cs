using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using System.Linq;

public class StageSelect : MonoBehaviour {
    
    //ゲームステート
    State state = new State();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //クリア情報
    ClearedStage cs = new ClearedStage();

    //オーディオ
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.5f;
        cs.getClearedStages();
        foreach (var val in cs.getClearedStages())
        {
            print(val);
        }

    }


    //タイトルボタン
    public void toTitle()
    {
        state.setState(GameState.NotPlaying);
        StartCoroutine(titleCoroutine());
    }
    IEnumerator titleCoroutine()
    {
        audio.Play();
        yield return new WaitForSeconds(2.0f);
        sc.toTitle();
        yield break;
    }

    //ステージセレクトボタン
    public void toStageSelect()
    {
        state.setState(GameState.NotPlaying);
        StartCoroutine(stageSelectCoroutine());
    }
    IEnumerator stageSelectCoroutine()
    {
        audio.Play();
        yield return new WaitForSeconds(2.0f);
        sc.toStageSelect();
        yield break;
    }

    //ステージ1ボタン
    public void stage01()
    {
        sc.setStage(StageName.Stage1);
        StartCoroutine(loadingCoroutine());
    }
    IEnumerator loadingCoroutine()
    {
        audio.Play();
        yield return new WaitForSeconds(2.0f);
        sc.toLoading();
        yield break;
    }

    //ステージ2ボタン
    public void stage02()
    {
        sc.setStage(StageName.Stage2);
        if (cs.getClearedStages()[StageName.Stage1] == 1)
        {
            StartCoroutine(loadingCoroutine());
        }
    }

    //ステージ3ボタン
    public void stage03()
    {
        sc.setStage(StageName.Stage3);
        if (cs.getClearedStages()[StageName.Stage1] == 1 && cs.getClearedStages()[StageName.Stage2] == 1)
        {
            StartCoroutine(loadingCoroutine());
        }
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
            default:
                break;
        }
        StartCoroutine(loadingCoroutine());
    }

    //リトライボタン
    public void retry()
    {
        StartCoroutine(loadingCoroutine());
    }

    //初期化ボタン
    public void clearData()
    {
        PlayerPrefs.DeleteAll();
        print("初期化");
    }


}