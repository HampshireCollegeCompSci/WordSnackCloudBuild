using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//This is deprecated now that we're using LoadLevel.Async - Josiah

public class Loading : MonoBehaviour {
	
	public static Loading instance;
	public bool showLoadingScreen = true;
	public Texture loadingScreen;
	
	void Awake(){
		if(instance == null){
			instance = this;
		}
		if(instance != this){
			Destroy(gameObject);
		}
		else{
			//DontDestroyOnLoad(gameObject);
		}
	}
	//Commented out because we're now loading scenes async and it's pretty fast on modern phones anyway
	/*void OnGUI () {
		if(showLoadingScreen && Application.isLoadingLevel && loadingScreen != null){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),loadingScreen);
		}
	}
	*/
}