using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    public TextMeshProUGUI waktuAkhirUI; // Optional, bisa dikosongkan jika tidak ingin langsung menampilkan di MainMenu

    public float TotalTime { get; private set; }
    private bool isPaused = false;

    void Awake()
    {
        // Singleton pattern + jangan hancurkan saat pindah scene
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (!isPaused)
        {
            TotalTime += Time.deltaTime;
        }

        // Update waktu ke UI jika di-assign
        if (waktuAkhirUI != null)
        {
            waktuAkhirUI.text = "Waktu: " + GetFormattedTime();
        }
    }

    // Pause timer
    public void PauseTimer() => isPaused = true;

    // Resume timer
    public void ResumeTimer() => isPaused = false;

    // Reset waktu dan resume
    public void ResetTimer()
    {
        TotalTime = 0f;
        isPaused = false;
    }

    // Format tampilannya
    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(TotalTime / 60);
        int seconds = Mathf.FloorToInt(TotalTime % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }
}