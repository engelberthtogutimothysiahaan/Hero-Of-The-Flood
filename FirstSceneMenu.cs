using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneMenu : MonoBehaviour
{
  
    // Fungsi ini akan dipanggil saat tombol Exit diklik
    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();

        
        
    }
}
