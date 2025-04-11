using UnityEngine;
using TMPro;

public class HoverPanelContent : MonoBehaviour {
    
    public TMP_Text skillTitle;
    public TMP_Text skillDesc;

    public void SetTitle(string title) {

        skillTitle.text = title;

    }

    public void SetDescription(string desc) {

        skillDesc.text = desc;

    }

}
