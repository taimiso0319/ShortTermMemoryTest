using UnityEngine;
using System.Collections;

public class CrossMarkInit : MonoBehaviour {

	public GameObject CrossMark;
	public GameObject InputArea;
	public GameObject InputName;
	public GameObject TestText;
	RectTransform rectTrans;
	// Use this for initialization
	void Start(){
		rectTrans = CrossMark.GetComponent<RectTransform>();
		rectTrans.position = new Vector3(Screen.width/2,Screen.height/2,0);
		rectTrans = InputArea.GetComponent<RectTransform>();
		rectTrans.position = new Vector3(Screen.width/2,Screen.height/2+40,0);
		rectTrans = InputName.GetComponent<RectTransform>();
		rectTrans.position = new Vector3(Screen.width/2,Screen.height/2+80,0);
		rectTrans = TestText.GetComponent<RectTransform>();
		rectTrans.position = new Vector3(Screen.width/2,Screen.height/2,0);
	}

}
