using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSystems;
using System;

public class Option : MonoBehaviour {

    private GameObject optionPanel;

    State state = new State();

    ClearedStage cs = new ClearedStage();

    StageSelect ss;

    void Start()
    {
        optionPanel = GameObject.Find("OptionPanel");
        optionPanel.SetActive(false);
        try
        {
            ss = GameObject.Find("StageSelect").GetComponent<StageSelect>();
        }catch(Exception e)
        {
            print(e);
        }
    }

    //オプション
    public void openOption()
    {
        state.setState(GameState.Pausing);
        print(state.getState());
        optionPanel.SetActive(true);
    }

    public void clearData()
    {
        cs.clearData();
        cs.getCleared();
        foreach(var val in cs.getClearedStages())
        {
            print(val);
        }
        ss.stageButton();
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
