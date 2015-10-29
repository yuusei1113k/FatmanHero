﻿using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour {

    //ステージクリアかどうか
    private bool clear;
    private bool gameOver;

    //Stageコンポーネント
    private StageManager stage;

    //クリア画面
    public GameObject clearScreen;

    //ゲームオーバー画面
    public GameObject gameOverScreen;
    
	void Start () {
        stage = FindObjectOfType<StageManager>();
        clear = stage.getResult();
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