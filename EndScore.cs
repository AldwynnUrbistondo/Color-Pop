using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    void Update()
    {
        scoreText.text = GameManager.scoreInt.ToString();

        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
