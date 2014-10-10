using UnityEngine;
using System.Collections;

public class ExpRandomer : MonoBehaviour {

	public bool[] rndBool = new bool[20];
	public int trueCount = 0;

	public int counter = 0;

	// Use this for initialization
	void Start(){
		for(int i = 0; i < rndBool.Length; i++)rndBool[i] = false;
	}

	public int RandomBool(){
		bool isLoop = true;
		int rndNum = 0;
		counter = 0;
		while(isLoop){
			rndNum = Random.Range(0,rndBool.Length);
			if(!rndBool[rndNum]||counter > rndBool.Length+50){
				rndBool[rndNum] = true;
				counter = 0;
				isLoop = false;
				trueCount++;
			}else{
				counter = 0;
				for(int i = 0;i < rndBool.Length;i++){
					if(rndBool[i])counter++;
				}
				if(counter == rndBool.Length)isLoop = false;
			}
		}
		return rndNum;
	}
}
