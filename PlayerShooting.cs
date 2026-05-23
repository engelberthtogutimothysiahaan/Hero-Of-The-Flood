using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletObject;        // Prefab peluru
    public Transform bulletOut;            // Posisi keluar peluru
    public float shootForce = 700f;        // Kekuatan tembak
    public float fireRate = 0.1f;          // Interval antar tembakan (detik)
    public int bulletsPerShot = 5;         // Banyaknya peluru yang keluar sekaligus

    public AudioClip shootSound;           // Suara tembakan
    public float volume = 1f;              // Volume suara tembakan (0.0 - 1.0)

    private AudioSource audioSource;       // Komponen audio
    private float nextFireTime = 0f;       // Waktu berikutnya bisa menembak

    void Start()
    {
        // Ambil atau tambahkan AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;   // Jangan main otomatis
        audioSource.spatialBlend = 0f;     // Set ke 2D agar suara selalu terdengar
        audioSource.volume = volume;       // Atur volume awal
    }

    void Update()
    {
        // Cek apakah karakter sedang bergerak
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        bool isMoving = Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputZ) > 0.1f;

        // Tembak jika klik kiri dan bergerak
        if (Input.GetMouseButton(0) && isMoving && Time.time >= nextFireTime)
        {
            ShootBullets();

            // Mainkan suara tembakan
            if (shootSound != null)
            {
                audioSource.PlayOneShot(shootSound, volume); // Volume dikontrol di sini
            }

            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootBullets()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Vector3 randomSpread = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.05f, 0.05f), 0f);
            GameObject bulletClone = Instantiate(bulletObject, bulletOut.position, bulletOut.rotation);

            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 spreadDirection = bulletOut.forward + randomSpread;
                rb.AddForce(spreadDirection.normalized * shootForce, ForceMode.Impulse);
            }
        }
    }
}