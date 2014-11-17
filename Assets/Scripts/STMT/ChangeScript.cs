using UnityEngine;
using System.Collections;

public class ChangeScript : MonoBehaviour {

	CubePlacer cubePlacer;
	
	public int beChangeColor;
	public int changeColor;

	// Use this for initialization
	void Start(){
		cubePlacer = GetComponent<CubePlacer>();
	}

	// Update is called once per frame
	public void ChangeColorRand(){
		beChangeColor = Random.Range(0,cubePlacer.objectNum);
		changeColor = Random.Range(0,cubePlacer.unselectedColor.Length);
		localInstantiate(beChangeColor,changeColor);
	}

	void localInstantiate(int p,int f){
		GameObject localObject;
		localObject = Instantiate(cubePlacer.unplacedGameObject[f]) as GameObject;
		localObject.transform.position = cubePlacer.placedObject[p].transform.position;
		localObject.transform.parent = cubePlacer.CubesParent.transform;
		Destroy(cubePlacer.placedObject[p].gameObject);
	}
}
