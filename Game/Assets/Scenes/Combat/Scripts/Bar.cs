using UnityEngine;

public class Bar : MonoBehaviour
{
    public Transform target;
    public float yOffset = 2f;

    protected virtual void Start()
    {
        if (target == null)
        {
            Debug.LogError($"{GetType().Name}: No target assigned.");
            enabled = false;
        }
    }

    protected virtual void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + Vector3.up * yOffset);
            transform.position = screenPos;
        }
    }
}
