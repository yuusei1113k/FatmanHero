using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSystems;

public class Option : MonoBehaviour {

    private GameObject optionPanel;

    State state = new State();

    ClearedStage cs = new ClearedStage();

    void Start()
    {
        optionPanel = GameObject.Find("OptionPanel");
        optionPanel.SetActive(false);
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
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
