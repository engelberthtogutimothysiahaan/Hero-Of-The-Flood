using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Damage yang diberikan peluru
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        
        // Menghancurkan peluru setelah 2 detik
        Destroy(gameObject, 1f);
    }
}

