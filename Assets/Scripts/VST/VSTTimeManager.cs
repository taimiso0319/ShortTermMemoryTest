using UnityEngine;
using System.Collections;

public class VSTTimeManager : MonoBehaviour {

    public GameObject CrossMark;
    public GameObject InputField;
    public GameObject InputNameText;
    public GameObject ReadMeText;

	DataReader dtReader;
	public int charSize;
	public string[] charStr;
	private int trueCharSize;
	private int[] falseCharSize;
	private int[] trueRandNum;
	private int[,] falseRandNum;
    
    public int defTimer = 30;
    public float timeCounter;
    private bool isStart = false, isEnd = false;
	// Use this for initialization
	void Start () {
        timeCounter = defTimer;
		dtReader = GetComponent<DataReader>();
		dtReader.OpenReader();
		falseCharSize = new int[dtReader.arrayLength-1];
		charStr = new string[dtReader.arrayLength];

		for(int i = 0;i < charStr.Length;i++){
			charStr[i] = (string)dtReader.arrayList[i];
		}
		trueCharSize = (charSize*2)/45;
		for(int i = 0;i < falseCharSize.Length;i++){
			falseCharSize[i] = (charSize - trueCharSize)/falseCharSize.Length;
		}
		trueRandNum = new int[trueCharSize];
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate(){



        ////////////////////////////////////////////
        if((timeCounter -= Time.deltaTime) < 0) {
            isEnd = true;   
        }
        
    }

	void SetRandom(){

	}
}
