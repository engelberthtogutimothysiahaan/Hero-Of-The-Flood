using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public TMP_Text rank1Text;
    public TMP_Text rank2Text;
    public TMP_Text rank3Text;

    void Start()
    {
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        leaderboardPanel.SetActive(true);

        string name1 = PlayerPrefs.GetString("HighScoreName1", "---");
        float score1 = PlayerPrefs.GetFloat("HighScore1", 0f);

        string name2 = PlayerPrefs.GetString("HighScoreName2", "---");
        float score2 = PlayerPrefs.GetFloat("HighScore2", 0f);

        string name3 = PlayerPrefs.GetString("HighScoreName3", "---");
        float score3 = PlayerPrefs.GetFloat("HighScore3", 0f);

        Debug.Log($"Loaded Leaderboard:");
        Debug.Log($"1. {name1} - {score1}");
        Debug.Log($"2. {name2} - {score2}");
        Debug.Log($"3. {name3} - {score3}");

        rank1Text.text = $"1. {name1} - {FormatTime(score1)}";
        rank2Text.text = $"2. {name2} - {FormatTime(score2)}";
        rank3Text.text = $"3. {name3} - {FormatTime(score3)}";
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return $"{minutes:D2} menit {seconds:D2} detik";
    }
}