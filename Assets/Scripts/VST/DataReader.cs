using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class DataReader : MonoBehaviour {

	StreamReader stReader;
	private string dataStr = null;
	private bool isReading = false;
	public int arrayLength;
	public ArrayList arrayList;

	// Use this for initialization
	void Start () {
		System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory());
	}
	
	// Update is called once per frame
	public void OpenReader(int dataNum){
        string ch = ""; 
        arrayLength = 0;
        arrayList = new ArrayList();
		dataStr = @"Excels/char"+ dataNum.ToString() +".data";
		stReader = new StreamReader(dataStr,Encoding.GetEncoding("Shift_JIS"));
		while((ch = stReader.ReadLine())!=null){
			arrayList.Add(ch);
			arrayLength++;
		}
		stReader.Close();
	}
}
