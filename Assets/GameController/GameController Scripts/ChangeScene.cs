﻿using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{

    public string versionNum;
	float timeGoneBy;
	
    // Use this for initialization
    void Start()
    {
//		PlayerPrefs.DeleteAll ();

        DestroyObject(GameObject.Find("AudioManager_Game(Clone)"));
        DestroyObject(GameObject.Find("AudioManager_Summary(Clone)"));

        if (GameObject.Find("AudioManager_Menu(Clone)") == null)
        {
            Instantiate(Resources.Load("AudioManager_Menu"), new Vector3(0, 0, 0), Quaternion.identity);
        }

        Resources.UnloadUnusedAssets();

		timeGoneBy = 0.0f;

		DontDestroyOnLoad (GameObject.Find ("Diner"));
		DontDestroyOnLoad (GameObject.Find ("Starfield Background"));
    }

    // Update is called once per frame
    void Update()
    {
		timeGoneBy += Time.deltaTime;

        if (timeGoneBy > 5.2f)
        {
            if (Application.loadedLevelName == "SplashScreen")
            {
                Application.LoadLevel("StartScreenTest");
            }
        }

		if (Application.loadedLevelName == "About") {
			transform.GetComponent<SpriteRenderer>().enabled = false;
		}else{
			transform.GetComponent<SpriteRenderer>().enabled = true;
		}
    }


    void OnMouseDown()
    {
        if (Application.loadedLevelName == "SplashScreen")
        {
            Application.LoadLevel("StartScreenTest");
        }
    }

//    void OnGUI()
//    {
//		if(Application.loadedLevelName == "SplashScreen" || Application.loadedLevelName == "StartScreenTest"){
//	        GUIStyle style = new GUIStyle();
//	        style.fontSize = 22;
//	        style.normal.textColor = Color.white;
//	        GUI.Label(new Rect(Screen.width * 0.7f, Screen.height * 0.05f, Screen.width * 0.3f, Screen.height * 0.12f), versionNum, style);
//	    
//		}
//	}
}