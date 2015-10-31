using UnityEngine;
using System.Collections;
using GameSystems;

public class Result : MonoBehaviour {

    //クリア画面
    public GameObject clearScreen;

    //ゲームオーバー画面
    public GameObject gameOverScreen;

    State state = new State();
    
	void Start () {
        if(state.getState() == GameState.StageClear)
        {
            clearScreen.SetActive(true);
            gameOverScreen.SetActive(false);
        }
        else if(state.getState() == GameState.GameOver)
        {
            gameOverScreen.SetActive(true);
            clearScreen.SetActive(false);
        }
	}
	

}
