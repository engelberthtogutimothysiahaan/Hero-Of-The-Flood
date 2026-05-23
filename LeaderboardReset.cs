using UnityEngine;

public class LeaderboardReset : MonoBehaviour
{
    [ContextMenu("Reset Leaderboard")]
    public void ResetLeaderboard()
    {
        PlayerPrefs.DeleteKey("HighScoreName1");
        PlayerPrefs.DeleteKey("HighScore1");
        PlayerPrefs.DeleteKey("HighScoreName2");
        PlayerPrefs.DeleteKey("HighScore2");
        PlayerPrefs.DeleteKey("HighScoreName3");
        PlayerPrefs.DeleteKey("HighScore3");
        PlayerPrefs.DeleteKey("LeaderboardReset"); // opsional, supaya bisa reset lagi nanti
        PlayerPrefs.Save();
        Debug.Log("Leaderboard telah di-reset dari Inspector!");
    }
}