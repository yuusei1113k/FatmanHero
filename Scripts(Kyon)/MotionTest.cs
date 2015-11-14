using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotionTest : MonoBehaviour {

    Animator anim;
    private Text text;

    private GameObject shibo;
    private GameObject enemy;
    private GameObject boss;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        text = GameObject.Find("MainCanvas/Text").GetComponent<Text>();
        shibo = GameObject.Find("Create");
        enemy = GameObject.Find("WakkiTest");
        boss = GameObject.Find("BossTest");
	}
	
    int i = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("l"))
        {
            for(int i = 0; i < 5; i++)
            {
                anim.SetLayerWeight(i, 0);
            }
            shibo.SetActive(true);
            enemy.SetActive(false);
            boss.SetActive(false);
            anim.SetLayerWeight(4, 1);
            print("Layer is List");
            text.text = "Now Layer: List";
        }
        if (Input.GetKeyDown("p"))
        {
            for (int i = 0; i < 5; i++)
            {
                anim.SetLayerWeight(i, 0);
            }
            shibo.SetActive(true);
            enemy.SetActive(false);
            boss.SetActive(false);
            anim.SetLayerWeight(0, 1);
            print("Layer is Shibokun");
            text.text = "Now Layer: Shibokun";
        }
        if (Input.GetKeyDown("b"))
        {
            for (int i = 0; i < 5; i++)
            {
                anim.SetLayerWeight(i, 0);
            }
            boss.SetActive(true);
            shibo.SetActive(false);
            enemy.SetActive(false);
            anim.SetLayerWeight(2, 1);
            print("Layer is Boss");
            text.text = "Now Layer: Boss";
        }
        if (Input.GetKeyDown("e"))
        {
            for (int i = 0; i < 5; i++)
            {
                anim.SetLayerWeight(i, 0);
            }
            enemy.SetActive(true);
            shibo.SetActive(false);
            boss.SetActive(false);
            anim.SetLayerWeight(1, 1);
            print("Layer is Enemy");
            text.text = "Now Layer: Boss";
        }

        if (anim.GetLayerWeight(4) == 1)
        {
            text.text = "Now Layer: List\nEnter: Next\n1: Stay\n2: Attack\n3: Skill";
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
            if (anim.GetLayerWeight(0) == 1)
            {
                text.text = "Now Layer: Shibokun\nA: Attack\nM: Move\nW: Flick\nT: TFiP\n1: SkillSonic\n2: SkillRush\n3:  SkillHavoc\nEnter: OffSkill";
            }
            else if (anim.GetLayerWeight(2) == 1)
            {
                text.text = "Now Layer: Boss\nM: Move\nA: Attack\nS: Skill";
            }
            else if (anim.GetLayerWeight(1) == 1)
            {
                text.text = "Now Layer:Enemy\nM: Move\nA: Attack";
            }


            if (Input.GetKeyDown("a"))
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
            if (Input.GetKeyDown("s"))
            {
                anim.SetTrigger("Skill");
            }
        }

    }
}
