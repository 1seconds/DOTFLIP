using UnityEngine;
using System.Collections;

//04스테이지에서만 사용되는 스크립트

public class Stage04Script : MonoBehaviour
{
    public GameObject upObstacle;
    public GameObject downObstacle;
    public float speed;
    public float deadlineX;

    void Start ()
    {
        upObstacle.SetActive(false);
        downObstacle.SetActive(false);

        StartCoroutine(CreateObstacle(0, upObstacle));
        StartCoroutine(CreateObstacle(1, downObstacle));
    }

    IEnumerator CreateObstacle(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            obj.SetActive(true);
            GameObject prefab = Instantiate(obj);
            obj.SetActive(false);
            while (true)
            {
                prefab.transform.position = new Vector2(prefab.transform.position.x - speed * Time.deltaTime, prefab.transform.position.y);
                yield return new WaitForEndOfFrame();
                    
                if (prefab.transform.position.x < deadlineX)
                {
                    Destroy(prefab);
                    break;
                }
            }
        }
    }
}