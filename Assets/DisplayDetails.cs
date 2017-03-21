using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayDetails : MonoBehaviour {
	List<string> detailsList;
	public int uiIndex;
	UIHandler uiscript;

	// Use this for initialization
	void Start () {
		//this.GetComponent<TextMesh>().text = "";
		detailsList = new List<string>();

		readTextFile("./details.txt");

		GameObject remoteDis = GameObject.Find("RemoteDisplay");
        uiscript = remoteDis.GetComponent<UIHandler>();
        uiIndex = uiscript.index;

		//changeDetails();
		wordWrap();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject remoteDis = GameObject.Find("RemoteDisplay");
        uiscript = remoteDis.GetComponent<UIHandler>();

		if(uiIndex != uiscript.index) {
			uiIndex = uiscript.index;
			changeDetails();
		}
	}

	void changeDetails() {
		//print(this.GetComponent<TextMesh>().text);
		this.GetComponent<TextMesh>().text = "";
		this.GetComponent<TextMesh>().text = wordWrap();
	}

	string wordWrap() {
		string builder = "";
     	TextMesh mesh = this.GetComponent<TextMesh>();
     	float rowLimit = 500.9f; //find the sweet spot    
     	string text = detailsList[uiIndex];
     	string[] parts = text.Split(' ');
		//print(parts.Length);
     	for (int i = 0; i < parts.Length; i++) 	{
      		//Debug.Log(parts[i]);
         	mesh.text += parts[i] + " ";
         	if (mesh.GetComponent<Renderer>().bounds.extents.x > rowLimit) 	{
         	    mesh.text = builder.TrimEnd() + System.Environment.NewLine + parts[i] + " ";
				//Debug.Log(mesh.text);
         	}
        	builder = mesh.text;
     	}
		return builder;
	}

	void readTextFile(string file_path)
	{
   		StreamReader inp_stm = new StreamReader(file_path);

   		while(!inp_stm.EndOfStream)
   		{
       		string inp_ln = inp_stm.ReadLine( );
       		detailsList.Add(inp_ln); 
   		}

   		inp_stm.Close( );  
	}
}
