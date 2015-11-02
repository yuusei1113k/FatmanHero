using UnityEngine;
using System.Collections;
using GameSystems;

public class Title : MonoBehaviour {

    ScenChanger sc = new ScenChanger();
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TapToStart());
        }
    }

    IEnumerator TapToStart()
    {
        audio.Play();
        yield return new WaitForSeconds(2.0f);
        sc.toStageSelect();
    }
}
