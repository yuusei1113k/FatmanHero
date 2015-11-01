using UnityEngine;
using System.Collections;
using GameSystems;

public class Title : MonoBehaviour {

    ScenChanger sc = new ScenChanger();

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sc.toStageSelect();
        }
    }
}
