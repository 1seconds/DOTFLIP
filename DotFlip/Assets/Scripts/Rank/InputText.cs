using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputText : MonoBehaviour{

	public InputField input;
	public GameObject button;
	public Text btnText;
	public string userid = null;
	private GameObject target;
	public GameMenu gameMenu;
	public int oneCoinHighScene;

	WWWHelper helper;
	private string url = "http://ec2-52-78-232-193.ap-northeast-2.compute.amazonaws.com:3000/rank/";

	// Use this for initialization
	void Start()
	{
		GetOneCoinData();	// Get_oneCoinHighScene
		input = GetComponent<InputField>();
		input.onEndEdit.AddListener(End);
		input.onValueChanged.AddListener(SetSpace);
		helper = WWWHelper.Instance;
	}

	void SetSpace(string arg0){
		if(arg0 ==" "){
			input.text = null;
		}
	}
	void GetOneCoinData()
	{
		//oneCoinHighScene = PlayerPrefs.GetInt("oneCoinHighScene");
		oneCoinHighScene = PlayerPrefs.GetInt("clearScene");
		Debug.Log("clear oneCoinHighScene = " + oneCoinHighScene);
	}

	void End(string arg0)
	{
		Debug.Log(arg0);
		userid = arg0;
		int space=arg0.IndexOf(" ");
		Debug.Log(space);
		if(space != -1){
			Debug.Log("");
			gameMenu.Open("공백을 포함할 수 없습니다.");
			input.text = null;
			return;
		}
		//MessageBox.Show("test");
		//PlaceSelectionOnSurface.CreateWizard();
		if (arg0.Length >= 7)
		{
			input.text = null;
			gameMenu.Open("너무 길어요. 7글자 제한");
			return;
		}
		Debug.Log("clear Post Scene"+oneCoinHighScene.ToString());
		if (userid != null){
			helper.post(15, url, userid, oneCoinHighScene.ToString());
			button.SetActive(true);
		}
			

	}


}
