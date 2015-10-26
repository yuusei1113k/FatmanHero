using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour {

    //ステージクリアかどうか
    public bool clear;

    //Stageコンポーネント
    private Stage stage;

    //クリア画面
    public GameObject clearScreen;

    //ゲームオーバー画面
    public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
        stage = GetComponent<Stage>();
        //clear = stage.getResult();
        if(clear == true)
        {
            clearScreen.SetActive(true);
            gameOverScreen.SetActive(false);
        }
        else if(clear == false)
        {
            gameOverScreen.SetActive(true);
            clearScreen.SetActive(false);
        }
	}
	

}
