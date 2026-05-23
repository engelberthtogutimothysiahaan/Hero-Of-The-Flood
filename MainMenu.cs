using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelSceneName = "Level 1"; // Pastikan nama persis sama dengan scene di Assets dan Build Settings

    // Fungsi ini akan dipanggil saat tombol diklik
    public void PlayGame()
    {
        Debug.Log("Attempting to load scene: " + levelSceneName);
        SceneManager.LoadSceneAsync(levelSceneName);
    }
}