using UnityEngine;
using System.Collections;

public class TouchPoint : MonoBehaviour {

    //タッチパッドの範囲
    public GameObject panel;

    //タッチした場所
    public GameObject touchPad;
    private Vector2 touchPoint;

    //スライドしてる場所
    public GameObject slidePad;
    private Vector2 slidePoint;

    //タッチ制限値
    float minX;
    float maxX;
    float minY;
    float maxY;



    void Start () {
        //タッチパッド非表示
        touchPad.SetActive(false);
        slidePad.SetActive(false);
	}
	
	void Update () {
        createPad();
	}

    //タッチした場所としている場所にイメージを張る
    public void createPad()
    {
        //タッチした場所
        if (Input.GetMouseButtonDown(0))
        {
            //タッチ地点の取得
            touchPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //slidePointの制限
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            minX = x - 60f;
            maxX = x + 60f;
            minY = y - 60f;
            maxY = y + 60f;


            //タッチパッドをタッチ地点に移動
            panel.transform.position = touchPoint;
            touchPad.transform.position = touchPoint;

            //タッチパッド表示
            panel.SetActive(true);
            touchPad.SetActive(true);
        }

        //タッチしてる場所
        if (Input.GetMouseButton(0))
        {
            //タッチ地点の取得
            slidePoint = new Vector2(Mathf.Clamp(Input.mousePosition.x, minX, maxX), Mathf.Clamp(Input.mousePosition.y, minY, maxY));

            //タッチパッドをタッチ地点に移動
            slidePad.transform.position = slidePoint;

            //タッチパッド表示
            slidePad.SetActive(true);

        }

        //イメージを非表示
        if (Input.GetMouseButtonUp(0))
        {
            panel.SetActive(false);
            touchPad.SetActive(false);
            slidePad.SetActive(false);
        }
    } 
}
