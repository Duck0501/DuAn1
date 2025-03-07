using UnityEngine;

public class GameController : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    public void Team1Scores()
    {
        scoreManager.IncreaseTeam1Score(1);
    }

    
    public void Team2Scores()
    {
        scoreManager.IncreaseTeam2Score(1); 
    }
}
