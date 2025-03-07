using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText; // Text UI để hiển thị số bàn thắng của đội 1
    [SerializeField] TextMeshProUGUI ScoreText1; // Text UI để hiển thị số bàn thắng của đội 2
    [SerializeField] TextMeshProUGUI highscoreText;  // Text UI để hiển thị điểm cao nhất
    private int team1Score = 0;
    private int team2Score = 0;

    void Start()
    {
        DisplayHighscore();
        UpdateScoreText();
    }

    public void IncreaseTeam1Score(int amount)
    {
        team1Score += amount;
        UpdateScoreText();
    }

    public void IncreaseTeam2Score(int amount)
    {
        team2Score += amount;
        UpdateScoreText();
    }

    public void SaveScore()
    {
        int currentHighscore = PlayerPrefs.GetInt("Highscore", 0);
        int higherScore = Mathf.Max(team1Score, team2Score);
        if (higherScore > currentHighscore)
        {
            PlayerPrefs.SetInt("Highscore", higherScore);
            PlayerPrefs.Save();
        }
        DisplayHighscore();
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Team 1: " + team1Score.ToString();
        ScoreText1.text = "Team 2: " + team2Score.ToString();
    }

    void DisplayHighscore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
