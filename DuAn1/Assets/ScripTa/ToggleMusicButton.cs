using UnityEngine;

public class ToggleMusicButton : MonoBehaviour
{
    // Tham chiếu đến AudioSource cần bật/tắt
    public AudioSource audioSource;

    // Gọi hàm này khi nút Music được bấm
    public void ToggleMusic()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Tạm dừng AudioSource nếu đang chạy
            }
            else
            {
                audioSource.Play(); // Chạy lại AudioSource nếu đang tắt
            }
        }
    }
}
