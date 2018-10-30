using UnityEngine;
using System.Collections;

public class SaveScene : MonoBehaviour {

	int highScene;
	int currentScene;

	// Use this for initialization
	void Start () {
	
	}
	
	void SaveData(){
		if(currentScene >highScene)
			PlayerPrefs.SetInt ("HighScene",currentScene);
	}

	void GetData(){
		highScene = PlayerPrefs.GetInt ("HighScene");
	}
}
