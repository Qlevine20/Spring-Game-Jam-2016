﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {
		
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int t = Mathf.RoundToInt(Time.time);
		text.text = t.ToString();
	}
}
