using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

	IEnumerator Load()
	{
		#if UNITY_IPHONE
		Handheld.SetActivityIndicatorStyle(UnityEngine.iOS.ActivityIndicatorStyle.Gray);
		#elif UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		#endif
		
		Handheld.StartActivityIndicator();
		yield return new WaitForSeconds(0);
	}
	
	void OnGUI()
	{
		if( GUI.Button(new Rect(10, 10, 100, 100), "Start") ) {
			StartCoroutine(Load());
		}
		
		if( GUI.Button(new Rect(10, 120, 100, 100), "Stop") ) {
			Handheld.StopActivityIndicator();
		}
	}
}
