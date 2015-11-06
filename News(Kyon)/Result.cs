using UnityEngine;
using System.Collections;
using GameSystems;

public class Result : MonoBehaviour {

    //クリア画面
    public GameObject clearScreen;

    //ゲームオーバー画面
    public GameObject gameOverScreen;

    //ゲームステート
    State state = new State();
    
    //クリア情報
    ClearedStage cs = new ClearedStage();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

	void Start () {
        if(state.getState() == GameState.StageClear)
        {
            cs.setCleared(sc.getStageName(), 1);
            print(cs.getClearedStages()[sc.getStageName()]);
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
