using UnityEngine;

[CreateAssetMenu(menuName = "Chest Opening/Level Config", fileName = "NewLevelConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Difficulty Settings")]
    public int maxMisses = 5;
    public float initialTreasureInterval = 2f;
    public float minTreasureInterval = 0.5f;
    public float initialObstacleInterval = 4f;
    public float minObstacleInterval = 1.5f;
    public float swimSpeed = 8f;
    public float maxSpeedMultiplier = 3f;
    public float timeToMaxSpeed = 120f;
}
