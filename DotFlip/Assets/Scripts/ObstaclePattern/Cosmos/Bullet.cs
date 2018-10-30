using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	/*
	 * 총알
		active와 rigidody 넣기
	 */

	public Bullet bullet;
	private Rigidbody2D rg2;
	public bool active=false;
	// Use this for initialization
	void Start () {
		bullet = GetComponent<Bullet> ();
		bullet.gameObject.AddComponent<Rigidbody2D>();
        bullet.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		rg2 = bullet.GetComponent<Rigidbody2D>();
		rg2.simulated = true;
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		if(coll.tag == "Obstacle")
        {
			bullet.active = false;
			bullet.gameObject.SetActive(false);
		}

	}
}
