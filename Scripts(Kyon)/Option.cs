using UnityEngine;
using System.Collections;

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
        optionPanel.SetActiveRecursively(true);
    }

    //オプション閉じる
    public void closeOption()
    {
        optionPanel.SetActive(false);
    }
}
