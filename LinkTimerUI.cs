using UnityEngine;
using TMPro;

public class LinkTimerUI : MonoBehaviour
{
    public TextMeshProUGUI waktuText;

    void Start()
    {
        if (GameTimer.Instance != null)
        {
            // Menghubungkan waktu yang dihitung dengan UI
            GameTimer.Instance.waktuAkhirUI = waktuText;

            // Update waktu jika sudah dihitung
            if (!string.IsNullOrEmpty(GameTimer.Instance.GetFormattedTime()))
            {
                waktuText.text = "Kamu menyelesaikan permainan dalam waktu: " + GameTimer.Instance.GetFormattedTime();
            }
        }
    }
}