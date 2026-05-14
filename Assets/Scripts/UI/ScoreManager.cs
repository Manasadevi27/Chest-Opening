using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI treasuresText;
    public TextMeshProUGUI streakText;
    public TextMeshProUGUI highScoreText;

    private int currentScore;
    private int treasuresCollected;
    private int currentStreak;
    private int bestStreak;
    private int highScore;

    private const string HighScorePrefKey = "HighScore";

    public int CurrentScore => currentScore;
    public int TreasuresCollected => treasuresCollected;
    public int BestStreak => bestStreak;
    public int HighScore => highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScorePrefKey, 0);
        UpdateUI();
    }

    public void AddTreasureScore(int value)
    {
        treasuresCollected++;
        currentStreak++;
        if (currentStreak > bestStreak)
            bestStreak = currentStreak;

        int streakBonus = Mathf.FloorToInt(currentStreak / 5) * 5;
        currentScore += value + streakBonus;

        UpdateUI();
    }

    public void BreakStreak()
    {
        currentStreak = 0;
        UpdateUI();
    }

    public void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScorePrefKey, highScore);
            PlayerPrefs.Save();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {currentScore}";

        if (treasuresText != null)
            treasuresText.text = $"Treasures: {treasuresCollected}";

        if (streakText != null)
            streakText.text = currentStreak >= 2 ? $"Streak: {currentStreak}x" : "";

        if (highScoreText != null)
            highScoreText.text = $"Best: {highScore}";
    }
}
