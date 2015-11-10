using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private BMIManager bmiManager;

    // Use this for initialization
    void Start()
    {
        bmiManager = GameObject.Find("BMIManager").GetComponent<BMIManager>();
    }


    // Update is called once per frame
    void Update()
    {

        // 現在角度 + (new Vector3(15,30,45) * Time.deltaTime) を適用する
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }


    //アイテムを取った際のメソッド
    void OnTriggerEnter(Collider c)
    {
        BoxCollider b = c.gameObject.GetComponent<BoxCollider>();
        if (c.gameObject.tag == "Player" && b == c)
        {
            bmiManager.BMIUP(int.Parse(name));
            Destroy(gameObject);
        }
    }
}