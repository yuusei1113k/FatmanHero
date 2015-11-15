using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using System;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    private GameObject optionPanel;

    private GameObject deletePanel;

    private GameObject howToPlayPanel;

    private GameObject howToPlay;

    Text howToText;

    private GameObject scPanel;

    private GameObject staffCredit;

    Text creditContent;

    private float creditPos = 0;

    State state = new State();

    ClearedStage cs = new ClearedStage();

    StageSelect ss;

    void Start()
    {
        optionPanel = GameObject.Find("OptionPanel");
        deletePanel = GameObject.Find("DeletePanel");
        howToPlayPanel = GameObject.Find("HowToPlayPanel");
        howToPlay = GameObject.Find("HowToPlay");
        howToText = howToPlay.transform.GetChild(1).GetComponent<Text>();
        scPanel = GameObject.Find("StaffCreditPanel");
        staffCredit = GameObject.Find("StaffCredit");
        creditContent = staffCredit.transform.GetChild(0).GetComponent<Text>();
        optionPanel.SetActive(false);
        deletePanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        scPanel.SetActive(false);
        try
        {
            ss = GameObject.Find("StageSelect").GetComponent<StageSelect>();
        }catch(Exception e)
        {
            print("Option. Find(StageSeledt): " + e);
        }
    }

    //オプションボタン
    public void openOption()
    {
        state.setState(GameState.Pausing);
        print(state.getState());
        optionPanel.SetActive(true);
    }

    //操作説明ボタン
    public void openHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }
    
    //戻るボタン
    public void preHowTo()
    {
        howToText.text = "戻った";
    }

    //進むボタン
    public void nextHowTo()
    {
        howToText.text = "進んだ";
    }

    //閉じるボタン
    public void closeHowTo()
    {
        howToPlayPanel.SetActive(false);
    }

    //クレジットボタン
    public void openCredit()
    {
        scPanel.SetActive(true);
    }
    IEnumerator scrollCredit()
    {
        while (creditPos < 500)
        {
            creditContent.transform.Translate(creditContent.transform.up * Time.deltaTime);
            creditPos = creditContent.rectTransform.position.y;
        }
        yield break;
    }

    //閉じるボタン
    public void closeCredit()
    {
        scPanel.SetActive(false);
    }

    //クリア情報初期化
    public void clearData()
    {
        cs.clearData();
        cs.getCleared();
        foreach(var val in cs.getClearedStages())
        {
            print(val);
        }
        StartCoroutine(deleteInfo());
        ss.stageButton();
    }
    IEnumerator deleteInfo()
    {
        deletePanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        deletePanel.SetActive(false);
        yield break;
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
