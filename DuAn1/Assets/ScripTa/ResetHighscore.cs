using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetHighscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.Save();
        DisplayHighscore();
    }

    void DisplayHighscore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
