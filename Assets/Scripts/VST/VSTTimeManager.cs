using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VSTTimeManager : MonoBehaviour {
   
    public int trueCount = 0;
    public int falseCount = 0;

    public GameObject CrossMark;
    public GameObject InputField;
    public GameObject InputNameText;
    public GameObject ReadMeText;
    public GameObject EndText;
    public GameObject ButtonPrefab;
    public GameObject ButtonParent;
	public GameObject NextString;
    public GameObject[] buttonGameObject;

	private DataReader dtReader;
	private ImageWriter imgWriter;
	public string[] outPutStr;
    public ExcelWriter exWriter;
	public int charSize;
	public string[,] charStr;
	private int trueCharSize;
	public int[] falseCharSize;
	public int[] trueRandNum;
    public int[,] falseRandNum;
	public int[] randNum;
    public int widthSize = 20;
    public int heightSize = 18;
    private int counter = 0;
    private int trueCounter = 0;
    private int falseCounter = 0;
    private int trueObjectCounter = 0;

    public float clickTime = 0;

    public int defTimer = 30;
    public int spanTimer = 10;
    public int testTimes = 3;
    public int timesCount = 0;
	public float timeCounter;
	public bool isStart = false;
	public bool isEnd = false;
    private bool isFirstTimeEnd = false;
	public bool imgWriting = false; 
	// Use this for initialization
	void Start () {
		dtReader = GetComponent<DataReader>();
		exWriter = GetComponent<ExcelWriter>();
		imgWriter = GetComponent<ImageWriter>();
		charStr = new string[20,3];
		randNum = new int[testTimes];
		for(int i = 0;i < testTimes; i++){
			dtReader.OpenReader(i%4);
			Debug.Log(i%4);
			for(int j = 0;j < 3;j++){
				charStr[i,j] = (string)dtReader.arrayList[j];
			}
			randNum[i] = i;
		}
		outPutStr = new string[3];
        timeCounter = defTimer;
		ArrayRandom();
        InitStats(0);

	}

	void InitStats(int times) {
        counter = 0;
//        dtReader.OpenReader(dataNum);
        falseCharSize = new int[dtReader.arrayLength - 1];
//        charStr = new string[dtReader.arrayLength];
//
//        for(int i = 0;i < charStr.Length;i++) {
//            charStr[i] = (string)dtReader.arrayList[i];
//        }
        trueCharSize = (charSize * 2) / 45;
        buttonGameObject = new GameObject[charSize];
        for(int i = 0;i < falseCharSize.Length;i++) {
            falseCharSize[i] = (charSize - trueCharSize) / falseCharSize.Length;
        }
        trueRandNum = new int[trueCharSize];
        falseRandNum = new int[falseCharSize.Length, falseCharSize[0]];
        SetRandom();
        //LocalInstantiate();

        for(int h = 0;h < heightSize;h++) {
            for(int w = 0;w < widthSize;w++) {
                LocalInstantiate(new Vector3(-380f + (40 * w), 340f - (40 * h), 0), counter,timesCount);
                counter++;
            }
        }
		NextString.GetComponent<Text>().text = "探索する文字は" + charStr[randNum[times],0] + "です。";
		NextString.SetActive(true);
    }

    void DestroyCharObject() {
        for(int i = 0;i < buttonGameObject.Length;i++) {
            Destroy(buttonGameObject[i].transform.parent.gameObject);
        }    
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return)&&!isStart&&!isFirstTimeEnd) {
            CrossMark.SetActive(false);
            InputField.SetActive(false);
            InputNameText.SetActive(false);
            ReadMeText.SetActive(false);
            isStart = true;
            ButtonParent.SetActive(true);
			if(imgWriting)imgWriter.ScreenShot();
			for(int i = 0; i < outPutStr.Length; i++){
				outPutStr[i] = charStr[randNum[timesCount],i];
			}
			exWriter.OpenWriter(timesCount,string.Join("_",outPutStr));
			NextString.SetActive(false);
        }
        if(isStart){
            for(int i = 0;i < buttonGameObject.Length;i++) {
                if(buttonGameObject[i].GetComponent<TextColorChanger>().isClicked) {
                    if(buttonGameObject[i].GetComponent<TextColorChanger>().trueChar) trueCounter++;
                    if(!buttonGameObject[i].GetComponent<TextColorChanger>().trueChar) falseCounter++;
                }
            }
        }
        trueCount = trueCounter;
        falseCount = falseCounter;
        trueCounter = 0;
        falseCounter = 0;
	}

    void FixedUpdate(){
        if(isStart&&!isEnd) {
            ////////////////////////////////////////////
            if((timeCounter -= Time.deltaTime) <= 0) {
                isStart = false;
                timeCounter = spanTimer;
                DestroyCharObject();
                ButtonParent.SetActive(false);
				//EndText.SetActive(true);
				exWriter.Writing(trueCount.ToString());
				exWriter.Writing(falseCount.ToString());
				exWriter.CloseWriter();
                isFirstTimeEnd = true;
				timesCount++;
				if(timesCount!=testTimes){
					InitStats(timesCount);
					CrossMark.SetActive(true);
				}
            }
        }
		if(timesCount == testTimes){
			EndText.SetActive(true);
			isEnd = true;
		}
        if(!isStart && isFirstTimeEnd && !isEnd) {
			if((timeCounter -= Time.deltaTime) <= 0) {			
				for(int i = 0; i < outPutStr.Length; i++){
					outPutStr[i] = charStr[randNum[timesCount],i];
				}
                CrossMark.SetActive(false);
				exWriter.OpenWriter(timesCount,string.Join("_",outPutStr));
	            timeCounter = defTimer;
				ButtonParent.SetActive(true);
				if(imgWriting)imgWriter.ScreenShot();
				isStart = true;
            }
        }
    }

	void SetRandom(){
        int[] NumArray;
        int temp;
        int randNum;
        NumArray = new int[charSize];
        for(int i = 0;i < NumArray.Length;i++) NumArray[i] = i;
        for(int i = 0;i < NumArray.Length;i++) {
            randNum = Random.Range(0, NumArray.Length);
            temp = NumArray[i];
            NumArray[i] = NumArray[randNum];
            NumArray[randNum] = temp;
        }
        for(int i = 0;i < NumArray.Length;i++) {
            if(i < trueCharSize) {
                trueRandNum[i] = NumArray[i];
            }
            if(trueCharSize <= i && i < falseCharSize[0]+trueCharSize) {
                falseRandNum[0,i-trueCharSize] = NumArray[i];
            }
            if(falseCharSize[0]+trueCharSize <= i) {
                falseRandNum[1,i-(falseCharSize[0]+trueCharSize)] = NumArray[i];
            }
            Debug.Log(i);
        }
	}

    void LocalInstantiate(Vector3 vec,int count,int times) {
        RectTransform rectTransform;
        GameObject tempGameObject;
        TextColorChanger txColorChanger;
        Text tx;
        tempGameObject = Instantiate(ButtonPrefab) as GameObject;
        tempGameObject.transform.parent = CrossMark.transform.parent;
        tx = tempGameObject.transform.FindChild("Text").GetComponent<Text>();
        txColorChanger = tempGameObject.transform.FindChild("Text").GetComponent<TextColorChanger>();
        buttonGameObject[count] = tempGameObject.transform.FindChild("Text").gameObject;
        rectTransform = tempGameObject.GetComponent<RectTransform>();
        for(int i = 0;i < trueRandNum.Length;i++) {
            if(trueRandNum[i] == count) {
                tx.text = charStr[randNum[times],0];
                txColorChanger.trueChar = true;
                trueObjectCounter++;
            }
        }
        for(int i = 0;i < falseCharSize.Length;i++) {
            for(int j = 0;j < falseCharSize[0];j++) {
                if(falseRandNum[i, j] == count) {
                    tx.text = charStr[randNum[times],i+1];
                    txColorChanger.trueChar = false;
                }
            }
        }
        rectTransform.localPosition = vec;
        tempGameObject.transform.parent = ButtonParent.transform;
    }
	void ArrayRandom(){
		int tempRnd;
		int temp;
		for(int i = 0;i < testTimes;i++){
			tempRnd = Random.Range(0,testTimes);
			temp = randNum[i];
			randNum[i] = randNum[tempRnd];
			randNum[tempRnd] = temp;
		}
	}
}
