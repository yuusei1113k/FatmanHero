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
    private GameObject tLevel2;
    private GameObject tLevel3;

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

    //T・FiPエフェクト
    private ParticleSystem tEffect;

    //波動エフェクト
    private ParticleSystem hado;
    private SphereCollider hadoc;

    //ソニックブーム
    private GameObject SonicBody;
    private GameObject SonicSatellite;
    bool sonic = false;

    //百烈拳
    private GameObject HundredField;
    private GameObject HundredJab;
    bool hundred = false;

    //グランドハボック
    private GameObject Havoc;
    bool havoc = false;

    int i = 0;
    float skilTime = 0f;
    bool skillOn = false;
    
    //プレイヤーとコントローラー
    private GameObject player;
    private Controller con;


    //他のスクリプトでbmi呼ぶ用
    public float getBMI()
    {
        return bmi;
    }


    void Start () {
        //プレイヤー
        player = GameObject.FindGameObjectWithTag("Player");

        //波動
        hado = player.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        hadoc = hado.GetComponent<SphereCollider>();

        //BMIゲージ(slider)を取得する
        BMIguage = GameObject.Find("BMIguage").GetComponent<Slider>();

        //BMIゲージにあるFill(BMI)を取得する→バーの色を変えるため
        BMIImage = GameObject.Find("Fill(BMI)").GetComponent<Image>();

        //Tゲージ(slider)を取得する
        Tguage = GameObject.Find("Tguage").GetComponent<Slider>();
        tLevel2 = GameObject.Find("TLevel2");
        tLevel3 = GameObject.Find("TLevel3");

        //Stageコンポーネント取得
        stage = FindObjectOfType<StageManager>();
        //print(stage);

        //BMIguage初期化
        bmi = 200.0f;
        //bmi = 100f;
        //Tゲージ初期化
        t = 33;
        //t = 99;

        //コントローラーコンポーネント
        con = player.GetComponent<Controller>();

        //オーディオコンポーネント
        audio = GetComponent<AudioSource>();

        //Tエフェクト
        tEffect = GameObject.Find("TEffect").GetComponent<ParticleSystem>();

        //スキル関係
        SonicBody = GameObject.Find("SonicBody");
        SonicSatellite = GameObject.Find("SonicSatellite");
        HundredField = GameObject.Find("HundredField");
        HundredJab = GameObject.Find("HundredJab");
        Havoc = GameObject.Find("HavocField");
        HundredField.SetActive(false);
        SonicBody.SetActive(false);
        Havoc.SetActive(false);

    }


    void Update () {
        //BMI・Tゲージ監視
        changeBMIguage();
        changeTguage();
	}

    //BMIゲージの色・値変更
    public void changeBMIguage()
    {
        //プレイヤーからBMIの値をとってくる
        bmi = con.getBMI();

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
        //Tゲージ量によりTレベルの表示非表示
        //レベル2
        if(t > 65 && t < 98)
        {
            tLevel2.SetActive(true);
            tLevel3.SetActive(false);
            con.setJabAtk(2f);
            con.setSmashAtk(6f);
            tEffect.emissionRate = 20f;
            hado.startSize = 2f;
            hadoc.radius = 0.4f;
        }
        //レベル3
        if (t > 98)
        {
            con.setJabAtk(5f);
            con.setSmashAtk(10f);
            tLevel2.SetActive(true);
            tLevel3.SetActive(true);
            tEffect.emissionRate = 50f;
            hado.startSize = 3f;
            hadoc.radius = 0.5f;
        }
        //レベル1
        if (t < 66)
        {
            con.setJabAtk(1f);
            con.setSmashAtk(3f);
            tLevel2.SetActive(false);
            tLevel3.SetActive(false);
            tEffect.emissionRate = 5f;
            hado.startSize = 1f;
            hadoc.radius = 0.3f;
        }
        Tguage.value = t;
    }

    //T・FiP
    public void tFiP()
    {
        if(skillOn == false)
        {
            audio.volume = 0.05f;
            if (t < 99)
            {
                tEffect.Play();
                if (t < 66)
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
                if (bmiCounter % 5f == 0f)
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
        else if(skillOn == true)
        {
            print("skilopn");
        }
    }

    //スキル
    //スキル1ソニックブーム
    public void useSkillSonic()
    {
        if (t > 66)
        {
            if (skillOn == false)
            {
                sonic = true;
                audio.volume = 0.1f;
                audio.PlayOneShot(audioSorce[2]);
                StartCoroutine(SkillSonic());
            }
        }
    }
    //スキル2百烈拳
    public void useSkillHundred()
    {
        if (t > 66)
        {
            if (skillOn == false)
            {
                hundred = true;
                audio.volume = 0.1f;
                audio.PlayOneShot(audioSorce[2]);
                t -= 45;
                StartCoroutine(SkillHundred());
            }
        }
    }
    //スキル3グランドハボック
    public void useSkillHavoc()
    {
        if (t > 98)
        {
            if (skillOn == false)
            {
                havoc = true;
                audio.volume = 0.1f;
                audio.PlayOneShot(audioSorce[2]);
                t -= 66;
                StartCoroutine(SkillHavoc());
            }
        }
    }
    //ソニックブーム本体
    IEnumerator SkillSonic()
    {
        skillOn = true;
        SonicBody.transform.position = new Vector3(player.transform.position.x, -2f, player.transform.position.z);
        SonicBody.transform.forward = player.transform.forward;
        SonicBody.SetActive(true);
        while (sonic == true)
        {
            skilTime = Time.deltaTime;
            i++;
            SonicBody.transform.Translate(SonicBody.transform.forward / 10);
            SonicSatellite.transform.RotateAround(SonicBody.transform.position, new Vector3(0, 10f), 30f);
            yield return new WaitForSeconds(0.01f);
            if (i > 100)
            {
                sonic = false;
            }
        }
        i = 0;
        //print("SkillTime: " + skilTime);
        skilTime = 0f;
        SonicBody.transform.position = new Vector3(0f, 2f, 2f);
        SonicBody.SetActive(false);
        skillOn = false;
        yield break;
    }
    //百烈拳本体
    IEnumerator SkillHundred()
    {
        HundredField.transform.position = player.transform.position;
        HundredJab.transform.position = HundredField.transform.position;
        skillOn = true;
        while (hundred == true)
        {
            skilTime += Time.deltaTime;
            i++;
            HundredJab.transform.position = new Vector3(player.transform.position.x + Random.Range(-1f, 2f), player.transform.position.y + Random.Range(1f, 2f), player.transform.position.z + Random.Range(-1f, 2f));
            HundredField.SetActive(true);
            HundredJab.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            HundredJab.SetActive(false);
            if (i > 100)
            {
                HundredField.SetActive(false);
                hundred = false;
            }
        }
        i = 0;
        //print("skillTime: " + skilTime);
        skilTime = 0f;
        skillOn = false;
        yield break;
    }
    //グランドハボック本体
    IEnumerator SkillHavoc()
    {
        ParticleSystem havocP = Havoc.GetComponent<ParticleSystem>();
        Havoc.transform.localScale = Havoc.transform.localScale;
        Havoc.transform.position = player.transform.position;
        skillOn = true;
        while (havoc == true)
        {
            skilTime += Time.deltaTime;
            i++;
            Havoc.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            Havoc.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            if (i > 2)
            {
                havoc = false;
            }
        }
        i = 0;
        //print("skillTime: " + skilTime);
        skilTime = 0f;
        skillOn = false;
        yield break;
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
