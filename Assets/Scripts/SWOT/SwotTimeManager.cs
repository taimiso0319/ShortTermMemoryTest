using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwotTimeManager : MonoBehaviour {
	public float expTime = 3;
	public float restTime = 5;
	public float frameTimer = 0;

	public bool exp;

	public int count = 0;

	public bool isStart;
	public bool timeReset;

	public GameObject inputFieldObject;
	public GameObject inputName;
	private Text inputField;
	public ExcelWriter excWriter;
	public GameObject textObject;
	public GameObject crossObject;
	public ObjectChanger objChanger;
	public GameObject endText;

	public string[] strData = new string[4];
	public bool canInput;

	// Use this for initialization
	void Start () {
		inputField = inputFieldObject.transform.FindChild("Text").GetComponent<Text>();
		excWriter = GetComponent<ExcelWriter>();
		objChanger = GetComponent<ObjectChanger>();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Return)&&!isStart){
			if(inputField.text != ""){
				isStart = true;
				inputFieldObject.SetActive(false);
				inputName.SetActive(false);
				textObject.SetActive(false);
				crossObject.SetActive(false);
				excWriter.OpenWriter();
				exp = true;
			}
		}
		if(canInput){
			if(Input.GetKeyDown(KeyCode.Alpha1))strData[3] = "1";
			if(Input.GetKeyDown(KeyCode.Alpha2))strData[3] = "2";
			if(Input.GetKeyDown(KeyCode.Alpha3))strData[3] = "3";
			if(Input.GetKeyDown(KeyCode.Alpha4))strData[3] = "4";
			if(Input.GetKeyDown(KeyCode.Alpha5))strData[3] = "5";
			if(Input.GetKeyDown(KeyCode.Alpha6))strData[3] = "6";
			if(Input.GetKeyDown(KeyCode.Alpha7))strData[3] = "7";
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(exp&&isStart){
			if(crossObject.activeSelf)crossObject.SetActive(false);
			if(canInput)canInput = false;
			if(!objChanger.picsPlate[count].activeSelf)objChanger.picsPlate[count].SetActive(true);
			if(frameTimer>=expTime * 50){
				exp = !exp;
				timeReset = true;
			}
		}
		if(!exp&&isStart){
			if(!canInput)canInput = true;
			if(!crossObject.activeSelf)crossObject.SetActive(true);
			if(objChanger.picsPlate[count].activeSelf)objChanger.picsPlate[count].SetActive(false);
			if(frameTimer>=restTime * 50){
				SetStrData();
				excWriter.Writing(string.Join(",",strData));
				strData[3] = null;
				exp = !exp;
				count++;
				timeReset = true;
			}
		}
		if(count == 55&&isStart){
			isStart = false;
			if(!endText.activeSelf)endText.SetActive(true);
			excWriter.CloseWriter();

		}
		if(isStart)frameTimer++;
		if(timeReset){
			frameTimer = 0;
			timeReset = false;
		}
	}
	void SetStrData(){
		switch(objChanger.picsPlate[count].name.Substring(0,2)){
		case "00":strData[0] = "00"; strData[1] = "Red"; strData[2] = "Cylinder"; 	break;
		case "01":strData[0] = "01"; strData[1] = "Red"; strData[2] = "Corn"; 		break;
		case "02":strData[0] = "02"; strData[1] = "Red"; strData[2] = "Sphere";		break;
		case "03":strData[0] = "03"; strData[1] = "Red"; strData[2] = "Cube";		break;
		case "04":strData[0] = "04"; strData[1] = "Red"; strData[2] = "Piramid";    break;
		case "05":strData[0] = "05"; strData[1] = "Green"; strData[2] = "Cylinder"; break;
		case "06":strData[0] = "06"; strData[1] = "Green"; strData[2] = "Corn"; 	break;
		case "07":strData[0] = "07"; strData[1] = "Green"; strData[2] = "Sphere";	break;
		case "08":strData[0] = "08"; strData[1] = "Green"; strData[2] = "Cube";		break;
		case "09":strData[0] = "09"; strData[1] = "Green"; strData[2] = "Piramid";  break;
		case "10":strData[0] = "10"; strData[1] = "Blue"; strData[2] = "Cylinder"; 	break;
		case "11":strData[0] = "11"; strData[1] = "Blue"; strData[2] = "Corn"; 		break;
		case "12":strData[0] = "12"; strData[1] = "Blue"; strData[2] = "Sphere";	break;
		case "13":strData[0] = "13"; strData[1] = "Blue"; strData[2] = "Cube";		break;
		case "14":strData[0] = "14"; strData[1] = "Blue"; strData[2] = "Piramid";   break;
		case "15":strData[0] = "15"; strData[1] = "Pink"; strData[2] = "Cylinder"; 	break;
		case "16":strData[0] = "16"; strData[1] = "Pink"; strData[2] = "Corn"; 		break;
		case "17":strData[0] = "17"; strData[1] = "Pink"; strData[2] = "Sphere";	break;
		case "18":strData[0] = "18"; strData[1] = "Pink"; strData[2] = "Cube";		break;
		case "19":strData[0] = "19"; strData[1] = "Pink"; strData[2] = "Piramid";   break;
		case "20":strData[0] = "20"; strData[1] = "Yellow"; strData[2] = "Cylinder";break;
		case "21":strData[0] = "21"; strData[1] = "Yellow"; strData[2] = "Corn"; 	break;
		case "22":strData[0] = "22"; strData[1] = "Yellow"; strData[2] = "Sphere";	break;
		case "23":strData[0] = "23"; strData[1] = "Yellow"; strData[2] = "Cube";	break;
		case "24":strData[0] = "24"; strData[1] = "Yellow"; strData[2] = "Piramid"; break;
		case "25":strData[0] = "25"; strData[1] = "Orange"; strData[2] = "Cylinder";break;
		case "26":strData[0] = "26"; strData[1] = "Orange"; strData[2] = "Corn"; 	break;
		case "27":strData[0] = "27"; strData[1] = "Orange"; strData[2] = "Sphere";	break;
		case "28":strData[0] = "28"; strData[1] = "Orange"; strData[2] = "Cube";	break;
		case "29":strData[0] = "29"; strData[1] = "Orange"; strData[2] = "Piramid"; break;
		case "30":strData[0] = "30"; strData[1] = "Purple"; strData[2] = "Cylinder";break;
		case "31":strData[0] = "31"; strData[1] = "Purple"; strData[2] = "Corn"; 	break;
		case "32":strData[0] = "32"; strData[1] = "Purple"; strData[2] = "Sphere";	break;
		case "33":strData[0] = "33"; strData[1] = "Purple"; strData[2] = "Cube";	break;
		case "34":strData[0] = "34"; strData[1] = "Purple"; strData[2] = "Piramid"; break;
		case "35":strData[0] = "35"; strData[1] = "Brown"; strData[2] = "Cylinder"; break;
		case "36":strData[0] = "36"; strData[1] = "Brown"; strData[2] = "Corn"; 	break;
		case "37":strData[0] = "37"; strData[1] = "Brown"; strData[2] = "Sphere";	break;
		case "38":strData[0] = "38"; strData[1] = "Brown"; strData[2] = "Cube";		break;
		case "39":strData[0] = "39"; strData[1] = "Brown"; strData[2] = "Piramid";  break;
		case "40":strData[0] = "40"; strData[1] = "White"; strData[2] = "Cylinder"; break;
		case "41":strData[0] = "41"; strData[1] = "White"; strData[2] = "Corn"; 	break;
		case "42":strData[0] = "42"; strData[1] = "White"; strData[2] = "Sphere";	break;
		case "43":strData[0] = "43"; strData[1] = "White"; strData[2] = "Cube";		break;
		case "44":strData[0] = "44"; strData[1] = "White"; strData[2] = "Piramid";  break;
		case "45":strData[0] = "45"; strData[1] = "Black"; strData[2] = "Cylinder"; break;
		case "46":strData[0] = "46"; strData[1] = "Black"; strData[2] = "Corn"; 	break;
		case "47":strData[0] = "47"; strData[1] = "Black"; strData[2] = "Sphere";	break;
		case "48":strData[0] = "48"; strData[1] = "Black"; strData[2] = "Cube";		break;
		case "49":strData[0] = "49"; strData[1] = "Black"; strData[2] = "Piramid";  break;
		case "50":strData[0] = "50"; strData[1] = "Grey"; strData[2] = "Cylinder"; 	break;
		case "51":strData[0] = "51"; strData[1] = "Grey"; strData[2] = "Corn"; 		break;
		case "52":strData[0] = "52"; strData[1] = "Grey"; strData[2] = "Sphere";	break;
		case "53":strData[0] = "53"; strData[1] = "Grey"; strData[2] = "Cube";		break;
		case "54":strData[0] = "54"; strData[1] = "Grey"; strData[2] = "Piramid";   break;
		default:  break;
		}
	}
}
