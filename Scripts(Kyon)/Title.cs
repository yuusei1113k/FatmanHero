using UnityEngine;
using System.Collections;
using GameSystems;

public class Title : MonoBehaviour {

    ScenChanger sc = new ScenChanger();
    AudioSource audio;

    void Start()
    {
<<<<<<< HEAD
        i = 0;
=======
>>>>>>> dca2acb682ec438d08fb2d2ac7efe153879fce2b
        audio = GetComponent<AudioSource>();
    }

    private int i = 0;
    void OnGUI()
    {
        if(i < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(TapToStart());
                i++;
            }
        }
    }

    IEnumerator TapToStart()
    {
        audio.Play();
        yield return new WaitForSeconds(2.0f);
        sc.toStageSelect();
    }
}
