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
        audio.volume = 0.5f;
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
        StartCoroutine(loadingCoroutine());
    }

    //ステージ3ボタン
    public void stage03()
    {
        sc.setStage(StageName.Stage3);
        StartCoroutine(loadingCoroutine());
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


}