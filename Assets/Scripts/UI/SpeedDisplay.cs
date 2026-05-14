using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    [Header("References")]
    public ChestMovement playerMovement;
    public TextMeshProUGUI speedText;
    public Slider speedSlider;

    [Header("Display")]
    public string prefix = "Speed: ";
    public string suffix = "x";

    private void Update()
    {
        if (playerMovement == null) return;

        float multiplier = playerMovement.SpeedMultiplier;
        string display = $"{prefix}{multiplier:F1}{suffix}";

        if (speedText != null)
            speedText.text = display;

        if (speedSlider != null)
            speedSlider.value = multiplier / playerMovement.maxSpeedMultiplier;
    }
}
