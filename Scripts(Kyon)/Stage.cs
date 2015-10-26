using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

    //ボス
    public GameObject Boss;

    //クリアかゲームオーバーか
    private bool clear;

    //プレイヤーBMI
    private float bmi;

    //BMIManagerコンポーネント
    private BMIManager bmiManager;

	// Use this for initialization
	void Start () {
        bmiManager = GetComponent<BMIManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bmi = bmiManager.getBMI();
        toResult();
	}

    //リザルトシーンへ遷移
    void toResult()
    {
        //ボスを倒したら
        if (Boss.activeSelf == false)
        {
            clear = true;
            Application.LoadLevel("Result");
        }

        //BMIが0になったら
        if (bmi <= 0)
        {
            clear = false;
            Application.LoadLevel("Result");
        }
        else { }
    }

    public bool getResult()
    {
        return clear;
    }
}
