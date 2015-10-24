using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    private bool pause = false;

    private GameObject modal;

    private bool tfip;

    BMIManager bmiManager;

    void Start()
    {
        modal = GameObject.Find("Modal");
        print(modal);
        modal.SetActive(false);
        bmiManager = FindObjectOfType<BMIManager>();
        tfip = false;
        pause = false;
    }

    public void pushPause()
    {
        print("Push");
        if(pause == false)
        {
            Time.timeScale = 0f;
            print("timeScale = 0");
            pause = true;
            modal.SetActiveRecursively(true);
        }
        else
        {
            modal.SetActive(false);
            pause = false;
        }
    }
    
    public void startTFiP()
    {
        if (tfip == false)
        {
            tfip = true;
        }
        else
        {
            tfip = false;
        }
    }

    public void useSkill()
    {
        bmiManager.skill();
    }

    void Update()
    {
        if(tfip == true)
        {
            bmiManager.tFiP();
        }
    }
}
