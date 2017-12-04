using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stillHere : MonoBehaviour {
    int howManyTimes;
	// Use this for initialization
	void Start () {
        howManyTimes = 10;
        DontDestroyOnLoad(GameObject.Find("Taste4"));
	}