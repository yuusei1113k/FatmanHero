using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        c.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider c)
    {
        c.gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
