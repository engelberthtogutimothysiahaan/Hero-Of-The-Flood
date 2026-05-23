using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    public float gravity = 9.81f;
    public float rotateSpeed = 200f;
    public float mouseSensitivity = 1f;
    [HideInInspector] public float currentSpeed = 0f;
    private float velocityY = 0f;
    private float originalSpeed;
    private Coroutine speedBoostCoroutine;

    // Health
    public float health = 100f;
    private bool isDead = false;

    // Game Over UI
    public GameObject gameOverMenu;

    // === Music Settings ===
    public AudioSource backgroundMusic;
    [Range(0f, 1f)]
    public float musicVolume = 1f;

    [Header("Speed Boost Visuals")]
    public Renderer playerRenderer;
    public Color speedBoostColor = Color.yellow;
    public GameObject blinkPanel;
    public float blinkInterval = 0.2f;

    private Color originalColor;

    void Awake()
    {
        if (playerRenderer == null)
            playerRenderer = GetComponentInChildren<Renderer>();

        if (playerRenderer != null)
            originalColor = playerRenderer.material.color;
    }

    void Start()
    {
        originalSpeed = moveSpeed;
        DisableCursor();

        // Kurangi sensitivitas jika di WebGL
        #if UNITY_WEBGL
        mouseSensitivity *= 0.3f;
        #endif

        if (backgroundMusic != null)
        {
            backgroundMusic.volume = musicVolume;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    void Update()
    {
        if (isDead) return;

        RotateCamera();
        Movement();
        ApplyGravity();
        CheckForDeath();

        if (backgroundMusic != null && backgroundMusic.volume != musicVolume)
        {
            backgroundMusic.volume = musicVolume;
        }
    }

    void RotateCamera()
    {
        float mouseX = Mathf.Clamp(Input.GetAxisRaw("Mouse X"), -1f, 1f); // Membatasi pergerakan mendadak
        float rotationAmount = mouseX * mouseSensitivity * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationAmount);
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(inputX, 0f, inputZ);
        inputDir = Vector3.ClampMagnitude(inputDir, 1f);
        Vector3 moveDirection = transform.TransformDirection(inputDir);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        currentSpeed = inputDir.magnitude;
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            velocityY = -2f;
        }
        else
        {
            velocityY -= gravity * Time.deltaTime;
        }
        controller.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
    }

    public void ApplySpeedBoost(float multiplier, float duration)
    {
        if (speedBoostCoroutine != null)
            StopCoroutine(speedBoostCoroutine);

        speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    public void ApplySpeedBoostWithColor(float multiplier, float duration, Color newColor)
    {
        if (speedBoostCoroutine != null)
            StopCoroutine(speedBoostCoroutine);

        speedBoostCoroutine = StartCoroutine(SpeedBoostWithColorRoutine(multiplier, duration, newColor));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        moveSpeed = originalSpeed * multiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
        speedBoostCoroutine = null;
    }

    private IEnumerator SpeedBoostWithColorRoutine(float multiplier, float duration, Color newColor)
    {
        moveSpeed = originalSpeed * multiplier;

        if (playerRenderer != null)
            playerRenderer.material.color = newColor;

        if (blinkPanel != null)
            StartCoroutine(BlinkPanelRoutine(duration));

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
        if (playerRenderer != null)
            playerRenderer.material.color = originalColor;

        speedBoostCoroutine = null;
    }

    private IEnumerator BlinkPanelRoutine(float duration)
    {
        float elapsed = 0f;
        bool isActive = false;

        while (elapsed < duration)
        {
            isActive = !isActive;
            blinkPanel.SetActive(isActive);
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        blinkPanel.SetActive(false);
    }

    public void ResetSpeed()
    {
        moveSpeed = originalSpeed;
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
            speedBoostCoroutine = null;
        }
    }

    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CheckForDeath()
    {
        if (health <= 0f && !isDead)
        {
            isDead = true;
            EnableCursor();
            Debug.Log("Player died - cursor enabled");
            OnPlayerDeath();
        }
    }

    void OnPlayerDeath()
    {
        EnableCursor();
        ShowGameOverMenu();
    }

    void ShowGameOverMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            health = 0f;
            CheckForDeath();
        }
    }
}