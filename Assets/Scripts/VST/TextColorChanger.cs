using UnityEngine;using UnityEngine.UI;using System.Collections;public class TextColorChanger : MonoBehaviour {

    public Color32 colorGreen = new Color32(0, 255, 0, 255);
    public Color32 colorRed = new Color32(0, 255, 0, 255);    public bool trueChar = false;    public bool isClicked = false;    public void SetColor() {
        Text tx = GetComponent<Text>();
        tx.color = colorRed;        if(trueChar) {
            tx.color = colorGreen;
        }
        isClicked = true;    }}