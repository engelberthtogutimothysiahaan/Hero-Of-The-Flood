using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // Ensure EventSystem is used for UI interaction

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI; // UI Game Over
    private PlayerMovement playerMovement; // Reference to PlayerMovement

    void Start()
    {
        gameOverUI.SetActive(false); // Hide Game Over UI at start
        playerMovement = FindObjectOfType<PlayerMovement>(); // Find PlayerMovement in the scene
    }

    // Call this method to trigger the Game Over screen
    public void TriggerGameOver()
    {
        Debug.Log("Game Over Triggered!");
        gameOverUI.SetActive(true); // Show Game Over UI
        Time.timeScale = 0f; // Pause the gameplay

        // Show cursor for UI interaction
        playerMovement.EnableCursor();

        // Ensure EventSystem is active
        EventSystem.current.enabled = true;
    }

    // Restart the game
    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
        Time.timeScale = 1f; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene

        // Hide and lock the cursor again after restarting
        playerMovement.DisableCursor();
    }

    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}