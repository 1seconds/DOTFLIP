using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : MonoBehaviour
{
	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 200, 100);
	// Only show it if needed.
	public bool show = false;
	private string msg;

	void OnGUI()
	{
		if (show)
			windowRect = GUI.Window(0, windowRect, DialogWindow, msg);
	}

	// This is the actual window.
	void DialogWindow(int windowID)
	{
		float y = 40;
		//GUI.Label(new Rect(5, y, windowRect.width, 20), "Again?");

		//if (GUI.Button(new Rect(5, y+120, windowRect.width - 10, 20+120), "Restart"))
		//{
		//	Application.LoadLevel(0);
		//	show = false;
		//}

		if (GUI.Button(new Rect(5, y, windowRect.width - 10, 40), "확인"))
		{
			show = false;
		}
		//GUI.Label(new Rect(5, y, windowRect.width, 20), "Again?");

	}

	// To open the dialogue from outside of the script.
	public void Open(string _msg)
	{
		Debug.Log(_msg);
		msg = _msg;
		Debug.Log(msg);
		show = true;
	}
}