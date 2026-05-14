using UnityEngine;

public class HandStretch : MonoBehaviour
{
    [Header("Collect Settings")]
    public float collectRange = 3f;
    public KeyCode stretchKey = KeyCode.Mouse0;

    [Header("Visual Feedback")]
    public Transform handVisual;
    public float handStretchDistance = 1.5f;
    public float handReturnSpeed = 10f;

    private Vector3 handRestPosition;
    private bool isStretching;

    private void Start()
    {
        if (handVisual != null)
            handRestPosition = handVisual.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(stretchKey))
        {
            TryCollectTreasure();
            isStretching = true;
        }

        if (Input.GetKeyUp(stretchKey))
        {
            isStretching = false;
        }

        UpdateHandVisual();
    }

    private void TryCollectTreasure()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, Mathf.Max(0f, collectRange));

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Treasure"))
            {
                Treasure treasure = hit.GetComponent<Treasure>();
                if (treasure != null && !treasure.IsCollected)
                {
                    treasure.Collect();
                }
            }
        }
    }

    private void UpdateHandVisual()
    {
        if (handVisual == null)
            return;

        Vector3 targetPosition = isStretching
            ? handRestPosition + Vector3.forward * handStretchDistance
            : handRestPosition;

        handVisual.localPosition = Vector3.Lerp(
            handVisual.localPosition,
            targetPosition,
            handReturnSpeed * Time.deltaTime
        );
    }
}
