using UnityEngine;

public class ShowCursorOnGameOver : MonoBehaviour
{
    void Start()
    {
        // Menampilkan kursor dan memastikan kursor bebas bergerak
        Cursor.visible = true;  // Menampilkan kursor
        Cursor.lockState = CursorLockMode.None;  // Membebaskan kunci kursor
    }
}