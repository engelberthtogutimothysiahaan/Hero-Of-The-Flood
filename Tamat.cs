using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tamat : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "Main Menu";
    [SerializeField] private TMP_InputField nameInputField;

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.PauseTimer();  // Hentikan timer saat masuk scene Tamat
        }
    }

    public void SubmitScoreAndReturnToMainMenu()
    {
        string playerName = string.IsNullOrWhiteSpace(nameInputField.text) ? "Player" : nameInputField.text;
        float finalTime = GameTimer.Instance != null ? GameTimer.Instance.TotalTime : 9999f;

        SaveHighScore(playerName, finalTime);
        SceneManager.LoadSceneAsync(mainMenuSceneName);
    }

    void SaveHighScore(string name, float time)
    {
        float score1 = PlayerPrefs.GetFloat("HighScore1", float.MaxValue);
        float score2 = PlayerPrefs.GetFloat("HighScore2", float.MaxValue);
        float score3 = PlayerPrefs.GetFloat("HighScore3", float.MaxValue);

        if (time < score1)
        {
            PlayerPrefs.SetFloat("HighScore3", score2);
            PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("HighScoreName2", "---"));

            PlayerPrefs.SetFloat("HighScore2", score1);
            PlayerPrefs.SetString("HighScoreName2", PlayerPrefs.GetString("HighScoreName1", "---"));

            PlayerPrefs.SetFloat("HighScore1", time);
            PlayerPrefs.SetString("HighScoreName1", name);
        }
        else if (time < score2)
        {
            PlayerPrefs.SetFloat("HighScore3", score2);
            PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("HighScoreName2", "---"));

            PlayerPrefs.SetFloat("HighScore2", time);
            PlayerPrefs.SetString("HighScoreName2", name);
        }
        else if (time < score3)
        {
            PlayerPrefs.SetFloat("HighScore3", time);
            PlayerPrefs.SetString("HighScoreName3", name);
        }

        PlayerPrefs.Save();
    }
}