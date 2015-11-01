using UnityEngine;
using System.Collections;
using GameSystems;

public class Option : MonoBehaviour {

    private GameObject optionPanel;

    State state = new State();

    void Start()
    {
        optionPanel = GameObject.Find("OptionPanel");
        print(optionPanel);
    }

    //オプション
    public void openOption()
    {
        state.setState(GameState.Pausing);
        print(state.getState());
        optionPanel.SetActiveRecursively(true);
        
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
