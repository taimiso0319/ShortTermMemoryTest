using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour {
	public float timer;
	public int frame;

	public int start = 25;
	public int place = 5;
	public int span = 45;
	public int change = 100;
	public bool isStart = false;

	public string testString = null;

	CubePlacer cubePlacer;
	ChangeScript changeScript;
	ExpRandomer expRand;
	ExcelWriter excWriter;
	string writeData;

	public GameObject testText;
	public GameObject crossHair;

	public bool isPlaced = false;
	public bool isChanged = false;
	public bool colorChange = false;
	public bool rnd = true;
	public bool isSelecting = false;
	public bool end = false;

	public string outputStr = "null";
	public string outputBoolStr = "";

	public GameObject inputFieldObject;
	public GameObject inputName;
	private Text inputField;
	// Use this for initialization
	void Start(){
		testText.SetActive(false);
		excWriter = GetComponent<ExcelWriter>();
		inputField = inputFieldObject.transform.Find("Text").GetComponent<Text>();
		cubePlacer = GetComponent<CubePlacer>();
		changeScript = GetComponent<ChangeScript>();
		expRand = GetComponent<ExpRandomer>();

		place += start;
		span += place;
		change += span;
		Debug.Log(inputField.text);
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Return)&&!isStart){
			if(inputField.text != ""){
				isStart = true;
				inputFieldObject.SetActive(false);
				inputName.SetActive(false);
				excWriter.OpenWriter(cubePlacer.objectNum);
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)&&isSelecting){
			testText.SetActive(false);
			if(colorChange){
				outputStr = "1";
			}
			else{
				outputStr = "0";
			}
			string[] tmpData = {
				outputStr,
				outputBoolStr
			};
			writeData = string.Join(",",tmpData);
			if(!end)excWriter.Writing(writeData);
			if(expRand.trueCount == 20){
				end = true;
				excWriter.CloseWriter();
				Application.LoadLevel(0);
			}
			frame = 0;
			isSelecting = false;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)&&isSelecting){
			testText.SetActive(false);
			if(!colorChange)outputStr = "1";
			else outputStr = "0";
			string[] tmpData = {
				outputStr,
				outputBoolStr
			};
			writeData = string.Join(",",tmpData);
			if(!end)excWriter.Writing(writeData);
			if(expRand.trueCount == 20){
				end = true;
				excWriter.CloseWriter();
				Application.LoadLevel(0);
			}
			frame = 0;
			isSelecting = false;
		}
	}

	void FixedUpdate(){
		if(end){
			frame = 1000;
		}
		if(!isStart){
			frame = 0;
		}
		if(0 <= frame && frame < start){
			isPlaced = false;
			isChanged = false;
			testString = "start";
			crossHair.SetActive(true);
		}
		if(start <= frame && frame < place){
			testString = "place";

			crossHair.SetActive(false);
			if(!isPlaced){
				cubePlacer.PlaceInit();
				cubePlacer.Place();
				isPlaced = !isPlaced;
			}
		}
		if(place <= frame && frame < span){
			testString = "span";
			for(int i = 0;i < cubePlacer.objectNum;i++){
				cubePlacer.placedObject[i].SetActive(false);
			}
			if(rnd){
				if(expRand.RandomBool() < 10){
					colorChange = true;
					outputBoolStr = "True";
				}else{ colorChange = false;
					outputBoolStr = "False";
				}
				rnd = false;
			}
		}
		if(span <= frame && frame < change){
			testString = "change";

			if(!isChanged){
				for(int i = 0;i < cubePlacer.objectNum;i++){
					cubePlacer.placedObject[i].SetActive(true);
				}

				if(colorChange)changeScript.ChangeColorRand();
				rnd = true;
				isChanged = !isChanged;
			}
		}
		if(change < frame){
			cubePlacer.destroCubes();
			testString = "select";
			testText.SetActive(true);
			isSelecting = true;

		}
		frame++;
		timer += Time.deltaTime;
	}
}
