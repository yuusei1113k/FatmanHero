using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public EnemyA enemy;

    private BMIManager bmiManager;

    private GameObject parentEnemy;

    // Use this for initialization
    void Start()
    {
        bmiManager = GameObject.Find("BMIManager").GetComponent<BMIManager>();

        parentEnemy = GameObject.Find("Enemy");
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
        if (c.gameObject.tag == "Player")
        {
            bmiManager.BMIUP(int.Parse(name));
            Destroy(gameObject);
            Debug.Log("アイテムとりましたぁぁぁぁん");
        }
    }
}