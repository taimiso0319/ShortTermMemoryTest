using UnityEngine;
using System.Collections;

public class ImageWriter : MonoBehaviour {

	private string format;

	public void Awake(){
		System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory());
		format = "yyyy-MM-dd-HH-mm-ss";
	}

	public void ScreenShot(){
		if(!System.IO.Directory.Exists(@"Img/"))System.IO.Directory.CreateDirectory(@"Img/");
		Application.CaptureScreenshot(@"Img/" + System.DateTime.Now.ToString(format) +".png");
	}
}
