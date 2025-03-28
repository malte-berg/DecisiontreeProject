using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    float animationTime;

    void Update(){

        transform.GetChild(0).localPosition = Vector3.up * Mathf.Sin(animationTime) * 0.35f + (Vector3.up * 2.85f);
        animationTime += Time.deltaTime * 2.6f;

    }

}
