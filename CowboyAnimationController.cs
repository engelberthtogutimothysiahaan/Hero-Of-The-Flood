using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CowboyAnimationController : MonoBehaviour
{
    private Animator animator;

    public PlayerMovement movement; // <-- Muncul di Inspector

    void Start()
    {
        animator = GetComponent<Animator>();

        if (movement == null)
            Debug.LogWarning("PlayerMovement belum di-assign ke CowboyAnimationController.");
    }

    void Update()
    {
        if (movement != null)
        {
            animator.SetFloat("Speed", movement.currentSpeed);
        }
    }
}