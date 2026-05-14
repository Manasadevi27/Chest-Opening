using UnityEngine;

public class Treasure : MonoBehaviour
{
    [Header("Treasure Settings")]
    public int scoreValue = 10;
    public float despawnDistance = 10f;

    [Header("Visual Feedback")]
    public GameObject collectEffectPrefab;
    public GameObject missEffectPrefab;

    private Transform player;
    private bool isCollected;

    public bool IsCollected => isCollected;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null || isCollected)
            return;

        Vector3 playerPos = player.position;
        Vector3 treasurePos = transform.position;

        float distance = Vector3.Distance(treasurePos, playerPos);
        Vector3 directionToPlayer = playerPos - treasurePos;
        bool isBehind = Vector3.Dot(transform.forward, directionToPlayer) < 0f;

        if (distance >= despawnDistance && isBehind)
        {
            Miss();
        }
    }

    public void Collect()
    {
        if (isCollected)
            return;
        isCollected = true;

        if (collectEffectPrefab != null)
            Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);

        GameManager.Instance?.RegisterTreasureCollected(scoreValue);

        Destroy(gameObject);
    }

    private void Miss()
    {
        if (isCollected)
            return;
        isCollected = true;

        if (missEffectPrefab != null)
            Instantiate(missEffectPrefab, transform.position, Quaternion.identity);

        GameManager.Instance?.RegisterTreasureMissed();

        Destroy(gameObject);
    }
}
