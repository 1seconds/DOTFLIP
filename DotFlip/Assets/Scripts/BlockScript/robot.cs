using UnityEngine;
using System.Collections;

public class robot : MonoBehaviour {

	public robot rb;

	void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log("hi");
		if (coll.tag == "Robot")
		{
			Debug.Log("come");
			//bullet.active = false;
		}
		//if (coll.tag == "Obstacle")
		//{
		//	Debug.Log("come");
		//	//bullet.active = false;
		//}
	}
}
