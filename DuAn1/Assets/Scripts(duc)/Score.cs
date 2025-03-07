using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.SetText(score.ToString());
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.SetText(score.ToString());
        if (score == 50)
        {
            SceneManager.LoadScene("Win(duc)");
        }
    }
}
