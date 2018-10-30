using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;
using System;

public class RankScript : MonoBehaviour
{

    SoundManager soundmanager;
	public GameObject panel;		//Ranking Panel
	public Text myRankingText;		//RankingPanel in Text
	public GameObject canvas;		//Ranking Canvas
	public GameObject oneCoinCanvas;
	public GameObject input;		//InputFild
	public GameObject button;		//Ranking Button -> InitOneCoinBtn()
	public Text btnText;			//button.text
	string url = "http://ec2-52-78-232-193.ap-northeast-2.compute.amazonaws.com:3000/rank/";
	public GameObject listview;		//Ranking ListView
	public Tuple[] tuples;			//listview tuple;

	string temp_name;				// parsing
	string temp_score;				// parsing
	string temp_rank;				// parsing
	WWWHelper helper;				// http
	bool _get=true;					// http_get 
	bool panelActive = false;		// RankingPanel Active
	public int oneCoinCurrentScene;	//
	public int oneCoinHighScene;
	private int oneCoinEnd;			// 원코인 종료 1 = 종료 / 0 =시작  이 변수 값에 따라 canvas 달라 진다.
	private int oneCoinBest;        // 원코인 기록 중 최고 기록 

    public Text Debugtext;

    void Start()
    {
		GetOneCoinData();
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
		helper = WWWHelper.Instance;
		tuples = listview.transform.GetComponentsInChildren<Tuple>();
		helper.OnHttpRequest += OnHttpRequest;
		if(oneCoinEnd==1){
			canvas.SetActive(false);
			oneCoinCanvas.SetActive(true);
		}
		else{
			canvas.SetActive(true);
			oneCoinCanvas.SetActive(false);
		}
    }
    public void Back()
    {
        //GameObject.FindWithTag("MainCamera").GetComponent<PrefabController>().GetData();
        soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
        SceneManager.LoadScene("00");

        GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().ballCntDisplay.transform.position = new Vector3(1280, 710, 0); ;
        GameObject.FindWithTag("MainCamera").GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();
    }
	public void GetRanking(){
		if (panelActive == false)
		{
			panel.SetActive(true);
			panelActive = true;
		}else{
			panel.SetActive(false);
			panelActive = false;
		}
		if(_get)
			helper.get(10, url);
		StartCoroutine("Get");
	}
	IEnumerator Get()
	{
		
		_get = false;
		yield return new WaitForSeconds(30.0f);
		_get = true;

	}
	/*Header Parsing */
	public static int parseResponseCode(string statusLine)
	{
		int ret = 0;

		string[] components = statusLine.Split(' ');
		if (components.Length < 3)
		{
			Debug.LogError("invalid response status: " + statusLine);
		}
		else {
			if (!int.TryParse(components[1], out ret))
			{
				Debug.LogError("invalid response code: " + components[1]);
			}
		}

		return ret;
	}

  //  public void OneCoinModeStart()
  //  {
  //      soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
  //      //GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().isOneCoinMode = true;
  //      InGameManager.isStartScene = false;
  //      GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().enabled = true;
  //      GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().deleteBtn.SetActive(true);
  //      GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().settingBtn.SetActive(true);
		//if (oneCoinHighScene == 0)
		//{
		//	PlayerPrefs.SetInt("oneCoinHighScene", 2);
		//	oneCoinHighScene = 2;
		//}

  //      if (oneCoinHighScene < 10)
		//	SceneManager.LoadScene("0" + oneCoinHighScene.ToString());
		//else
		//	SceneManager.LoadScene(oneCoinHighScene.ToString());
        
  //  }
	void SetListView(int n, string userName, string userScore, string userRank)
	{
		Debug.Log(n);
		tuples[n].setUserId(userName);
		tuples[n].setScore(userScore);
		tuples[n].setRank(userRank);
	}
	/* OneCoin End, Init */
	public void InitOneCoinBtn(){
		PlayerPrefs.SetInt("oneCoinEnd", 0);
		SceneManager.LoadScene("Rank");
	}
	/* 내부 DB*/
	void GetOneCoinData()
	{
		oneCoinEnd = PlayerPrefs.GetInt("oneCoinEnd");
		oneCoinHighScene = PlayerPrefs.GetInt("oneCoinHighScene");
		oneCoinBest = PlayerPrefs.GetInt("oneCoinBest");
		//Debug.Log("oneCoinHighScene = "+oneCoinHighScene);
	}
	/* Get/Post Parsing */
	void OnHttpRequest(int id, WWW www)
	{
		Debug.Log("url id" + id);
		if (www.error != null)
		{
			Debug.Log("[Error] " + www.error);
			Debugtext.text = www.error;
		}
		else {

			if (id == 10)
			{
				var data = new Data();
				var user_1 = new user();
				var mv = new movie();
				Debug.Log(www.text);
				int www_code = parseResponseCode(www.responseHeaders["STATUS"]);
				Debug.Log("header" + www_code);
				if (www_code == 200)
				{//response code 200 is Success
					//Debugtext.text = "200";
					JsonData json = JsonMapper.ToObject(www.text);
					int size = json.Count;
					Debug.Log(size);
					JsonData items = json[0];
					for (int i = 0; i < 10; i++)
					{
						if (json[i] != null)
						{
							//Debugtext.text = json[i]["name"].ToString();
							SetListView(i, json[i]["name"].ToString(), json[i]["score"].ToString(), json[i]["rank"].ToString());

						}
					}//for
					myRankingText.text = "My top ranking is " + oneCoinBest.ToString();
				}//if

			}//if id==10

			if (id == 15)
			{
				int www_code = parseResponseCode(www.responseHeaders["STATUS"]);
				Debug.Log("header" + www_code);
				if (www_code == 200)
				{
					JsonData json = JsonMapper.ToObject(www.text);
					int size = json.Count;
					Debug.Log(size);
					JsonData items = json[0];
					for (int i = 0; i < size; i++)
					{
						if (json[i]["Count(*)+1"] != null)
						{
							string temp = json[i]["Count(*)+1"].ToString();
							Debug.Log(temp);
							btnText.text = "My Ranking is ";
							btnText.text += temp;
							if(oneCoinBest<int.Parse(temp)){
								PlayerPrefs.SetInt("oneCoinBest", int.Parse(temp));
								myRankingText.text="my top ranking is"+temp;
							}
						}//if
					}//for
				}//if
				else {
					// id 중복
				}
			}// if id 15

		}
	}
}
