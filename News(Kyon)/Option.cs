using UnityEngine;
using System.Collections;
using StageState;

public class Option : MonoBehaviour {

    private GameObject optionPanel;

    void Start()
    {
        optionPanel = GameObject.Find("OptionPanel");
        print(optionPanel);
    }

    //オプション
    public void openOption()
    {
        State state = new State(GameState.Pausing);
        optionPanel.SetActiveRecursively(true);
        
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
