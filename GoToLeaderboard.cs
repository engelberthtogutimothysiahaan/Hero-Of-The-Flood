using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLeaderboard : MonoBehaviour
{
    public void OnLeaderboardButton()
    {
        SceneManager.LoadScene("Leaderboard"); 
        // Atau ganti dengan nama scene leaderboard kamu jika berbeda
    }
}
