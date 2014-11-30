using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class DataReader : MonoBehaviour {

	StreamReader stReader;
	private string dataStr = null;
	private bool isReading = false;
	public int arrayLength = 0;
	public ArrayList arrayList = new ArrayList();

	// Use this for initialization
	void Start () {
		System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory());
	}
	
	// Update is called once per frame
	public void OpenReader(){
		string ch = "";
		dataStr = @"Excels/char.data";
		if(!isReading){
			stReader = new StreamReader(dataStr,Encoding.GetEncoding("Shift_JIS"));
			isReading = true;
		}
		while((ch = stReader.ReadLine())!=null){
			arrayList.Add(ch);
			arrayLength++;
		}
		stReader.Close();
	}
}
