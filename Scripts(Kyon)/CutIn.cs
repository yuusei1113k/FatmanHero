using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class CutIn : MonoBehaviour {

    //スプライト格納用
    List<Sprite[]> list = new List<Sprite[]>();
    private Sprite[] cutIn1 = new Sprite[4];
    private Sprite[] cutIn2 = new Sprite[4];
    private Sprite[] cutIn3 = new Sprite[4];

    //アニメーションコルーチン
    IEnumerator coroutine;

    //コルーチン脱出用
    private bool b;

    //CutInナンバー確認用
    int cut = 0;

    // Use this for initialization
    void Start () {

        for (int j = 0; j < 4; j++)
        {
            cutIn1 = Resources.LoadAll<Sprite>("CutIn/Skill1");
            cutIn2 = Resources.LoadAll<Sprite>("CutIn/Skill2");
            cutIn3 = Resources.LoadAll<Sprite>("CutIn/Skill3");
        }
        list.Add(cutIn1);
        list.Add(cutIn2);
        list.Add(cutIn3);
    }
    // Update is called once per frame
    void Update () {
        CutInAnimatation(transform.gameObject.name);
    }

    //カットイン受け取り
    void CutInAnimatation(string name)
    {
        b = true;

        switch (name)
        {
            case "CutIn1":
                cut = 0;
                break;
            case "CutIn2":
                cut = 1;
                break;
            case "CutIn3":
                cut = 2;
                break;
        }
        StartCoroutine(loopAnimation());
    }

    //アニメーション
    IEnumerator loopAnimation()
    {
        foreach (var val in list[cut])
        {
            gameObject.GetComponent<Image>().sprite = val;
            yield return new WaitForSeconds(0.1f);
            if (b == false)
            {
                yield break;
            }
        }

    }

    //コルーチン脱出
    void OnDisable()
    {
        b = false;
    }


}
