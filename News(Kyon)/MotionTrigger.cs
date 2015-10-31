using UnityEngine;
using System.Collections;

public class MotionTrigger : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    public void pushAttack()
    {
        anim.SetBool("Move", false);
        anim.SetTrigger("Attack");
    }

    public void pushMove()
    {
        anim.SetBool("Move", true);
        anim.SetTrigger("Move");
    }
}
