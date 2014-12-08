using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextColorChanger : MonoBehaviour{

    public Color32 colorGreen = new Color32(0, 255, 0, 255);
    public Color32 colorRed = new Color32(0, 255, 0, 255);

    public bool trueChar = false;
    public bool isClicked = false;
    public float timer = 0;

    VSTTimeManager vst;

    void Start() {
		vst = GameObject.Find("SoftwareManager").GetComponent<VSTTimeManager>();
		timer = 0;
		vst.clickTime = 0;
    }

    void FixedUpdate() {
        if(vst.isStart) {
            timer += Time.deltaTime;
        }
    }

    public void SetColor() {
        Text tx = GetComponent<Text>();
		string writeStr;
        tx.color = colorRed;
        if(trueChar) {
            tx.color = colorGreen;
        }
		if(!isClicked){
			string[] tempStr = {trueChar.ToString(),(timer-vst.clickTime).ToString()};
			writeStr = string.Join(",",tempStr);
	        vst.exWriter.Writing(writeStr);
	        vst.clickTime = timer;
		}
		isClicked = true;
    }
}
