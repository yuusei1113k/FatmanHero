using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

    //ボス
    public GameObject Boss;

    //クリアかゲームオーバーか
    private bool clear;

    //プレイヤーBMI
    private float bmi = 200;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //リザルトシーンへ遷移
    void toResult()
    {
        if (Boss.activeSelf == false)
        {
            clear = true;
            Application.LoadLevel("Result");
        } else if (bmi == 0)
        {
            clear = false;
            Application.LoadLevel("Result");
        }
    }

    public bool getResult()
    {
        return clear;
    }
}
