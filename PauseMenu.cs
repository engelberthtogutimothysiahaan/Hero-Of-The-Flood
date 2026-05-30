using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    private PlayerMovement player;

    void Start()
    {
        pauseMenu.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused!");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        if (player != null)
        {
            player.EnableCursor(); // Tampilkan kursor
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed!");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        if (player != null)
        {
            player.DisableCursor(); // Sembunyikan kursor
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting from Pause...");
        Time.timeScale = 1f;

        if (player != null)
        {
            player.DisableCursor();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void QuitGame()
    {
    Debug.Log("Loading Main Menu...");
    Time.timeScale = 1f; // Sangat penting untuk mereset Time.timeScale!

    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;

    
    SceneManager.LoadScene("Main Menu"); 
    }
}
