using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
    
    public  int lives = 3;
    public  int score = 0;
    public static float timer = 0.0f;
    public GameObject LoseScreen;
    UI_Score UIscore;
    UI_Lives UIlives;

    void Start()
    {
        UIscore = GetComponentInChildren<UI_Score>();
        UIlives = GetComponentInChildren<UI_Lives>();
        UIlives.UpdateLives(lives);
        UIscore.UpdateScore(score);
    }

    //Positive numbers to decrease, negative to increase
    public void ModifyLives(int value = 1)
    {
        lives -= value;
        UIlives.UpdateLives(lives);
    }
    
    //Positive numbers to increase, negative to decrease
    public void ModifyScore(int points)
    {
        score += points;
        UIscore.UpdateScore(score);
    }
    public void LoseGame() 
    {
        LoseScreen.SetActive(true);
    }
    public void Update() 
    {
        if (lives < 1) 
        {
            LoseGame();
        }
    }
}
