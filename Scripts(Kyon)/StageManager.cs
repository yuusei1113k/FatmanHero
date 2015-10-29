using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

    //ポーズ中かどうか
    private bool pause;

    //クリアかゲームオーバーか
    public static bool clear;

    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    public bool getPause()
    {
        return pause;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public bool setResult(bool c)
    {
        clear = c;
        return clear;
    }

    public bool getResult()
    {
        print(clear);
        return clear;
    }
}
