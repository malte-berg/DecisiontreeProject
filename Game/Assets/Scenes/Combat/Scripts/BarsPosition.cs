using UnityEngine;

public class BarsPosition : MonoBehaviour
{
    public Transform target; // The GameCharacter's transform
    public Vector3 offset = Vector3.up * 2f; // Offset above the character

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = screenPos;
        }
    }
}
