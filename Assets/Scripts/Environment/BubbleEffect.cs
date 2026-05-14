using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    [Header("Bubble Settings")]
    public float riseSpeed = 0.5f;
    public float lifetime = 3f;
    public float wobbleAmount = 0.1f;
    public float wobbleFrequency = 2f;

    private float elapsed;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        float wobble = Mathf.Sin(elapsed * wobbleFrequency) * wobbleAmount;
        transform.position = startPos + Vector3.up * (elapsed * riseSpeed) + Vector3.right * wobble;
    }
}
