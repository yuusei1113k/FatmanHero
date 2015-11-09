using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSystems;

public class TouchPoint : MonoBehaviour {

    //タッチパッドの範囲
    private GameObject panel;

    //タッチした場所
    private GameObject touchPad;
    private Vector2 touchPoint;

    //スライドしてる場所
    private GameObject slidePad;
    private Vector2 slidePoint;

    //タッチ制限値
    float minX;
    float maxX;
    float minY;
    float maxY;

    //ポーズ中かどうか
    private bool pause;

    //タッチパッド作成可能領域
    float x;
    float y;

    //コントローラーコンポーネント
    Controller controller;

    //Panel色変更用
    Image panelImage;
    Color panelColor;

    //Buttonコンポーネント
    Buttons button;

    State state = new State();

    void Start () {
        //パネル
        panel = transform.GetChild(0).gameObject;
        touchPad = GameObject.Find("Touch Point");
        slidePad = GameObject.Find("Slice Point");

        //PanelのImageコンポーネント
        panelImage = panel.GetComponent<Image>();
        //Controllerコンポーネント取得
        controller = FindObjectOfType<Controller>();
        button = FindObjectOfType<Buttons>();
        
        //タッチパッド非表示
        touchPad.SetActive(false);
        slidePad.SetActive(false);
    }

    void Update()
    {
        //フリックの状態
        
        //print("TouchPointFlick: " + controller.getFlick());
        if (controller.getFlick() == true)
        {
            print("Flick!");
        }
        else
        {
        }
        //タッチパッド作成可能領域の指定
        if (Input.GetMouseButtonDown(0))
        {
            //60 <= y <= 286
            //2 <= x <= 198
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
        }
        
        //ポーズ中なら作らない
        if ( button.getPushButton() == false && state.getState() == GameState.Playing)
        {
             createPad();
        }
        else
        {
        //    print("PauseNow or PushButtonNow");
        }
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
