using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tuple : MonoBehaviour {
	string userid;
	string score;
	string rank;
	public GameObject textName;
	public GameObject textScore;
	public GameObject textRank;

	public void setUserId(string userid){
		textName.GetComponent<Text>().text = userid;
		this.userid = userid;
	}
	public void setScore(string score)
	{
		textScore.GetComponent<Text>().text = score;
		this.score = score;
	}
	public void setRank(string rank)
	{
		textRank.GetComponent<Text>().text = rank;
		this.rank = rank;
	}
	void getText(){
		//=textName.GetComponent<Text>().
	}

}
