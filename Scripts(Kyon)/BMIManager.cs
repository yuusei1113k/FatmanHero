using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BMIManager : MonoBehaviour {

    //BMIゲージ(slider)
    private Slider BMIguage;

    //BMIゲージ色変更用
    private Image BMIImage;
    /*  緑#06FF83FF
        R = 6
        G = 255
        B = 131
        A = 255
    */
    /*
        黄#FFCD00FF
        R = 255
        G = 206
        B = 0
        A = 255
    */
    /*
        赤#FF0505FF
        R = 255
        G = 6
        B = 6
        A = 255
    */

        //Tゲージ(slider)
    private Slider Tguage;

    //Tゲージレベル
    public GameObject tLevel2;
    public GameObject tLevel3;

    /*
        オレンジ#FFBA05FF
        R = 255
        G = 186
        B = 6
        A = 255
    */

    //BMIゲージ
    private float bmi;

    //Tゲージ
    private int t;

    //TFiP変換スピード調整用
    public int tSpeed = 1;

    //bmiカウンター
    private float bmiCounter = 0;

    //StageManatgerコンポーネント
    StageManager stage;

    //SceneChangerコンポーネント
    SceneChanger scene;

    //他のスクリプトでbmi呼ぶ用
    public float getBMI()
    {
        return bmi;
    }


    void Start () {
        //BMIゲージ(slider)を取得する
        BMIguage = GameObject.Find("BMIguage").GetComponent<Slider>();

        //BMIゲージにあるFill(BMI)を取得する→バーの色を変えるため
        BMIImage = GameObject.Find("Fill(BMI)").GetComponent<Image>();

        //Tゲージ(slider)を取得する
        Tguage = GameObject.Find("Tguage").GetComponent<Slider>();

        //Stageコンポーネント取得
        stage = FindObjectOfType<StageManager>();
        print(stage);
        scene = FindObjectOfType<SceneChanger>();

        //BMIguage初期化
        bmi = 200.0f;

        //Tゲージ初期化
        t = 33;
    }

    void Update () {
        //BMI・Tゲージ監視
        changeBMIguage();
        changeTguage();
	}

    //BMIゲージの色・値変更
    public void changeBMIguage()
    {
        //デバッグ用ゲージ上昇・200で0になる
        
        //bmi -= 1.0f;
        /*
        if (bmi > 200)
        {
            bmi = 0;
        }*/
        

        //色変化
        if (bmi > 150f)
        {
            //print("BMI > 150");
            //BMIImage.color = new Color(6, 255, 131, 255);
            BMIImage.color = Color.green;
        }
        else if (bmi > 18)
        {
            //print("BMI > 18");
            //BMIImage.color = new Color(255, 206, 0, 255);
            BMIImage.color = Color.yellow;
        }
        else if (bmi >= 0f)
        {
            //print("BMI >= 0");
            //BMIImage.color = new Color(255, 6, 6, 255);
            BMIImage.color = Color.red;
        }

        //Valueにbmiをいれる
        BMIguage.value = bmi;

        //BMIが0以下になったら
        if(bmi <= 0)
        {
            stage.setResult(false);
        }
    }

    //Tゲージ
    public void changeTguage()
    {
        //デバッグ用Tゲージ上昇
        /*
        if (Input.GetMouseButton(0))
        {
            t++;
            //print("t: " + t);
        }
        if (Input.GetMouseButtonUp(0))
        {
            t = 33;
        }
        */

        //Tゲージ量によりTレベルの表示非表示
        if(t > 65)
        {
            tLevel2.SetActive(true);
        }
        if(t > 98)
        {
            tLevel2.SetActive(true);
            tLevel3.SetActive(true);
        }
        if(t < 99)
        {
            tLevel3.SetActive(false);
        }
        if ( t < 66)
        {
            tLevel2.SetActive(false);
            tLevel3.SetActive(false);
        }
        Tguage.value = t;
    }

    //T・FiP
    public void tFiP()
    {
        if(t < 99)
        {
            bmiCounter += 1f;
            bmi -= 0.1f;
            print(BMIguage.value);
            print("BMICounter: " + bmiCounter);
            if(bmiCounter % 5f == 0f)
            {
                t += 1;
                //print("T: " + t);
            }
        }
    }

    //スキル
    public void skill()
    {
        if (t > 66)
        {
            bmiCounter = 0;
            t -= 33;
            bmi = 200.0f;
        }

    }
}
