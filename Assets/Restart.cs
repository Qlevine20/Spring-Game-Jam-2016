using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void RestartGame() 
    {
        Application.LoadLevel(0);
    }
}
