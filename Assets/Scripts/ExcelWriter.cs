using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

public class ExcelWriter : MonoBehaviour {

	StreamWriter stWriter;
	CubePlacer cubePlacer;
	public GameObject InputArea;
	private string currentDir;
	private Text areaText;
	private bool write = false;
	public bool stmt = true;
	public string stmtStr = null;
	public string dirFolderName = null;

	void Awake(){
		System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory());
	}
	// Use this for initialization
	void Start(){
		if(dirFolderName==null)dirFolderName="Untitled";
		cubePlacer = (CubePlacer)GameObject.Find("SoftwareManager").GetComponent<CubePlacer>();
		areaText = InputArea.transform.FindChild("Text").GetComponent<Text>();
		if(!System.IO.Directory.Exists(@"Excels"))System.IO.Directory.CreateDirectory(@"Excels");
		if(!System.IO.Directory.Exists(@"Excels/"+dirFolderName))System.IO.Directory.CreateDirectory(@"Excels/"+dirFolderName);
	}
	public void CloseWriter(){
		if(write){
			stWriter.Close();
			write=false;
		}
	}
	public void Writing(string str){
		if(write){
			stWriter.WriteLine(str);
		}
	}

	public void OpenWriter() {
		if(!System.IO.Directory.Exists(@"Excels/" + dirFolderName + "/" + areaText.text)) System.IO.Directory.CreateDirectory(@"Excels/" + dirFolderName + "/" + areaText.text);
		stmtStr = @"Excels/" + dirFolderName + "/" + areaText.text + "/Date_" + "Exp_" +
			System.DateTimeOffset.Now.Year.ToString() +
				"年" +
				System.DateTimeOffset.Now.Month.ToString() +
				"月" +
				System.DateTimeOffset.Now.Day.ToString() +
				"日" +
				System.DateTimeOffset.Now.Hour.ToString() +
				"時" +
				System.DateTimeOffset.Now.Minute.ToString() +
				"分" +
				System.DateTimeOffset.Now.Second.ToString() +
				"秒" + ".csv";
		if(!write) {
			stWriter = new StreamWriter(stmtStr);
			write = true;
			
		}
	}
	public void OpenWriter(int testNum) {
		if(!System.IO.Directory.Exists(@"Excels/" + dirFolderName + "/" + areaText.text)) System.IO.Directory.CreateDirectory(@"Excels/" + dirFolderName + "/" + areaText.text);
		stmtStr = @"Excels/" + dirFolderName + "/" + areaText.text + "/Date_" +
			System.DateTimeOffset.Now.Year.ToString() +
				"年" +
				System.DateTimeOffset.Now.Month.ToString() +
				"月" +
				System.DateTimeOffset.Now.Day.ToString() +
				"日" +
				System.DateTimeOffset.Now.Hour.ToString() +
				"時" +
				System.DateTimeOffset.Now.Minute.ToString() +
				"分" +
				System.DateTimeOffset.Now.Second.ToString() +
				"秒" + "Exp_" + testNum.ToString() + ".csv";
		if(!write) {
			stWriter = new StreamWriter(stmtStr);
			write = true;
			
		}
	}
    public void OpenWriter(int times,string str) {
        if(!System.IO.Directory.Exists(@"Excels/" + dirFolderName + "/" + areaText.text)) System.IO.Directory.CreateDirectory(@"Excels/" + dirFolderName + "/" + areaText.text);
        stmtStr = @"Excels/" + dirFolderName + "/" + areaText.text + "/Date_" +
            System.DateTimeOffset.Now.Year.ToString() +
                "年" +
                System.DateTimeOffset.Now.Month.ToString() +
                "月" +
                System.DateTimeOffset.Now.Day.ToString() +
                "日" +
                System.DateTimeOffset.Now.Hour.ToString() +
                "時" +
                System.DateTimeOffset.Now.Minute.ToString() +
                "分" +
                System.DateTimeOffset.Now.Second.ToString() +
				"秒" + "_Exp_" + times + "_" + str + "_" + ".csv";
        if(!write) {
            stWriter = new StreamWriter(stmtStr);
            write = true;

        }
    }
}
