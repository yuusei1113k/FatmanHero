using UnityEngine;
using System.Collections;

public class JudgePunch : MonoBehaviour {

    //波動オブジェクト
    private GameObject hado;

	// Use this for initialization
	void Start () {
        hado = GameObject.Find("Hado");
	}

    //ジャブかスマッシュか判定して波動の攻撃力を決める
    void OnTriggerEnter(Collider c)
    {
        hado.tag = c.tag;
    }
}
