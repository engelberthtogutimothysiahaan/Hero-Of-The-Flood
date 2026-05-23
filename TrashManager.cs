using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TrashManager : MonoBehaviour
{
    public int totalTrash = 5;
    public int collectedTrash = 0;
    public TextMeshProUGUI trashText;

    public string nextSceneName;

    void Start()
    {
        StartCoroutine(CountTrashAfterFrame());
    }

    IEnumerator CountTrashAfterFrame()
    {
        yield return new WaitForEndOfFrame(); // Tunggu 1 frame dulu
        totalTrash = GameObject.FindGameObjectsWithTag("Trash").Length;
        UpdateTrashUI();
    }

    public void AddTrash()
    {
        collectedTrash++;
        UpdateTrashUI();

        if (collectedTrash >= totalTrash)
        {
            Debug.Log("Semua sampah terkumpul! Lanjut ke level berikutnya...");
            Invoke(nameof(LoadNextLevel), 1.5f);
        }
    }

    void UpdateTrashUI()
    {
        if (trashText != null)
        {
            trashText.text = $"Sampah: {collectedTrash} / {totalTrash}";
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}