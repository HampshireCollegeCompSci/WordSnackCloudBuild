using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class StoreWordsFed : MonoBehaviour {
	public List <string> character1Words;
	public List <string> character2Words;
	public float score;
	public int rawScore;
	public int multiScore;
	public int trashLetterNum;
	public int trashedLetterScore;
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "WordMaking" || SceneManager.GetActiveScene().name == "ScoreScreen"){
			DontDestroyOnLoad(gameObject);
		}
		Debug.Log("WordsFed is Here");
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "WordMaking" && SceneManager.GetActiveScene().name != "ScoreScreen") {
			Destroy(gameObject);
		}
	}
}
