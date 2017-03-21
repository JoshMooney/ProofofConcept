using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIHandler : MonoBehaviour {
	public List<GameObject> uiElements;
	public int index;

	Color orgColour;
	Color highlightColour;
	//public GameObject UI;

	// Use this for initialization
	void Start () {
		index = 0;
		uiElements = new List<GameObject>();
		getAllChildren();

		orgColour = uiElements[0].GetComponent<Renderer>().material.color;
		highlightColour = new Color(255.0f, 255.0f, 0.0f, 0.9f);



		//foreach(GameObject g in uiElements)
		//	print(g);

		uiElements[index].GetComponent<Renderer>().material.color = highlightColour;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveLeft() {
		if(index > 0) {
			uiElements[index].GetComponent<Renderer>().material.color = orgColour;
			index -= 1;
			uiElements[index].GetComponent<Renderer>().material.color = highlightColour;
		}
		else {
			Handheld.Vibrate();
		}
	}

	public void MoveRight() {
		if(index < uiElements.Count - 1) {
			uiElements[index].GetComponent<Renderer>().material.color = orgColour;
			index += 1;
			uiElements[index].GetComponent<Renderer>().material.color = highlightColour;
		}
		else {
			Handheld.Vibrate();
		}
	}

	void getAllChildren() {
		foreach (Transform child in transform)
             uiElements.Add(child.gameObject);
	}
}
