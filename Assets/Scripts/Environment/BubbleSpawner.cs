using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [Header("Bubble Prefab")]
    public GameObject bubblePrefab;

    [Header("Spawn Settings")]
    public Transform followTarget;
    public float spawnInterval = 0.3f;
    public float spawnRadius = 2f;
    public int maxBubbles = 20;

    private float timer;

    private void Update()
    {
        if (followTarget == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBubble();
            timer = 0f;
        }
    }

    private void SpawnBubble()
    {
        if (bubblePrefab == null)
            return;

        Vector3 offset = Random.insideUnitSphere * spawnRadius;
        offset.y = Mathf.Abs(offset.y);
        Vector3 spawnPos = followTarget.position + offset;

        GameObject bubble = Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
        bubble.transform.SetParent(null);
    }
}
