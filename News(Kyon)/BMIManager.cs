using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSystems;

public class BMIManager : MonoBehaviour {

    //BMIを減らすスピードを変える
    public float bmiDecrement = 1f;

    //T・FiPを増やすスピードを変える
    public float tIncrement = 1f;


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
    private float t;

    //bmiカウンター
    private float bmiCounter = 0;

    //StageManatgerコンポーネント
    StageManager stage;

    //StageSelectコンポーネント
    ScenChanger sc = new ScenChanger();

    public AudioClip[] audioSorce;
    private AudioSource audio;

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
        //print(stage);

        //BMIguage初期化
        bmi = 200.0f;

        //Tゲージ初期化
        t = 33;
        con = player.GetComponent<Controller>();

        audio = GetComponent<AudioSource>();
    }

    void Update () {
        //BMI・Tゲージ監視
        changeBMIguage();
        changeTguage();
	}

    public GameObject player;
    private Controller con;
    //BMIゲージの色・値変更
    public void changeBMIguage()
    {
        //プレイヤーからBMIの値をとってくる
        bmi = con.getBMI();

        //デバッグ用ゲージ上昇・200で0になる
        
        //bmi -= 1.0f;
        //BMIの上限値を設定
        if (bmi > 200f)
        {
            con.setBMI(200f);
        }
        

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
            sc.toResult();
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
            con.setJabAtk(2f);
            con.setSmashAtk(6f);
        }
        if(t > 98)
        {
            con.setJabAtk(5f);
            con.setSmashAtk(10f);
            tLevel2.SetActive(true);
            tLevel3.SetActive(true);
        }
        if(t < 99)
        {
            con.setJabAtk(2f);
            con.setSmashAtk(6f);
            tLevel3.SetActive(false);
        }
        if ( t < 66)
        {
            con.setJabAtk(1f);
            con.setSmashAtk(3f);
            tLevel2.SetActive(false);
            tLevel3.SetActive(false);
        }
        Tguage.value = t;
    }

    //T・FiP
    public void tFiP()
    {
        audio.volume = 0.05f;
        if (t < 99)
        {
            if(t < 66)
            {
                audio.pitch = 0.5f;
                audio.PlayOneShot(audioSorce[1]);
            }
            else if (t < 99)
            {
                audio.pitch = 1.0f;
                audio.PlayOneShot(audioSorce[1]);
            }
            con.incBMI(-0.3f * bmiDecrement);
            if(bmiCounter % 5f == 0f)
            {
                t += (0.2f * tIncrement);
            }
        }
        else if (t >= 99)
        {
            audio.pitch = 2.0f;
            audio.PlayOneShot(audioSorce[1]);
        }

    }

    //スキル
    public void skill()
    {
        if (t > 66)
        {
            audio.volume = 0.1f;
            audio.PlayOneShot(audioSorce[2]);
            t -= 33;
            con.incBMI(50f);
        }
    }

    private float healPoint;
    //BMIゲージ回復
    public float BMIUP(int itemName)
    {
        audio.volume = 0.5f;
        audio.PlayOneShot(audioSorce[3]);
        Debug.Log("ゲージ回復前" + bmi);
        switch (itemName)
        {
            case 0:
                print("おむすび");
                healPoint = 5f;
                break;
            case 1:
                print("コーラ");
                healPoint = 10f;
                break;
            case 2:
                print("ポテチ");
                healPoint = 20f;
                break;
            case 3:
                print("肉まん");
                healPoint = 30f;
                break;
            case 4:
                print("ピザ");
                healPoint = 50f;
                break;
            default:
                healPoint = 0;
                break;
        }
        Debug.Log("ヒールポイント：" + healPoint);
        con.incBMI(healPoint);
        Debug.Log("ゲージ回復後" + bmi);
        return bmi;
    }
}
