using UnityEngine;
using System.Collections;

public class CubePlacer : MonoBehaviour {

	public GameObject mainCamera;

	public GameObject[] Cubes;

	public GameObject CubesParent;
	public int objectNum = 2;
	public string[] selectedColor;
	public string[] unselectedColor;
	public bool[] selectedColorBool;
	public int trueCount = 0;
	public bool isLoopColor = true;
	public bool isLoopBool = true;
	public int loopFlag = 0;
	public bool[] rndPlaceBool;
	public int[] rndPlaceNum;
	public int counterBool = 0;
	public GameObject[] destroyObject;

	private int instX;
	private int instY;

	private Vector3[,] cubePos;
	public GameObject[] placedObject;
	public GameObject[] unplacedGameObject;

	//int testCount = 0;

	// Use this for initialization
	void Start(){
		destroyObject = new GameObject[objectNum];
		selectedColor = new string[Cubes.Length];
		selectedColorBool = new bool[Cubes.Length];
		placedObject = new GameObject[objectNum];
		unplacedGameObject = new GameObject[10 - objectNum];
		rndPlaceBool = new bool[24];
		cubePos = new Vector3[6,4];
		rndPlaceNum = new int[objectNum];
		unselectedColor = new string[10 - objectNum];
		for(int i = 0;i < rndPlaceBool.Length;i++){
			rndPlaceBool[i] = false;
		}
		for(int x = 0; x < 6;x++){
			for(int y = 0;y < 4;y++){
				cubePos[x,y] = new Vector3(Screen.width/12+(Screen.width/6*x),(Screen.height/8+Screen.height/4*y),0);
			}
		}

	}
	// Update is called once per frame
	public void PlaceInit(){
		CubesParent = new GameObject("CubesParent");
		isLoopColor = true;
		for(int i = 0; i < selectedColorBool.Length;i++){
			selectedColorBool[i] = false;
		}
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

	public void Place(){
		for(int i = 0; i < objectNum; i++){
			Debug.Log(rndPlaceNum[i]);
			switch(rndPlaceNum[i]){
			case 0: instX = 0; instY = 0; break;
			case 1: instX = 0; instY = 1; break;
			case 2: instX = 0; instY = 2; break;
			case 3: instX = 0; instY = 3; break;
			case 4: instX = 1; instY = 0; break;
			case 5: instX = 1; instY = 1; break;
			case 6: instX = 1; instY = 2; break;
			case 7: instX = 1; instY = 3; break;
			case 8: instX = 2; instY = 0; break;
			case 9: instX = 2; instY = 1; break;
			case 10: instX = 2; instY = 2; break;
			case 11: instX = 2; instY = 3; break;
			case 12: instX = 3; instY = 0; break;
			case 13: instX = 3; instY = 1; break;
			case 14: instX = 3; instY = 2; break;
			case 15: instX = 3; instY = 3; break;
			case 16: instX = 4; instY = 0; break;
			case 17: instX = 4; instY = 1; break;
			case 18: instX = 4; instY = 2; break;
			case 19: instX = 4; instY = 3; break;
			case 20: instX = 5; instY = 0; break;
			case 21: instX = 5; instY = 1; break;
			case 22: instX = 5; instY = 2; break;
			case 23: instX = 5; instY = 3; break;
			default:break;
			}
			Debug.Log(instX);
			localInstatiate(cubePos[instX,instY],selectedColor[i],i);
		}
		unselectedColorString();
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
		case 0:selectedColor[arrayNum] = "Red";	break;
		case 1:selectedColor[arrayNum] = "Orange";	break;
		case 2:selectedColor[arrayNum] = "Yellow";	break;
		case 3:selectedColor[arrayNum] = "LightGreen";	break;
		case 4:selectedColor[arrayNum] = "Green";			break;
		case 5:selectedColor[arrayNum] = "Emerald";		break;
		case 6:selectedColor[arrayNum] = "Blue";		break;
		case 7:selectedColor[arrayNum] = "DeepBlue";    break;
		case 8:selectedColor[arrayNum] = "Purple";	   	break;
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

	void localInstatiate(Vector3 vec,string cName, int i){
		GameObject instGameObject;
		int cNum = 999;
		switch(cName){
		case "Red":			cNum = 0;break;
		case "Orange":		cNum = 1;break;
		case "Yellow":		cNum = 2;break;
		case "LightGreen":	cNum = 3;break;
		case "Green":		cNum = 4;break;
		case "Emerald":		cNum = 5;break;
		case "Blue":		cNum = 6;break;
		case "DeepBlue":	cNum = 7;break;
		case "Purple":		cNum = 8;break;
		case "LightPurple":	cNum = 9;break;
		default:break;
		}
		if(cNum != 999){
			instGameObject = Instantiate(Cubes[cNum]) as GameObject;
			instGameObject.transform.position = mainCamera.camera.ScreenToWorldPoint(vec) + new Vector3(0,0,5);
			instGameObject.transform.parent = CubesParent.transform;
			placedObject[i] = instGameObject;
		}
	}

	void unselectedColorString(){
		for(int i = 0;i < selectedColorBool.Length;i++){
			switch(selectedColor[i]){
			case "Red":			selectedColorBool[0] = true;break;
			case "Orange":		selectedColorBool[1] = true;break;
			case "Yellow":		selectedColorBool[2] = true;break;
			case "LightGreen":	selectedColorBool[3] = true;break;
			case "Green":		selectedColorBool[4] = true;break;
			case "Emerald":		selectedColorBool[5] = true;break;
			case "Blue":		selectedColorBool[6] = true;break;
			case "DeepBlue":	selectedColorBool[7] = true;break;
			case "Purple":		selectedColorBool[8] = true;break;
			case "LightPurple":	selectedColorBool[9] = true;break;
			default:break;
			}
		}

		int sC = 0;
		for(int i = 0; i < selectedColorBool.Length;i++){
			if(!selectedColorBool[i]){
				switch(i){
				case 0 :unselectedColor[sC]="Red"; 			unplacedGameObject[sC] = Cubes[0]; break;
				case 1 :unselectedColor[sC]="Orange";		unplacedGameObject[sC] = Cubes[1]; break;
				case 2 :unselectedColor[sC]="Yellow";		unplacedGameObject[sC] = Cubes[2]; break;
				case 3 :unselectedColor[sC]="LightGreen";	unplacedGameObject[sC] = Cubes[3]; break;
				case 4 :unselectedColor[sC]="Green";		unplacedGameObject[sC] = Cubes[4]; break;
				case 5 :unselectedColor[sC]="Emerald";		unplacedGameObject[sC] = Cubes[5]; break;
				case 6 :unselectedColor[sC]="Blue";			unplacedGameObject[sC] = Cubes[6]; break;
				case 7 :unselectedColor[sC]="DeepBlue";		unplacedGameObject[sC] = Cubes[7]; break;
				case 8 :unselectedColor[sC]="Purple";		unplacedGameObject[sC] = Cubes[8]; break;
				case 9 :unselectedColor[sC]="LightPurple";	unplacedGameObject[sC] = Cubes[9]; break;
				default:break;
				}
				sC++;
			}
		}
	}
	
	public void destroCubes(){
		Destroy(CubesParent.gameObject);
	}

}
