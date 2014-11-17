﻿using UnityEngine;
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

	// Use this for initialization
	void Start(){
		cubePlacer = (CubePlacer)GameObject.Find("SoftwareManager").GetComponent<CubePlacer>();
		areaText = InputArea.transform.FindChild("Text").GetComponent<Text>();
		System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory());

		if(stmt){
			if(!System.IO.Directory.Exists(@"Excels"))System.IO.Directory.CreateDirectory(@"Excels");
			if(!System.IO.Directory.Exists(@"Excels/Stmt"))System.IO.Directory.CreateDirectory(@"Excels/Stmt");
		}else if(!stmt){
			if(!System.IO.Directory.Exists(@"Excels"))System.IO.Directory.CreateDirectory(@"Excels");
			if(!System.IO.Directory.Exists(@"Excels/Swot"))System.IO.Directory.CreateDirectory(@"Excels/Swot");
		}
	}

	public void CloseWriter(){
		if(write){
			stWriter.Close();
		}
	}
	public void Writing(string str){
		if(write){
			stWriter.WriteLine(str);
		}
	}

	public void OpenWriter(){
		if(areaText.text=="")Application.LoadLevel(Application.loadedLevel);
		if(stmt){
			if(!System.IO.Directory.Exists(@"Excels/Stmt/"+areaText.text))System.IO.Directory.CreateDirectory(@"Excels/Stmt/"+areaText.text);
			stmtStr = @"Excels/Stmt/"+areaText.text+"/"+"Exp"+cubePlacer.objectNum.ToString()+"_"+
				System.DateTimeOffset.Now.Year.ToString()   +
					"年" +
					System.DateTimeOffset.Now.Month.ToString()  +
					"月" +
					System.DateTimeOffset.Now.Day.ToString()	+
					"日" +
					System.DateTimeOffset.Now.Hour.ToString() 	+
					"時" +
					System.DateTimeOffset.Now.Minute.ToString() +
					"分" +
					System.DateTimeOffset.Now.Second.ToString() +
					"秒" + ".csv";
		}
		else if(!stmt){
			if(!System.IO.Directory.Exists(@"Excels/Swot/"+areaText.text))System.IO.Directory.CreateDirectory(@"Excels/Swot/"+areaText.text);
			stmtStr = @"Excels/Swot/"+areaText.text+"/"+"Exp_"+
				System.DateTimeOffset.Now.Year.ToString()   +
					"年" +
					System.DateTimeOffset.Now.Month.ToString()  +
					"月" +
					System.DateTimeOffset.Now.Day.ToString()	+
					"日" +
					System.DateTimeOffset.Now.Hour.ToString() 	+
					"時" +
					System.DateTimeOffset.Now.Minute.ToString() +
					"分" +
					System.DateTimeOffset.Now.Second.ToString() +
					"秒" + ".csv";
		}
		if(!write){
			stWriter = new StreamWriter(stmtStr);
			write=!write;

		}
	}
}