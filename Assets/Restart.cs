using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour {

    private bool gameStart = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 1 && !gameStart)
        {
            gameStart = true;
            Time.timeScale = 1.0f;
            GameObject.FindGameObjectWithTag("Menu").SetActive(false);
        }
	
	}


    public void RestartGame() 
    {

        Application.LoadLevel(0);
    }
}
