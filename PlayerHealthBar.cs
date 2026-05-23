using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100; // HP Maksimum Player
    private int currentHealth;
    private bool isDead = false;

    [Header("UI References")]
    public Image healthBarImage; // Health bar UI (drag Image fill type ke sini)
    public GameObject gameOverCanvas; // UI Game Over canvas (drag canvas ke sini)

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false); // Sembunyikan UI Game Over saat awal game
        }

        // Awal game: sembunyikan kursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Abaikan jika sudah mati

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        Debug.Log("Player terkena damage! HP sekarang: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            float healthRatio = (float)currentHealth / maxHealth;
            healthBarImage.fillAmount = Mathf.Clamp01(healthRatio);
        }
        else
        {
            Debug.LogError("Health Bar Image belum di-assign!");
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Player Mati!");
        gameObject.SetActive(false); // Nonaktifkan player object (bisa diganti efek mati)

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // Tampilkan UI Game Over
        }

        // ✅ Munculkan kursor agar player bisa klik tombol di Game Over UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    } // ← Kurung tutup fungsi Die()

} // ← Kurung tutup class PlayerHealth