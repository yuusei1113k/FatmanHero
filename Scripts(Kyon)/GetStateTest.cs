using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetStateTest : MonoBehaviour {

    Animator anim;

    Text ActionText;

    int[] state = new int[4];

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        ActionText = GameObject.Find("Action").GetComponent<Text>();
        state[0] = 17588480;
        state[1] = 1284765916;
        state[2] = -711284378;
        state[3] = -355276023;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(0, 0, 0);
        //print(anim.GetCurrentAnimatorStateInfo(0).fullPathHash);
        if (Input.GetKeyDown("s"))
        {
            foreach(var val in state)
            {
                print(val);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
        action();
    }

    void action()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == state[0])
        {
            ActionText.text = "State is Stanby";
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == state[1])
        {
            ActionText.text = "State is Jab1";
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == state[2])
        {
            ActionText.text = "State is Jab2";
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == state[3])
        {
            ActionText.text = "State is Smash";
        }
        else
        {
            ActionText.text = "hoge";
        }
    }
}
