using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

    //int score;
    Text ScoreText;

    public void UpdateScore(int score)
    {
        ScoreText = GetComponent<Text>();
        ScoreText.text = score.ToString();
    }
}
