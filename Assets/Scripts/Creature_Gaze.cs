using UnityEngine;
using System.Collections;

public class Creature_Gaze : MonoBehaviour {

    float timetoUserPresence = 2.0f;
    int pointsGained = 100;
    int pointsLost = -50;

    GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
