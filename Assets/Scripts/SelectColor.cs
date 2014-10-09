using UnityEngine;
using System.Collections;

public class SelectColor : MonoBehaviour {

	string SelectColorName(){
		int randomNum;
		string color = null;
		randomNum = Random.Range(0,10);
		switch(randomNum){
		case 0:color = "Red";			break;
		case 1:color = "Orange";		break;
		case 2:color = "Yellow";		break;
		case 3:color = "LightGreen";	break;
		case 4:color = "Green";		break;
		case 5:color = "Emerald";		break;
		case 6:color = "Blue";		break;
		case 7:color = "DeepBlue";	break;
		case 8:color = "Purple";		break;
		case 9:color = "LightPurple";	break;
		default: break;
		}
		return color;
	}
}
