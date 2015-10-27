using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class touchTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchSupported)
        {
            print("hoge");
        }
    }

    public void button1()
    {
        print("1");
    }
    public void button2()
    {
        print("2");
    }
}
