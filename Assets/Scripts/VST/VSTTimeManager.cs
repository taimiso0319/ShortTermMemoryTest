using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VSTTimeManager : MonoBehaviour {
   
    public int trueCount = 0;

    public GameObject CrossMark;
    public GameObject InputField;
    public GameObject InputNameText;
    public GameObject ReadMeText;
    public GameObject EndText;
    public GameObject ButtonPrefab;
    public GameObject ButtonParent;
    public GameObject[] trueButton;

	DataReader dtReader;
	public int charSize;
	public string[] charStr;
	private int trueCharSize;
	public int[] falseCharSize;
	public int[] trueRandNum;
    public int[,] falseRandNum;
    public int widthSize = 20;
    public int heightSize = 18;
    private int counter = 0;
    private int trueCounter = 0;
    private int trueObjectCounter = 0;
    
    public int defTimer = 30;
    public float timeCounter;
    private bool isStart = false;
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
        trueButton = new GameObject[trueCharSize];
		for(int i = 0;i < falseCharSize.Length;i++){
			falseCharSize[i] = (charSize - trueCharSize)/falseCharSize.Length;
		}
		trueRandNum = new int[trueCharSize];
        falseRandNum = new int[falseCharSize.Length, falseCharSize[0]];
        SetRandom();
        //LocalInstantiate();

        for(int h = 0;h < heightSize;h++) {
            for(int w = 0;w < widthSize;w++) {
                LocalInstantiate(new Vector3(-380f + (40 * w), 340f - (40 * h), 0), counter);
                counter++;
            }
        }

	}

	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return)&&!isStart) {
            CrossMark.SetActive(false);
            InputField.SetActive(false);
            InputNameText.SetActive(false);
            ReadMeText.SetActive(false);
            isStart = true;
            ButtonParent.SetActive(true);
        }
        for(int i = 0;i < trueButton.Length;i++) {
            if(trueButton[i].GetComponent<TextColorChanger>().isClicked) trueCounter++;
        }
        trueCount = trueCounter;
        trueCounter = 0;
	}

    void FixedUpdate(){
        if(isStart) {


            ////////////////////////////////////////////
            if((timeCounter -= Time.deltaTime) <= 0) {
                isStart = false;
                timeCounter = 0;
                ButtonParent.SetActive(false);
                EndText.SetActive(true);
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

    void LocalInstantiate(Vector3 vec,int count) {
        RectTransform rectTransform;
        GameObject tempGameObject;
        TextColorChanger txColorChanger;
        Text tx;
        tempGameObject = Instantiate(ButtonPrefab) as GameObject;
        tempGameObject.transform.parent = CrossMark.transform.parent;
        tx = tempGameObject.transform.FindChild("Text").GetComponent<Text>();
        txColorChanger = tempGameObject.transform.FindChild("Text").GetComponent<TextColorChanger>();
        rectTransform = tempGameObject.GetComponent<RectTransform>();
        for(int i = 0;i < trueRandNum.Length;i++) {
            if(trueRandNum[i] == count) {
                tx.text = charStr[0];
                txColorChanger.trueChar = true;
                trueButton[trueObjectCounter] = tempGameObject.transform.FindChild("Text").gameObject;
                trueObjectCounter++;
            }
        }
        for(int i = 0;i < falseCharSize.Length;i++) {
            for(int j = 0;j < falseCharSize[0];j++) {
                if(falseRandNum[i, j] == count) {
                    tx.text = charStr[i+1];
                    txColorChanger.trueChar = false;
                }
            }
        }
        rectTransform.localPosition = vec;
        tempGameObject.transform.parent = ButtonParent.transform;
    }
}
