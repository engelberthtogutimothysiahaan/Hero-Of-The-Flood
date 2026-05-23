using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneMenu : MonoBehaviour
{
    // Nama scene tutorial yang akan dimuat saat tombol Start diklik
    [SerializeField] private string tutorialSceneName = "TutorialScene"; // Ganti dengan nama scene 

    // Fungsi ini akan dipanggil saat tombol Start diklik
    public void StartTutorial()
    {
        Debug.Log("Loading tutorial scene...");
        SceneManager.LoadSceneAsync(tutorialSceneName);
    }

    // Fungsi ini akan dipanggil saat tombol Exit diklik
    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();

        // Perlu diingat: Application.Quit() hanya berfungsi setelah game dibuild.
        // Saat dijalankan di Editor, tidak akan menutup Unity Editor.
    }
}