using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public Dropdown myDropdown;
	public Load load;
	public int highScene=0;
	string Scene;

	// Use this for initialization
	void Start () {
		myDropdown = GetComponent<Dropdown> ();
		GetData ();

		for (int i = 1; i < highScene+1; i++) {
			Scene="0";
			if (i < 10)
				Scene += i.ToString ();
			else
				Scene = i.ToString ();
			myDropdown.options.Add(new Dropdown.OptionData() {text=Scene});
		}

		myDropdown.onValueChanged.AddListener(DropdownValueChange);
	}
	
	void GetData(){
		highScene = PlayerPrefs.GetInt("HighScene");

	}
	public void DropdownValueChange(int value){
		value++;
		load.index = value;
	
	}


}
