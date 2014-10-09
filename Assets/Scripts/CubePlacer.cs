using UnityEngine;
using System.Collections;

public class CubePlacer : MonoBehaviour {

	public GameObject[] Cubes;
	public int objectNum = 2;
	public string[] selectedColor;
	public int trueCount = 0;
	public bool isLoopColor = true;
	public bool isLoopBool = true;
	public int loopFlag = 0;
	public bool[] rndPlaceBool;
	public int[] rndPlaceNum;
	public int counterBool = 0;

	//int testCount = 0;

	// Use this for initialization
	void Start(){
		selectedColor = new string[objectNum];
		rndPlaceBool = new bool[24];
		rndPlaceNum = new int[objectNum];		
		for(int i = 0;i < rndPlaceBool.Length;i++){
			rndPlaceBool[i] = false;
		}
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Return)){
			Place();
			//testCount++;
		}
	}
	// Update is called once per frame
	public void Place(){
		isLoopColor = true;
		while(isLoopColor){
			loopFlag = ColorSelect(objectNum);
			if(loopFlag == objectNum)isLoopColor = false;
		}
		for(int i = 0;i < objectNum;i++){
			rndPlace(objectNum,i);
		}
		for(int i = 0;i < rndPlaceBool.Length;i++){
			rndPlaceBool[i] = false;
		}
	}
	int ColorSelect(int cNum){
		int[] colorNum = new int[cNum];
		trueCount = 0;
		for(int c = 0; c < colorNum.Length;c++){
			colorNum[c] = 999;
		}
		for(int i = 0; i < cNum; i++){
			colorNum[i] = Random.Range(0,10);
			for(int j = 0; j < cNum; j++){
				if(colorNum[i]==colorNum[j])trueCount++;
			}
			ColorName(colorNum[i],i);
		}
		return trueCount;
	}
	void ColorName(int cNum, int arrayNum){
		switch(cNum){
		case 0:selectedColor[arrayNum] = "Red";			break;
		case 1:selectedColor[arrayNum] = "Orange";		break;
		case 2:selectedColor[arrayNum] = "Yellow";		break;
		case 3:selectedColor[arrayNum] = "LightGreen";	break;
		case 4:selectedColor[arrayNum] = "Green";		break;
		case 5:selectedColor[arrayNum] = "Emerald";		break;
		case 6:selectedColor[arrayNum] = "Blue";		break;
		case 7:selectedColor[arrayNum] = "DeepBlue";	break;
		case 8:selectedColor[arrayNum] = "Purple";		break;
		case 9:selectedColor[arrayNum] = "LightPurple";	break;
		default:break;
		}
	}
	void rndPlace(int cNum, int loopCount){
		isLoopBool = true;
		int rndNum;
		counterBool = 0;
		while(isLoopBool){
			rndNum = Random.Range(0,24);
			if(!rndPlaceBool[rndNum]){
				rndPlaceBool[rndNum] = true;
				rndPlaceNum[loopCount] = rndNum;
				isLoopBool = false;
			}else{
				counterBool = 0;
				for(int i = 0;i < objectNum;i++){
					if(rndPlaceBool[i])counterBool++;
				}
				if(counterBool == cNum)isLoopBool = false;
			}
		}	
	}
}
