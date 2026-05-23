using UnityEngine;

public class EnemyDropTrash : MonoBehaviour
{
    [Header("Trash Drop Settings")]
    public GameObject trashPrefab; // Prefab sampah yang akan keluar
    public Transform dropPoint;    // Titik di mana trash keluar (boleh kosong, maka akan spawn di posisi enemy)

    // Fungsi untuk menjatuhkan sampah
    public void DropTrash()
    {
        if (trashPrefab != null)
        {
            // Tentukan posisi spawn trash
            Vector3 spawnPosition = dropPoint != null ? dropPoint.position : transform.position;
            // Instantiate trash di posisi yang ditentukan dengan rotasi default
            Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
        }
    }
}