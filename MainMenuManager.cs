using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStartGame()
    {
        // Reset waktu
        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.ResetTimer();
        }

        // Pindah ke scene tutorial
        SceneManager.LoadScene("TutorialScene");
    }
}
