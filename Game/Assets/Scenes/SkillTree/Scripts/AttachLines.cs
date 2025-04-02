using UnityEngine;
using UnityEngine.UI;

public class AttachLines : MonoBehaviour{
    // The skillnodes we want to add a line between.
    public RectTransform startNode;

    public RectTransform endNode;

    public Image connectingLine;

    void Update()
    {
        if(startNode == null || endNode == null) return;

        // Get the radius of the skill nodes
        float startRadius = startNode.sizeDelta.x / 2;
        float endRadius = endNode.sizeDelta.x / 2;

        // Converts UI positions to World Space
        Vector3 startPos = startNode.position;
        Vector3 endPos = endNode.position;

        //Store direction and distance of the wanted line between nodes.
        Vector2 direction = endPos - startPos;



        float distance = direction.magnitude;

        // Set line position and size
        connectingLine.rectTransform.sizeDelta = new Vector2(distance, 5); // Width becomes distance, Height = fixed line thickness
        connectingLine.rectTransform.position = (startNode.position + endNode.position) / 2; // Centered between nodes

        // Rotate line to match direction
        connectingLine.rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
