using UnityEngine;
using System.Collections;

public class JudgePunch : MonoBehaviour {

    //波動オブジェクト
    private GameObject hado;

    void Start()
    {
        hado = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject;
    }

    //ジャブかスマッシュか判定して波動の攻撃力を決める
    void OnTriggerEnter(Collider c)
    {
        //print("Trigger Judge: " + c.name);
        if (c.tag == "Jab" || c.tag == "Smash")
        {
            hado.tag = c.tag;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        print("Collistion Judge: " + c.gameObject.name);
        if (c.gameObject.tag == "Jab" || c.gameObject.tag == "Smash")
        {
            hado.tag = c.gameObject.tag;
        }
    }
}
