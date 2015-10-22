using UnityEngine;
using System.Collections;

public class TouchPoint : MonoBehaviour {

    //タッチした場所
    public GameObject touchPad;
    private Vector2 touchPoint;

    //スライドしてる場所
    public GameObject slidePad;
    private Vector2 slidPoint;


    // Use this for initialization
    void Start () {
        //タッチパッド非表示
        touchPad.SetActive(false);
        slidePad.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        createPad();
	}

    public void createPad()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タッチ地点の取得
            touchPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //タッチパッドをタッチ地点に移動
            touchPad.transform.position = touchPoint;

            //タッチパッド表示
            touchPad.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            //タッチ地点の取得
            slidPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //タッチパッドをタッチ地点に移動
            slidePad.transform.position = slidPoint;

            //タッチパッド表示
            slidePad.SetActive(true);

        }

        if (Input.GetMouseButtonUp(0))
        {
            touchPad.SetActive(false);
            slidePad.SetActive(false);
        }
    } 
}
