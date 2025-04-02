using UnityEngine;
using UnityEngine.UI;

public class DecreaseStat : MonoBehaviour {
    [SerializeField] public GameObject statBar;

    public void Decrease() {
        statBar.GetComponent<Slider>().value--;
    }
}
