using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    private TrashManager trashManager;
    private PlayerMovement playerMovement;

    [Header("Efek Saat Sampah Diambil")]
    public AudioClip pickupSound;

    [Header("Efek Speed Boost (Optional)")]
    public bool isSpeedBoostTrash = false;
    public float speedMultiplier = 1.5f;
    public float speedDuration = 5f;

    void Start()
    {
        trashManager = FindObjectOfType<TrashManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            trashManager?.AddTrash();

            if (isSpeedBoostTrash)
            {
                playerMovement = other.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    // Gunakan warna yang sudah ditentukan di inspector PlayerMovement
                    playerMovement.ApplySpeedBoostWithColor(speedMultiplier, speedDuration, playerMovement.speedBoostColor);
                }
            }

            Destroy(gameObject);
        }
    }
}