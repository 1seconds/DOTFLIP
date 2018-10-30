using UnityEngine;
using System.Collections;

public class CosmosPrefabsManager : MonoBehaviour {


	//공이 이동가능한 좌표값 정보
	public float xMaxPos;
	public float xMinPos;
	public float yMaxPos;
	public float yMinPos;

	public Bullet[] bullet;
	public Transform[] tr;
	private CosmosPrefabsManager cpm;

	// Use this for initialization
	void Start () {
		cpm = GetComponent<CosmosPrefabsManager> ();
		tr = cpm.GetComponentsInChildren<Transform> ();
		bullet = cpm.GetComponentsInChildren<Bullet> (true);

	}

	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < bullet.Length; i++) {
			if (bullet[i].gameObject.transform.position.x > xMaxPos || bullet[i].gameObject.transform.position.x < xMinPos || bullet[i].gameObject.transform.position.y > yMaxPos || bullet[i].gameObject.transform.position.y < yMinPos)
			{
				bullet[i].gameObject.SetActive(false);
				bullet[i].active = false;
			}
		}
	}
}
