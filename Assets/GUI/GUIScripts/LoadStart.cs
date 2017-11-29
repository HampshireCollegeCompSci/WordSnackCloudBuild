using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnMouseDown () {
        SceneManager.LoadSceneAsync("StartScreenTest");
	}
}
