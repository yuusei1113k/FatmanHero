using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSystems;

public class LoadScene : MonoBehaviour {

	private AsyncOperation async;

	private GameObject parent;

	private Slider lodingBar;

	private Text loadingText;

	private Text startText;

	string stageName;

	float i = 0;

    ScenChanger sc = new ScenChanger();

    State state = new State();
	
	void Start(){
		parent = transform.root.gameObject;

		lodingBar = GameObject.Find("LoadingBar").GetComponent<Slider>();
		loadingText = GameObject.Find ("LoadingText").GetComponent<Text> ();
		startText = GameObject.Find ("StartText").GetComponent<Text> ();
        print("Stage: " + sc.getStageName());

		StartCoroutine (Load());

	}
	
	// Update is called once per frame
	void Update () {

	}

 	IEnumerator Load(){


		Debug.Log ("コルーチン内処理" + parent);

		//ステージ名はStage01～

		stageName = sc.getStageName().ToString();
        
		print ("stageName: " + stageName);
		//Debug.Log ("aaaa" + scenechanger);
		//Debug.Log ("bbbb" + scenechanger.toLoading ());
		
		// 非同期でロード開始
		async = Application.LoadLevelAsync(stageName.ToString());
		// デフォルトはtrue。ロード完了したら勝手にシーンきりかえ発生しないよう設定。
		async.allowSceneActivation= false;
		
		// 非同期読み込み中の処理

		while(async.progress < 0.9f){
		//while(i < 0.9f){

			loadingText.text = "NowLoading..." + (async.progress * 100).ToString("F0") + "%";
			//loadingText.text = "NowLoading..." + (i*100+20).ToString("F0") + "%";
			Debug.Log ("ローディングパーセント" + async.progress * 100);
			//i = i + 0.1f;
			//lodingBar.value = i;
			lodingBar.value = async.progress;
			yield return new WaitForEndOfFrame();
			//yield return new WaitForSeconds(5f);

		}
		lodingBar.value = 0.9f;
		loadingText.text = "NowLoading...100%";

		//yield return new WaitForSeconds(10f);

		yield return async;
		//async.allowSceneActivation = true;				           
	}

	void swichLoad(){
		startText.text = "TAP to START";
		if(Input.GetMouseButtonDown(0)){
			// タッチしたら遷移する（検証用）
			Debug.Log ("タッチ取得");
			async.allowSceneActivation= true;
		}
	}

	void OnGUI(){
		if (loadingText.text == "NowLoading...100%") {
			swichLoad ();
		}
	}

}
