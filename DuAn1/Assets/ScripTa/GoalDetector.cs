using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Rigidbody2D rb;
    private Vector2 initialPosition; // Khai báo biến để lưu vị trí bắt đầu

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Lưu trữ vị trí bắt đầu của đối tượng
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Xử lý khi va chạm với các vùng ghi bàn
        if (collision.CompareTag("Goal"))
        {
            scoreManager.IncreaseTeam1Score(1);
            StartCoroutine(ResetBallAfterDelay(1f));
        }
        else if (collision.CompareTag("Goal1"))
        {
            scoreManager.IncreaseTeam2Score(1);
            StartCoroutine(ResetBallAfterDelay(1f));
        }

        // Xử lý khi va chạm với đối tượng có tag "Vachvoi"
        
    }

    private IEnumerator ResetBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetBallPosition();
    }

    private void ResetBallPosition()
    {
        rb.velocity = Vector2.zero; // Đặt vận tốc của bóng về 0
        rb.angularVelocity = 0f; // Đặt vận tốc góc của bóng về 0
        transform.position = initialPosition; // Đưa bóng về vị trí bắt đầu
    }
}
