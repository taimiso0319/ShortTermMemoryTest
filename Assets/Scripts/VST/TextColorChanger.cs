using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextColorChanger : MonoBehaviour {

    public Color32 color32 = new Color32(0,255,0,255);
    public bool trueChar = false;
    public bool isClicked = false;

    public void SetColor() {
        Text tx = GetComponent<Text>();
        if(trueChar) {
            tx.color = color32;
            isClicked = true;
        }
    }
}
