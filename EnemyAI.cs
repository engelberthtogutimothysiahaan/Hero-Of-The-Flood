using UnityEngine;
using UnityEngine.AI; // Import library untuk NavMeshAgent

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Target pemain yang akan dikejar
    public float speed = 3.5f; // Kecepatan musuh, bisa diatur dari Inspector

    private NavMeshAgent agent; // Komponen NavMeshAgent untuk pergerakan musuh
    private bool isAttacking = false; // Apakah musuh sedang menyerang?

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Ambil komponen NavMeshAgent dari GameObject musuh
        agent.speed = speed; // Atur kecepatan awal
    }

    void Update()
    {
        // Jika pemain ada dan musuh tidak sedang menyerang, kejar pemain
        if (player != null && !isAttacking)
        {
            agent.SetDestination(player.position); // Atur tujuan musuh ke posisi pemain
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Jika musuh menyentuh pemain, hentikan pergerakan
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            agent.isStopped = true; // Hentikan musuh saat menyerang
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Jika pemain menjauh dari musuh, kembali ke mode mengejar
        if (other.CompareTag("Player"))
        {
            isAttacking = false;
            agent.isStopped = false; // Aktifkan kembali pergerakan musuh
        }
    }
}