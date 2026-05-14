using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Spawn Settings")]
    public Transform player;
    public float spawnDistanceAhead = 20f;
    public float minLateralOffset = -4f;
    public float maxLateralOffset = 4f;

    [Header("Spawn Timing")]
    public float initialInterval = 4f;
    public float minInterval = 1.5f;
    public float intervalDecreaseRate = 0.02f;

    private float currentInterval;
    private float timer;
    private float gameTime;

    private void Start()
    {
        currentInterval = initialInterval;
    }

    private void Update()
    {
        if (player == null)
            return;

        gameTime += Time.deltaTime;
        currentInterval = Mathf.Max(minInterval, initialInterval - gameTime * intervalDecreaseRate);

        timer += Time.deltaTime;

        if (timer >= currentInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
            return;

        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        if (prefab == null)
            return;

        float lateralOffset = Random.Range(minLateralOffset, maxLateralOffset);

        Vector3 spawnPos =
            player.position + player.forward * spawnDistanceAhead + player.right * lateralOffset;

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
