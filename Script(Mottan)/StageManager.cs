using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	//ポーズ中かどうか
    private bool pause;
    //クリア判定
    private bool clear;
	//ゲームオーバー判定
	private bool gameover;
	// Bossのタグを取得
	public bool BD = GameObject.FindGameObjectWithTag("Boss");
	// scenechangerのScriptを取得
	private SceneChanger SC = GameObject.FindObjectOfType<SceneChanger> ();
	// ポーズ判定
    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    public bool getPause()
    {
        return pause;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
		// タグを常時判定しタグがFalseになったら判定
		if ( BD == false) {
			clear = true;
			SC.toResult();
		}
	}
}
