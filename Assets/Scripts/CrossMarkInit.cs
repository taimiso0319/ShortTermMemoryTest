using UnityEngine;
using System.Collections;

public class CrossMarkInit : MonoBehaviour {

	public GameObject CrossMark;
	RectTransform rectTrans;
	// Use this for initialization
	void Start(){
		rectTrans = CrossMark.GetComponent<RectTransform>();
		rectTrans.position = new Vector3(Screen.width/2,Screen.height/2,0);
	}
	
	// Update is called once per frame
	void Update(){
	}
}
