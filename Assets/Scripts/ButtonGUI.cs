using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonGUI : MonoBehaviour {
	public GameObject[] Buttons = new GameObject[4];
	public RectTransform[] rectTrans;
	public Button[] btn;
	// Use this for initialization
	void Start(){
		rectTrans = new RectTransform[Buttons.Length];
		btn = new Button[4];
		for(int i = 0;i < Buttons.Length;i++){
			rectTrans[i] = (RectTransform)Buttons[i].GetComponent<RectTransform>();
			btn[i] = (Button)Buttons[i].GetComponent<Button>();
		}
		btn[0].onClick.AddListener(() => {SceneChanger(0);});
		btn[1].onClick.AddListener(() => {SceneChanger(1);});
		btn[2].onClick.AddListener(() => {SceneChanger(2);});
		btn[3].onClick.AddListener(() => {SceneChanger(3);});
	}
	
	// Update is called once per frame
	void Update(){
		rectTrans[0].position = new Vector3(Screen.width/4,Screen.height/4*3,0);
		rectTrans[1].position = new Vector3(Screen.width/4*3,Screen.height/4*3,0);
		rectTrans[2].position = new Vector3(Screen.width/4,Screen.height/4,0);
		rectTrans[3].position = new Vector3(Screen.width/4*3,Screen.height/4,0);
	}

	void SceneChanger(int i){
		switch(i){
		case 0:
			Application.LoadLevel(1);
				break;
		case 1:
			Application.LoadLevel(2);
				break;
		case 2:
			Application.LoadLevel(3);
				break;
		case 3:
			Application.LoadLevel(4);
				break;
		}
	}
}
