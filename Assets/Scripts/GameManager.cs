using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
    
    public static int lives = 3;
    public static int score = 0;
    public static float timer = 0.0f;
    UI_Score UIscore;
    UI_Lives UIlives;

    void Start()
    {
        UIscore = GetComponent<UI_Score>();
        UIlives = GetComponent<UI_Lives>();
    }

    //Positive numbers to decrease, negative to increase
    public void ModifyLives(int value = 1)
    {
        lives -= value;
        UIlives.UpdateLives(value);
    }
    
    //Positive numbers to increase, negative to decrease
    public void ModifyScore(int points)
    {
        score += points;
        UIscore.UpdateScore(score);
    }
}
