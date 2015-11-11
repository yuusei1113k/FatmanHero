using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using System.Linq;
using System;

public class StageSelect : MonoBehaviour {
    
    //ゲームステート
    State state = new State();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //クリア情報
    ClearedStage cs = new ClearedStage();

    //オーディオ
    AudioSource audio;

    //Stageボタン
    private GameObject stage2;
    private GameObject stage3;
    DebugSystem ds = new DebugSystem();

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.5f;
        cs.getCleared();
        try
        {
            stageButton();
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    void stageButton()
    {
        stage2 = GameObject.Find("Stage2");
        stage3 = GameObject.Find("Stage3");
        stage2.SetActive(false);
        stage3.SetActive(false);
        if (cs.getClearedStages()[StageName.Stage1] == 1)
        {
            try
            {
                stage2.SetActive(true);
            }
            catch (Exception e)
            {
                print(e);
            }
        }
        if (cs.getClearedStages()[StageName.Stage1] == 1 && cs.getClearedStages()[StageName.Stage2] == 1)
        {
            try
            {
                stage3.SetActive(true);
            }
            catch (Exception e)
            {
                print(e);
            }
        }

    }

    void OnGUI()
    {
        ds.OnGUI();
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
        yield return new WaitForSeconds(1.0f);
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
        yield return new WaitForSeconds(1.0f);
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
        yield return new WaitForSeconds(1.0f);
        sc.toLoading();
        yield break;
    }

    //ステージ2ボタン
    public void stage02()
    {
        if (cs.getClearedStages()[StageName.Stage1] == 1)
        {
            sc.setStage(StageName.Stage2);
            StartCoroutine(loadingCoroutine());
        }
    }

    //ステージ3ボタン
    public void stage03()
    {
        if (cs.getClearedStages()[StageName.Stage1] == 1 && cs.getClearedStages()[StageName.Stage2] == 1)
        {
            sc.setStage(StageName.Stage3);
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
        cs.getCleared();
        foreach(var val in cs.getClearedStages())
        {
            print(val);
        }
        print("初期化");
        stageButton();
    }


}