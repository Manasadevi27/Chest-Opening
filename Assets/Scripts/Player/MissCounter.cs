using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissCounter : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI missCountText;
    public GameObject gameOverPanel;

    [Header("Miss Settings")]
    public int maxMisses = 5;

    private int currentMisses;

    public int CurrentMisses => currentMisses;
    public int RemainingMisses => maxMisses - currentMisses;
    public bool IsGameOver => currentMisses >= maxMisses;

    private void Start()
    {
        currentMisses = 0;
        UpdateUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void RegisterMiss()
    {
        if (IsGameOver)
            return;

        currentMisses++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (missCountText != null)
        {
            missCountText.text = $"Misses: {currentMisses}/{maxMisses}";
        }
    }
}
