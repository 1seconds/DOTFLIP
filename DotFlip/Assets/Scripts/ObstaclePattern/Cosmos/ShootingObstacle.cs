using UnityEngine;
using System.Collections;

public class ShootingObstacle : MonoBehaviour
{
    public float speed;
    public float delayTime;
    public GameObject shootingPrefab;
	public Bullet[] bullet;

    public Sprite[] cosmosBallet = new Sprite[4];

    void Start()
    {
        StartCoroutine(ShootingStart(delayTime));
		bullet = GameObject.Find("cosmosManager").GetComponentsInChildren<Bullet>(true);
		//cosmosManager의 child Bullet을 모두 얻어온다 (active false, ture 모두) 
    }

    IEnumerator ShootingStart(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            for(int i =0; i<4;i++)
            {
				for (int j = 0; j < bullet.Length; j++) {
					if (bullet [j].active == false) {
						//StartCoroutine (InstantiateGameObject (Instantiate (shootingPrefab), i));
						bullet[j].active =true;
						bullet[j].gameObject.SetActive(true);
						StartCoroutine (InstantiateGameObject (bullet[j], i));
						break;
					}
				}
            }
        }
    }
//    IEnumerator InstantiateGameObject(GameObject obj, int j)
//    {
//        obj.transform.position = gameObject.transform.position;
//        obj.transform.eulerAngles = gameObject.transform.eulerAngles;
//
//        while (true)
//        {
//            yield return new WaitForEndOfFrame();
//
//            if (obj == null)
//                break;
//
//            if (j == 0)
//                obj.transform.Translate(speed * Time.deltaTime, 0, 0);
//            if (j == 1)
//                obj.transform.Translate(-speed * Time.deltaTime, 0, 0);
//            if (j == 2)
//                obj.transform.Translate(0, speed * Time.deltaTime, 0);
//            if (j == 3)
//                obj.transform.Translate(0, -speed * Time.deltaTime, 0);
//        }
//
//    }

	IEnumerator InstantiateGameObject(Bullet obj, int j)
	{
        obj.transform.position = gameObject.transform.position;
        if(j == 0)
            obj.transform.eulerAngles = new Vector3(0, 0, 270);
        if (j == 1)
            obj.transform.eulerAngles = new Vector3(0, 0, 90);
        if (j == 2)
            obj.transform.eulerAngles = new Vector3(0, 0, 0);
        if (j == 3)
            obj.transform.eulerAngles = new Vector3(0, 0, 180);

        //obj.active = true;

        while (true)
		{
			yield return new WaitForEndOfFrame();
			//yield return new WaitForSeconds(0.1f);

			if (obj == null)
                break;
            if (obj.active == false)
                break;

            obj.transform.Translate(0, speed * Time.deltaTime, 0);
        }

	}


}
