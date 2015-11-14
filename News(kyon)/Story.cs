using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class Story : MonoBehaviour {

    private GameObject epilogue;

    private GameObject words;

    private GameObject clearModal;

    private GameObject skipButton;

    private string epilogueText;

    private string wordsText;

    public float speed = 1f;

	// Use this for initialization
	void Start () {
        epilogue = GameObject.Find("Epilogue");
        words = GameObject.Find("Words");
        clearModal = GameObject.Find("ClearModal");
        skipButton = GameObject.Find("SkipButton");
        clearModal.SetActive(false);
        epilogueText = "四坊英雄がいじめっこ委員会役員を全員更正させたため、ついにいじめはなくなった。\nしかし、世界にはまだまだいじめは存在する、偶然手にいれたT·FiP という力であったが、四坊英雄は世界のいじめをなくすため旅だったのであった。\n行け四坊英雄、君ならいじめをなくしいじめられっこをたくさん助けることができる。\nなぜならば君は、いじめに泣かせれていた頃の君ではなく、いじめられっこを助けられるヒーローなのだから。\n　　　　　　　　　\n　　　　　　　　　　　\n　　　　　　　　　　　\n　　　　　　\n　　　　　　　　　\n　　　　　　　　　\n　　　　\n　　　　　　\n　　　　　　　　\n　　　　　　\n　　　　　　　\n\n\n\n";
        wordsText = "どれだけ今日が暗くても明日はきっと明るいはずそんな希望を持ち続けていれば暗い日も少なくなるはず　　　希望を捨てたら途端に光のない闇の中だけど　　　希望があれば少しは明るい　　　僕は希望を持ち続けるよ君はどうかな　　　　　さぁがんばろう外に出よう 引きこもっていては気持ちは内向き気持ちを外に向けよう　　　　　　　    　今日は雨でも曇りでも　　きっと晴れるよ今辛いならそれは今だけ  信じてみようきっとよくなるよ　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";
        StartCoroutine(storyWriter(epilogueText));
        StartCoroutine(wordsWriter(wordsText));
    }
	
	// Update is called once per frame
	void Update () {
        //デバッグ用
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKey("s"))
        {
            clearModal.SetActive(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(thank());
        }
    }

    //上部ストーリー
    IEnumerator storyWriter(string str)
    {
        yield return new WaitForSeconds(10.0f);
        int len = 0;
        StringBuilder sb = new StringBuilder();
        Text text = epilogue.GetComponent<Text>();
        yield return null;
        while(len < str.Length)
        {
            epilogue.transform.Translate(epilogue.transform.up * Time.deltaTime * speed);
            sb.Append(str.Substring(len, 1));
            text.text = sb.ToString();
            len++;
            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }

    //下部歌詞
    IEnumerator wordsWriter(string str)
    {
        yield return new WaitForSeconds(20.0f);
        int len = 0;
        StringBuilder sb = new StringBuilder();
        Text text = words.GetComponent<Text>();
        while (len < str.Length)
        {
            sb.Append(str.Substring(len, 1));
            text.text = sb.ToString();
            len++;
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(14.5f);
        StartCoroutine(thank());
        yield break;
    }

    IEnumerator thank()
    {
        epilogue.SetActive(false);
        words.SetActive(false);
        skipButton.SetActive(false);
        clearModal.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel("Title");
    }

    public void SkipButton()
    {
        StartCoroutine(thank());
    }
}
