using UnityEngine;
using System.Collections;

public class JudgePunch : MonoBehaviour {

    //波動オブジェクト
    public GameObject hado;

    //ジャブかスマッシュか判定して波動の攻撃力を決める
    void OnTriggerEnter(Collider c)
    {
        print("Judge: " + c.tag);
        if(c.tag == "Jab" || c.tag == "Smash")
        {
            hado.tag = c.tag;
        }
    }
}
