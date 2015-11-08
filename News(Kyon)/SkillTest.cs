using UnityEngine;
using System.Collections;

public class SkillTest : MonoBehaviour {

    //ソニックブーム
    private GameObject SonicBody;
    private GameObject SonicSatellite;
    bool sonic = false;

    //百烈拳
    private GameObject HundredField;
    private GameObject HundredJab;
    Vector3 HundredJabPos;
    bool hundred = false;

    //グランドハボック
    private GameObject Havoc;
    bool havoc = false;

    int i = 0;
    float skilTime = 0f;
    bool skillOn = false;



    // Use this for initialization
    void Start () {
        SonicBody = GameObject.Find("SonicBody");
        SonicSatellite = GameObject.Find("SonicSatellite");
        HundredField = GameObject.Find("HundredField");
        HundredJab = GameObject.Find("HundredJab");
        Havoc = GameObject.Find("HavocField");
        HundredJabPos = HundredJab.transform.position;
        HundredJab.SetActive(false);
        SonicBody.SetActive(false);
        Havoc.SetActive(false);
	}

	void Update () {
        //移動
        if (Input.GetKey("space"))
        {
            transform.Translate(new Vector3(0, 2f, 0));
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(new Vector3(-2f, 0, 0));
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(new Vector3(0, 0, 2f));
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(new Vector3(2f, 0, 0));
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(new Vector3(0, 0, -2));
        }
        if (Input.GetKey("z"))
        {
            transform.position = new Vector3(0, 2f, 0);
        }

        //スキル
        if (Input.GetKey("1"))
        {
            print("Push1");
            if (skillOn == false)
            {
                sonic = true;
                StartCoroutine(SkillSonic());
            }
        }
        if (Input.GetKey("2"))
        {
            print("Push2");
            if (skillOn == false)
            {
                hundred = true;
                StartCoroutine(SkillHundred());
            }
        }
        if (Input.GetKey("3"))
        {
            print("Push3");
            if (skillOn == false)
            {
                havoc = true;
                StartCoroutine(SkillHavoc());
            }
        }
    }

    IEnumerator SkillSonic()
    {
        skillOn = true;
        SonicBody.transform.position = new Vector3(0f, 2f, 2f);
        SonicBody.SetActive(true);
        while(sonic == true)
        {
            skilTime = Time.deltaTime;
            //print(i);
            i++;
            SonicBody.transform.Translate(transform.forward / 10);
            SonicSatellite.transform.RotateAround(SonicBody.transform.position, new Vector3(0, 10f), 30f);
            yield return new WaitForSeconds(0.03f);
            if(i > 100)
            {
                sonic = false;
            }
        }
        i = 0;
        //print("SkillTime: " + skilTime);
        skilTime = 0f;
        SonicBody.transform.position = new Vector3(0f, 2f, 2f);
        SonicBody.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        skillOn = false;
        yield break;
    }

    IEnumerator SkillHundred()
    {
        skillOn = true;
        while (hundred == true)
        {
            skilTime += Time.deltaTime;
            //print(i);
            i++;
            HundredJabPos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1.5f, 3f), 2.4f);
            HundredJab.transform.position = HundredJabPos;
            HundredJab.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            HundredJab.SetActive(false);
            if (i > 100)
            {
                print("i > 100");
                hundred = false;
            }
        }
        i = 0;
        //print("skillTime: " + skilTime);
        skilTime = 0f;
        yield return new WaitForSeconds(3.0f);
        skillOn = false;
        yield break;
    }

    IEnumerator SkillHavoc()
    {
        skillOn = true;
        while (havoc == true)
        {
            skilTime += Time.deltaTime;
            //print(i);
            i++;
            Havoc.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            Havoc.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            if (i > 2)
            {
                print("i > 2");
                havoc = false;
            }
        }
        i = 0;
        //print("skillTime: " + skilTime);
        skilTime = 0f;
        yield return new WaitForSeconds(3.0f);
        skillOn = false;
        yield break;
    }
}
