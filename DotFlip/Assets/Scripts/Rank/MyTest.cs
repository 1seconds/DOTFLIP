using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class user
{
	public int memIdx;
	public string uid;
	public string upw;
	public string regData;
	public string name;
}

public class test{
	public int memIdx{ get;set;}
	public string uid{ get; set; }
	public string upw{ get; set; }
	public string regData{ get; set; }
	public string name{ get; set; }
}
public class movie{
	public string title;

}

class Data
{
	public int code;
	public string msg;
	//public user[] users;
	public List<user> users;
//	public ArrayList<user> temp;
	//public string users;
	//public ArrayList<int> ar = new ArrayList<int>();
	//public ArrayList<user> users;
}


/*
 * 
 * {"code":1,"msg":"Victory",
 * "users":[{"memIdx":1,"uid":"test","upw":"1234","regDate":"2000-01-01 00:00:01.0","name":"한글"}]}
*/




public class MyTest : MonoBehaviour
{

	string url = "http://itpaper.co.kr/demo/unity/items/item.json";
	string url2 = "http://ec2-52-42-87-136.us-west-2.compute.amazonaws.com/t/login";
	string url3 = "ec2-52-78-232-193.ap-northeast-2.compute.amazonaws.com:3000/rank/";
	// Use this for initialization
	public GameObject listview;
	public GameObject[] list;
	public Tuple[] tuples;
	string temp_name;
	string temp_score;
	string temp_rank;

	void Start()
	{
		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		//helper.get(100, url);
		//helper.subpost(1000,url2,"test","123");
		helper.get(10, url3);
		ListView();
	}
	void Postgogo(){
		WWWHelper helper = WWWHelper.Instance;
		helper.subpost(200, url3, "userid", "score");
	}
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
	void ListView(){
		//list = listview.transform.GetComponentsInChildren<GameObject>();
		tuples = listview.transform.GetComponentsInChildren<Tuple>();
		Debug.Log("sizeok?"+tuples.Length);
		for (int i = 0; i < tuples.Length; i++)
		{
			tuples[i].setUserId("ok");
			tuples[i].setScore("ok");
			tuples[i].setRank("ok");
		}
		//list 
	}
	void SetListView(int n,string userName,string userScore,string userRank){
		tuples[n].setUserId(userName);
		tuples[n].setScore(userScore);
		tuples[n].setRank(userRank);
	}

	void OnHttpRequest(int id, WWW www)
	{
		Debug.Log("url id"+id);
		if (www.error != null){
			Debug.Log("[Error] " + www.error);
		}
		else {

			if (id == 10){
				var data = new Data();
				var user_1 = new user();
				var mv = new movie();
				Debug.Log(www.text);
				int www_code = parseResponseCode(www.responseHeaders["STATUS"]);
				Debug.Log("header" + www_code);
				if (www_code == 200){//response code 200 is Success
					JsonData json = JsonMapper.ToObject(www.text);
					int size = json.Count;
					Debug.Log(size);
					JsonData items = json[0];
					for (int i = 0; i < size; i++){
						if (json[i]!= null){

							SetListView(i,json[i]["name"].ToString(),json[i]["score"].ToString(),json[i]["rank"].ToString());

						}
					}//for
				}//if

			}//if

			//			JsonData json = JsonMapper.ToObject(www.text);
			//			JsonData items = json["title"];
			//mv = JsonUtility.FromJson<movie>(www.text);
			//Debug.Log(mv.title);
			//JsonUtility.FromJsonOverwrite(www.text, data);
			//Debug.Log(data.msg);
			//Debug.Log(data.code);
			/*
			JsonData json = JsonMapper.ToObject(www.text);
			JsonData items = json["users"];
			int size = json["users"].Count;
			Debug.Log("Size"+size);
			int count = items.Count;
			for (int i = 0; i < count; i++){
				//JsonData item = items[i];
				//string dname = item["uid"].ToString();
				//Debug.Log(dname);
				string row = items[i].ToJson();
				test user_2 = JsonMapper.ToObject<test>(row);
				Debug.Log(user_2.uid);
				Debug.Log(user_2.upw);
				//Debug.Log(user_2.ToString());
			}
*/
			//JsonData json = JsonMapper.ToObject(www.text);
			//JsonData items = json["title"];
			//int size = json["title"].Count;
			//Debug.Log("Size" + size);
			//int count = items.Count;
			//var mv = new movie();
			//for (int i = 0; i < count; i++)
			//{
			//	//JsonData item = items[i];
			//	//string dname = item["uid"].ToString();
			//	//Debug.Log(dname);
			//	string row = items[i].ToJson();
			//	movie mv = JsonMapper.ToObject<movie>(row);
			//	Debug.Log(mv.title);
			//	//Debug.Log(user_2.ToString());
			//}


			//data=JsonUtility.FromJson<Data>(www.text);
			//List<user> userlist = new List<user>();
			//Debug.Log(data.msg);
			//Debug.Log(data.code);
			//if (data.users != null)
			//	Debug.Log("hi");
			//user_1 = JsonUtility.FromJson<user>(data.users);
			//Debug.Log(data.users);
			//userlist = data.users;
			//Debug.Log(data.users);

			//if(userlist !=null){
			//	Debug.Log("come");
			//}



			//Debug.Log(data.users.ToString());
			//user_1 = data.users[0];
			//JsonUtility.FromJson(www)         ;

			if (id ==15){
				int www_code = parseResponseCode(www.responseHeaders["STATUS"]);
				Debug.Log("header" + www_code);
				if (www_code == 200){
					JsonData json = JsonMapper.ToObject(www.text);
					int size = json.Count;
					Debug.Log(size);
					JsonData items = json[0];
					for (int i = 0; i < size; i++){
						if (json[i]["Count(*)+1"] != null){
							string temp = json[i]["Count(*)+1"].ToString();
							Debug.Log(temp);

						}//if
					}//for
				}//if
				else{
					// id 중복
				}
			}// if
			
		}
	}

}