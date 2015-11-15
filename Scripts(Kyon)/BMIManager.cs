using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSystems;

public class BMIManager : MonoBehaviour {
    //BMIを減らすスピードを変える
    private float bmiDecrement = 1f;

    //T・FiPを増やすスピードを変える
    private float tIncrement = 3f;
    
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

    //ステート
    State state = new State();

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
    private GameObject testHavoc;


    int i = 0;
    float skilTime = 0f;
    private bool skillOn = false;
    
    //プレイヤーとコントローラー
    private GameObject player;
    private Controller con;

    //アニメーター
    Animator anim;

    //スキルカットイン
    GameObject[] cutIns = new GameObject[3];

    //他のスクリプトでbmi呼ぶ用
    public float getBMI()
    {
        return bmi;
    }

	//スクリーンのボタン配列
	private Button[] screenButton = new Button[3];

	private string sName;

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
        stage = GameObject.Find("StageManager").GetComponent<StageManager>();
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
        //リソースからゲームオブジェクトを取得し出す
        //ソニックブーム
        GameObject sb = (GameObject)Resources.Load("SkillObjects/SonicBody");
        SonicBody = (GameObject)Instantiate(sb, sb.transform.position, sb.transform.rotation);
        SonicSatellite = GameObject.Find("SonicSatellite");

