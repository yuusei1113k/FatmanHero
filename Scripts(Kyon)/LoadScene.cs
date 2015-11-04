using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSystems;
using System;

public class LoadScene : MonoBehaviour
{

    private AsyncOperation async;

    private GameObject parent;

    private Slider lodingBar;

    private Text loadingText;

    private Text startText;

    string stageName;

    float i = 0;

    ScenChanger sc = new ScenChanger();

    State state = new State();

    void Start()
    {
        parent = transform.root.gameObject;

        lodingBar = GameObject.Find("LoadingBar").GetComponent<Slider>();
        loadingText = GameObject.Find("LoadingText").GetComponent<Text>();
        startText = GameObject.Find("StartText").GetComponent<Text>();
        print("Stage: " + sc.getStageName());


        StartCoroutine(Load());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Load()
    {


        Debug.Log("コルーチン内処理" + parent);

        //ステージ名はStage01～
        try
        {
            stageName = sc.getStageName().ToString();

            print("stageName: " + stageName);


            // 非同期でロード開始
            async = Application.LoadLevelAsync(stageName.ToString());
            // デフォルトはtrue。ロード完了したら勝手にシーンきりかえ発生しないよう設定。
            async.allowSceneActivation = false;
        }
        catch (Exception)
        {
            Application.LoadLevelAsync("StageSelect");
            yield break;
        }

        // 非同期読み込み中の処理

        while (async.progress < 0.9f)
        {
            //while(i < 0.9f){

            loadingText.text = "NowLoading..." + (async.progress * 100).ToString("F0") + "%";
            Debug.Log("ローディングパーセント" + async.progress * 100);
            lodingBar.value = async.progress;
            yield return new WaitForEndOfFrame();

        }
        lodingBar.value = 0.9f;
        loadingText.text = "NowLoading...100%";

        yield return async;

    }



    void swichLoad()
    {
        startText.text = "TAP to START";
        if (Input.GetMouseButtonDown(0))
        {
            // タッチしたら遷移する（検証用）
            Debug.Log("タッチ取得");
            async.allowSceneActivation = true;
        }
    }

    void OnGUI()
    {
        if (loadingText.text == "NowLoading...100%")
        {
            swichLoad();
        }
    }

}