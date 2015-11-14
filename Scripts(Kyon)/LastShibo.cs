using UnityEngine;

public class LastShibo : MonoBehaviour
{
    Animator anim;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.1f;
    }


    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(5, 1);
    }
}
