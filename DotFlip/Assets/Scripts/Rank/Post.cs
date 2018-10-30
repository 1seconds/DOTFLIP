using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.UI;

public class Post : MonoBehaviour {


	private string url3 = "ec2-52-78-232-193.ap-northeast-2.compute.amazonaws.com:3000/rank/";
	public InputText inputText;
	WWWHelper helper;
	private GameObject target;
	private Post post;
	Camera _mainCam = null;
	string userid;
	string score;
	public GameObject listview;

	// Use this for initialization
	void Start () {
		helper = WWWHelper.Instance;
		//helper.OnHttpRequest += OnHttpRequest;
		post = GetComponent<Post>();
		_mainCam = Camera.main;

	}
	private GameObject GetClickedObject()
	{
		//충돌이 감지된 영역
		RaycastHit hit;
		//찾은 오브젝트
		GameObject target = null;

		//마우스 포이트 근처 좌표를 만든다.
		Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

		//마우스 근처에 오브젝트가 있는지 확인
		if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
		{
			//있다!

			//있으면 오브젝트를 저장한다.
			target = hit.collider.gameObject;
		}

		return target;
	}

	// Update is called once per frame
	void Update () {
		userid = "eoghk";
		score = "15";
		if(Input.GetMouseButtonDown(0)){
			//target = GetClickedObject();
			if(inputText.userid != null)
				userid = inputText.userid;
			target = GetClickedObject();
			//if (target.tag == "Post")
			if (target != null){
				if (target.CompareTag("Post")){
					Debug.Log(userid);
					Debug.Log(score);
					helper.post(15, url3, userid, score);
				}
			}
		}
	}

	//void OnHttpRequest(int id, WWW www)
	//{
	//	Debug.Log("url id" + id);
	//	if (www.error != null)
	//	{
	//		Debug.Log("[Error] " + www.error);
	//	}
	//	else {

	//		//var data = new Data();
	//		//var user_1 = new user();
	//		//var mv = new movie();
	//		//Debug.Log(www.text);
	//		//int www_count = parseResponseCode(www.responseHeaders["STATUS"]);
	//		//Debug.Log("header" + www_count);
	//		//JsonData json = JsonMapper.ToObject(www.text);
	//		//int size = json.Count;
	//		//Debug.Log(size);
	//		//JsonData items = json[0];
	//		//for (int i = 0; i < size; i++)
	//		//{
	//		//	string temp = json[i]["Name"].ToString();
	//		//	Debug.Log(temp);
	//		//}
	

	//		//if (id == 200)
	//		//{


	//		//}

	//	}
	//}

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

}
