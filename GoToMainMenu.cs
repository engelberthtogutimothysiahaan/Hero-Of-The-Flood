using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}