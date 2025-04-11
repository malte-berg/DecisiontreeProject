using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{


    public GameObject hoverPanelPrefab;
    GameObject hoverPanelInstance;
    public Vector2 offset;

    string skillName;
    string skillDesc;

    Player player;

    void Init() {

        //player = GameObject.Find("Player").GetComponent<Player>();

    }

    void Awake() {

        Init();

    }

    public void OnPointerEnter(PointerEventData eventData) {

        if (hoverPanelPrefab != null && hoverPanelInstance == null) {

            hoverPanelInstance = Instantiate(hoverPanelPrefab, transform);

            skillName = GetComponentInChildren<TMP_Text>().text;
            hoverPanelInstance.GetComponent<HoverPanelContent>().SetTitle(skillName);

            //skillDesc =
            //hoverPanelInstance.transform.GetChild(2).gameObject.GetComponent<TMP_Text>.text = skillDesc;

            RectTransform buttonRect = GetComponent<RectTransform>();
            RectTransform panelRect = hoverPanelInstance.GetComponent<RectTransform>();

            Vector3[] buttonCorners = new Vector3[4];
            buttonRect.GetWorldCorners(buttonCorners);

            Vector3 targetPos = buttonCorners[0] + new Vector3(offset.x, offset.y, 0);

            panelRect.position = targetPos;
        }

    }

    public void OnPointerExit(PointerEventData eventData) {

        if (hoverPanelInstance != null) {

            Destroy(hoverPanelInstance);

        }

    }

}
