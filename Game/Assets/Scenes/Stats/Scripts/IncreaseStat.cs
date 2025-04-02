using UnityEngine;
using UnityEngine.UI;

public class IncreaseStat : MonoBehaviour {
    [SerializeField] public GameObject statBar;

    public void Increase() {
        statBar.GetComponent<Slider>().value++;
    }
}
