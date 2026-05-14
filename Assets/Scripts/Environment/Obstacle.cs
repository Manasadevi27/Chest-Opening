using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Type")]
    public ObstacleType type = ObstacleType.Rock;

    [Header("Obstacle Settings")]
    public float despawnDistance = 15f;

    [Header("Effects")]
    public GameObject hitEffectPrefab;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector3 playerPos = player.position;
        Vector3 objPos = transform.position;
        Vector3 directionToPlayer = playerPos - objPos;
        bool isBehind = Vector3.Dot(transform.forward, directionToPlayer) < 0f;

        if (isBehind && Vector3.Distance(playerPos, objPos) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HitPlayer();
        }
    }

    private void HitPlayer()
    {
        GetComponent<Collider>().enabled = false;

        if (hitEffectPrefab != null)
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        AudioManager.Instance?.PlayObstacleHit();
        GameManager.Instance?.GameOver();
    }
}

public enum ObstacleType
{
    Rock,
    SeaPlant,
}
