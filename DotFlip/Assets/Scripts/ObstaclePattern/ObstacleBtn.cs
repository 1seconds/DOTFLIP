using UnityEngine;
using System.Collections;

public class ObstacleBtn : MonoBehaviour {

	/*
	 * 
	- 34스테이지에서 
	btn 충돌시 로봇 움직이게 하고
	ClickEvent.isDoClick==false 
	게임에서 패배하면
	원래 위치로 돌려놓는 스크립트임

	 */

	public GameObject gameobject;		//위치제어할 Object
	private Vector2 vector2;			//gameObject positon Vector


	// Use this for initialization
	void Start () {
		vector2=gameobject.transform.position;
	}
	void Update(){
		if(ClickEvent.isDoClick < 1){
			if (gameobject.GetComponent<MoveX>() != null){
				gameobject.GetComponent<MoveX>().speed = 0;
			}
			gameobject.transform.position = vector2;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (gameobject.GetComponent<MoveX>() != null){
			gameobject.GetComponent<MoveX>().speed = 5;
		}

	}

}
