using UnityEngine;
using System.Collections;

public class ObjectChanger : MonoBehaviour {

	public GameObject[] picsPlate = new GameObject[55];
	public Vector3 pos = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		ArrayRandomer(picsPlate);
	}

	void ArrayRandomer(GameObject[] gameObjectArray){
		int randNum;
		GameObject temp;
		for(int i = 0; i < gameObjectArray.Length; i++){
			randNum = Random.Range(0,gameObjectArray.Length);
			temp = gameObjectArray[i];
			gameObjectArray[i] = gameObjectArray[randNum];
			gameObjectArray[randNum] = temp;
		}
	}
}
