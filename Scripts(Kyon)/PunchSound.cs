using UnityEngine;
using System.Collections;

public class PunchSound : StateMachineBehaviour
{
    public AudioClip swing;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        AudioSource.PlayClipAtPoint(swing, animator.gameObject.transform.position);
    }
}
