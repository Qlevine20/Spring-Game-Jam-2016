using UnityEngine;
using UnityEngine.UI;

public class UI_Lives : MonoBehaviour {

    //int lives;
    Text livesRemaining;

    public void UpdateLives(int lives)
    {
        livesRemaining = GetComponent<Text>();
        livesRemaining.text = lives.ToString();
    }
}
