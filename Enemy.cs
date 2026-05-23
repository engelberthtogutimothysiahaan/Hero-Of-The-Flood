using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;
    public int attackDamage = 20; // Damage yang diberikan ke Player

    public Image healthBarImage; // HP bar UI (harus diassign ke Fill Image di Canvas)

    private Rigidbody rb;

    private void Start()
    {
        currentHealth = maxHealth;

        // Ambil reference ke Rigidbody dan atur agar tidak terpental
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        UpdateHealthBar(); // Pastikan health bar diupdate saat start
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return; // Mencegah musuh menerima damage setelah mati

        currentHealth -= damage;
        UpdateHealthBar();

        Debug.Log("Enemy terkena damage! HP sekarang: " + currentHealth);

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
            healthBarImage.fillAmount = Mathf.Clamp(healthRatio, 0, 1); // Mencegah nilai tidak valid
        }
    }

    private void Die()
    {
        Debug.Log("Enemy mati!");
        Destroy(gameObject); // Hapus musuh dari game
    }

     // **Menyerang Player saat bersentuhan dengan Collider**
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy bertabrakan dengan: " + collision.gameObject.name); // Debugging

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player terkena serangan dari enemy!");
            }
        }
    }
}