        //ハンドレッドラッシュ
        GameObject hb = (GameObject)Resources.Load("SkillObjects/HundredField");
        Vector3 hbPos = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z + 1.0f);
        HundredField = (GameObject)Instantiate(hb, hbPos, hb.transform.rotation);
        HundredJab = GameObject.Find("HundredJab");
        HundredField.transform.SetParent(player.transform);

        //グランドハボック
        //GameObject hv = (GameObject)Resources.Load("SkillObjects/HavocField");
        GameObject hv = (GameObject)Resources.Load("SkillObjects/TestHavoc");
        Havoc = (GameObject)Instantiate(hv, hv.transform.position, hv.transform.rotation);
        HundredField.SetActive(false);
        SonicBody.SetActive(false);
        Havoc.SetActive(false);

        //アニメーター
        anim = player.GetComponent<Animator>();

        //スキルカットイン
        cutIns[0] = GameObject.Find("CutIn1");
        cutIns[1] = GameObject.Find("CutIn2");
        cutIns[2] = GameObject.Find("CutIn3");
        cutIns[0].SetActive(false);
        cutIns[1].SetActive(false);
        cutIns[2].SetActive(false);

		//スキルボタン取得
		getSkillButton();
    }


    void Update () {
        //BMI・Tゲージ監視
        changeBMIguage();
        changeTguage();

        //デバッグ用
        if (Input.GetKeyDown("1"))
        {
            StartCoroutine(CutIn(0));
        }
        if (Input.GetKeyDown("2"))
        {
            StartCoroutine(CutIn(1));
        }
        if (Input.GetKeyDown("3"))
        {
            StartCoroutine(CutIn(2));
        }
    }

    //スキルボタンを配列に
    public void getSkillButton()
	{
		int j = 1;

		for (int i = 0; i < 3; i++)
		{
			switch(i){
			case 0:
				sName = "Sonic";
				break;
			case 1:
				sName = "Rush";
				break;
			case 2:
				sName = "Havoc";
				break;
			}

			screenButton[i] = GameObject.Find(sName).GetComponent<Button>();
			j++;
			//print("screenButton" + screenButton[i]);
			screenButton[i].interactable = false;
		}
	}

    //BMIゲージの色・値変更
    public void changeBMIguage()
    {        
        //常時減少
        if(state.getState() == GameState.Playing)
        {
            con.incBMI(-0.01f);
        }

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
            //BMIImage.color = new Color(6, 255, 131, 255);
            BMIImage.color = Color.green;
        }
        else if (bmi > 18)
        {
            //BMIImage.color = new Color(255, 206, 0, 255);
            BMIImage.color = Color.yellow;
        }
        else if (bmi >= 0f)
        {
            //BMIImage.color = new Color(255, 6, 6, 255);
            BMIImage.color = Color.red;
        }

        //Valueにbmiをいれる
        BMIguage.value = bmi;

        //BMIが0以下になったら
        if(bmi <= 0)
        {
            stage.setResult(false);
            StartCoroutine(stage.telop());
        }
    }

    //Tゲージ
    public void changeTguage()
    {
        //Tゲージ量によりTレベルの表示非表示
        //レベル2
        if(t > 65 && t < 98)
        {
            //表示
            tLevel2.SetActive(true);
            tLevel3.SetActive(false);
            //更生力
            con.setJabAtk(2f);
            con.setSmashAtk(6f);
            //オーラ
            tEffect.emissionRate = 20f;
            tEffect.startSize = 3f;
            //波動
            hado.startSize = 2f;
            hadoc.radius = 0.4f;
			screenButton[0].interactable = true;
			screenButton[1].interactable = true;
			screenButton[2].interactable = false;
        }
        //レベル3
        if (t > 98)
        {
            con.setJabAtk(5f);
            con.setSmashAtk(10f);
            tLevel2.SetActive(true);
            tLevel3.SetActive(true);
            tEffect.emissionRate = 50f;
            tEffect.startSize = 10f;
            hado.startSize = 3f;
            hadoc.radius = 0.5f;
			screenButton[2].interactable = true;
        }
        //レベル1
        if (t < 66)
        {
            con.setJabAtk(1f);
            con.setSmashAtk(3f);
            tLevel2.SetActive(false);
            tLevel3.SetActive(false);
            tEffect.emissionRate = 5f;
            tEffect.startSize = 2f;
            hado.startSize = 1f;
            hadoc.radius = 0.3f;
			screenButton[0].interactable = false;
			screenButton[1].interactable = false;
			screenButton[2].interactable = false;
        }
        if(t < 33)
        {
            t = 33;
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
            //print("skilOn");
        }
    }

    //スキル
    //使用状況取得用
    public bool getSkillOn()
    {
        return skillOn;
    }
    //スキル1ソニックブーム
    public void useSkillSonic()
    {
        if (t > 66)
        {
            if (skillOn == false)
            {
                sonic = true;
                audio.volume = 0.1f;
                StartCoroutine(CutIn(0));
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
                StartCoroutine(CutIn(1));
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
                t -= 66;
                StartCoroutine(CutIn(2));
                StartCoroutine(SkillHavoc());
            }
        }
    }
    //ソニックブーム本体
    IEnumerator SkillSonic()
    {
        skillOn = true;
        anim.SetTrigger("SkillSonic");
        SonicBody.transform.position = new Vector3(player.transform.position.x, -2f, player.transform.position.z);
        SonicBody.transform.rotation = player.transform.rotation;
        yield return new WaitForSeconds(0.3f);
        SonicBody.SetActive(true);
        audio.PlayOneShot(audioSorce[2]);
        anim.SetTrigger("OffSkill");
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
        anim.SetTrigger("SkillRush");
        skillOn = true;
        while (hundred == true)
        {
            skilTime += Time.deltaTime;
            i++;
            HundredJab.transform.position = new Vector3(player.transform.position.x + Random.Range(-1f, 1f), player.transform.position.y + Random.Range(1f, 2f),player.transform.position.z + 1f);
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
        anim.SetTrigger("OffSkill");
        print("anim.setTrigger(off)");
        skilTime = 0f;
        skillOn = false;
        yield break;
    }

    //グランドハボック本体
    IEnumerator SkillHavoc()
    {
        ParticleSystem havocP = Havoc.GetComponent<ParticleSystem>();
        anim.SetTrigger("SkillHavoc");
        Havoc.transform.localScale = Havoc.transform.localScale;
        //Havoc.transform.position = player.transform.position;
        Havoc.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.1f, player.transform.position.z);
        skillOn = true;
        anim.SetTrigger("OffSkill");
        yield return new WaitForSeconds(0.7f);
        while (havoc == true)
        {
            audio.PlayOneShot(audioSorce[2]);
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

    //スキルカットイン
    IEnumerator CutIn(int i)
    {
        cutIns[i].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        cutIns[i].SetActive(false);
        yield break;
    }

    private float healPoint;
    //BMIゲージ回復
    public float BMIUP(int itemName)
    {
        audio.volume = 0.5f;
        audio.PlayOneShot(audioSorce[3]);
        switch (itemName)
        {
            case 0:
                //print("おむすび");
                healPoint = 15f;
                break;
            case 1:
                //print("コーラ");
                healPoint = 20f;
                break;
            case 2:
                //print("ポテチ");
                healPoint = 30f;
                break;
            case 3:
                //print("ピザ");
                healPoint = 50f;
                break;
            case 4:
                //print("ピザボックス");
                healPoint = 70f;
                break;
            default:
                healPoint = 0;
                break;
        }
        con.incBMI(healPoint);
        return bmi;
    }
}
