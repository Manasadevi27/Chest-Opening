using UnityEngine;

public class UnderwaterCamera : MonoBehaviour
{
    [Header("Float Settings")]
    public float floatSpeed = 1f;
    public float floatAmount = 0.1f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        Vector3 offset = new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
        transform.localPosition = startPos + offset;
    }
}
