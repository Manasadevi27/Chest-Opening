using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject treasurePrefab;

    [Header("Spawn Settings")]
    public Transform player;
    public float spawnDistanceAhead = 15f;
    public float minLateralOffset = -3f;
    public float maxLateralOffset = 3f;
    public float minVerticalOffset = -1f;
    public float maxVerticalOffset = 1f;

    [Header("Spawn Timing")]
    public float initialInterval = 2f;
    public float minInterval = 0.5f;
    public float intervalDecreaseRate = 0.01f;

    private float currentInterval;
    private float timer;
    private float gameTime;

    private void Start()
    {
        currentInterval = initialInterval;
        timer = 0f;
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
            SpawnTreasure();
            timer = 0f;
        }
    }

    private void SpawnTreasure()
    {
        if (treasurePrefab == null)
            return;

        float lateralOffset = Random.Range(minLateralOffset, maxLateralOffset);
        float verticalOffset = Random.Range(minVerticalOffset, maxVerticalOffset);

        Vector3 spawnPos =
            player.position
            + player.forward * spawnDistanceAhead
            + player.right * lateralOffset
            + player.up * verticalOffset;

        Instantiate(treasurePrefab, spawnPos, Quaternion.identity);
    }
}
