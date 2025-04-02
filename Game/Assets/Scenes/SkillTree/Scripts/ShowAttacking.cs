using UnityEngine;
using UnityEngine.UI;

public class ShowAttacking : MonoBehaviour {

   public Button buttonA;
   public Button buttonB; 
   public Color newColor = Color.gray;

   void Start()
   {
      if (buttonA != null && buttonB != null)
      {
         buttonA.onClick.AddListener(ChangeButtonBColor);
      }
   }

   void ChangeButtonBColor()
   {
      buttonB.GetComponent<Image>().color = newColor;
   }

}
