using UnityEngine;
using System.Collections;
using GameSystems;

public class Option : MonoBehaviour {

    public GameObject optionPanel;

    State state = new State();

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
        //optionPanel.SetActiveRecursively(true);

    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
