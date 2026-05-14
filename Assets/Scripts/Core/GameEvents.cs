using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnTreasureCollected;
    public static event Action OnTreasureMissed;
    public static event Action<int> OnStreakChanged;
    public static event Action OnGameOver;
    public static event Action OnGameStart;
    public static event Action<float> OnSpeedIncreased;
    public static event Action<int> OnMissCountChanged;

    public static void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }

    public static void TreasureCollected(int count)
    {
        OnTreasureCollected?.Invoke(count);
    }

    public static void TreasureMissed()
    {
        OnTreasureMissed?.Invoke();
    }

    public static void StreakChanged(int streak)
    {
        OnStreakChanged?.Invoke(streak);
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public static void SpeedIncreased(float multiplier)
    {
        OnSpeedIncreased?.Invoke(multiplier);
    }

    public static void MissCountChanged(int misses)
    {
        OnMissCountChanged?.Invoke(misses);
    }
}
