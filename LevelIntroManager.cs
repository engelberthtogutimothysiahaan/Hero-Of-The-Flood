using UnityEngine;
using TMPro;

public class LevelIntroManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject levelIntroPanel;
    public TextMeshProUGUI levelIntroText;

    [Header("Pengaturan Teks")]
    [TextArea(2, 4)]
    public string message = "Selamat datang di level baru!";

    [Header("Durasi Panel Muncul (detik)")]
    public float displayDuration = 3f;

    [Header("Durasi Game Di-Pause (detik)")]
    public float pauseDuration = 3f;

    void Start()
    {
        if (levelIntroPanel != null && levelIntroText != null)
        {
            // Tampilkan panel dan isi teks
            levelIntroPanel.SetActive(true);
            levelIntroText.text = message;

            // Pause game
            PauseGame();

            // Gunakan unscaled time untuk memastikan tetap berjalan saat game dipause
            StartCoroutine(ResumeAfterDelay(pauseDuration));

            // Sembunyikan panel sesuai displayDuration
            Invoke(nameof(HidePanel), displayDuration);
        }
        else
        {
            Debug.LogWarning("LevelIntroManager: Panel atau TextMeshPro belum di-assign!");
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void HidePanel()
    {
        if (levelIntroPanel != null)
        {
            levelIntroPanel.SetActive(false);
        }
    }

    System.Collections.IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Tidak terpengaruh timeScale
        ResumeGame();
    }
}