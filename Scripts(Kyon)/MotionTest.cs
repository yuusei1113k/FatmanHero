using UnityEngine;
using System.Collections;

public class MotionTest : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    int i = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("l"))
        {
            anim.SetLayerWeight(3, 1);
            print("Layer is List");
        }
        if (Input.GetKeyDown("s"))
        {
            anim.SetLayerWeight(3, 0);
            print("Layer is Shibokun");
        }

        if(anim.GetLayerWeight(3) == 1)
        {
            if (Input.GetKeyDown("enter"))
            {
                anim.SetTrigger("Next");
            }

            if (Input.GetKeyDown("1"))
            {
                anim.SetTrigger("Stay");
            }

            if (Input.GetKeyDown("2"))
            {
                anim.SetTrigger("Attack");
            }
            if (Input.GetKeyDown("3"))
            {
                anim.SetTrigger("Skill");
            }
        }
        else
        {
            if (Input.GetKeyDown("z"))
            {
                anim.SetTrigger("Attack");
            }
            if (Input.GetKey("m"))
            {
                anim.SetBool("Move", true);
            }else if (Input.GetKeyUp("m"))
            {
                anim.SetBool("Move", false);
            }
            if (Input.GetKeyDown("w"))
            {
                anim.SetTrigger("Flick");
            }
            if (Input.GetKey("t"))
            {
                anim.SetBool("TFiP", true);
            }else if (Input.GetKeyUp("t"))
            {
                anim.SetBool("TFiP", false);
            }
            if (Input.GetKeyDown("1"))
            {
                anim.SetTrigger("SkillSonic");
            }
            if (Input.GetKey("2"))
            {
                anim.SetTrigger("SkillRush");
            }
            if (Input.GetKeyDown("3"))
            {
                anim.SetTrigger("SkillHavoc");
            }
            if (Input.GetKeyDown("enter"))
            {
                anim.SetTrigger("OffSkill");
            }
        }

    }
}
