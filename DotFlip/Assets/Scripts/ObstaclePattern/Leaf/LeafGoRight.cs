using UnityEngine;
using System.Collections;

public class LeafGoRight : MonoBehaviour
{
    public GameObject leaf;
    public float leafSpeed;
    public float leafStart;
    public float limitX;
    public float maxY;
    public float minY;

    public bool start2Go;
    public bool start5Go;

    private float currentPosY;
    private GameObject leafPrefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(leafStart);

        leafPrefab = Instantiate(leaf);
        leafPrefab.transform.position = gameObject.transform.position;

        if (start2Go)
            StartCoroutine(Go2Hour(leafPrefab));
        if (start5Go)
            StartCoroutine(Go5Hour(leafPrefab));

    }

    //5시방향으로 이동하는 함수
    IEnumerator Go5Hour(GameObject obj)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            obj.transform.position = new Vector2(obj.transform.position.x + leafSpeed * Time.deltaTime, obj.transform.position.y - leafSpeed * Time.deltaTime);

            if (currentPosY < minY)
                break;
			
        }
        StartCoroutine(Go2Hour(obj));
    }

    //2시방향으로 이동하는 함수
    IEnumerator Go2Hour(GameObject obj)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            obj.transform.position = new Vector2(obj.transform.position.x + leafSpeed * Time.deltaTime, obj.transform.position.y + leafSpeed * Time.deltaTime);

            if (currentPosY > maxY)
                break;
        }
        StartCoroutine(Go5Hour(obj));
    }

    void Update()
    {
        if (leafPrefab != null)
            currentPosY = leafPrefab.transform.position.y;

        if (leafPrefab != null && leafPrefab.transform.position.x > limitX)
        {
            Destroy(leafPrefab);
            StopAllCoroutines();
            leafPrefab = Instantiate(leaf);
            leafPrefab.transform.position = gameObject.transform.position;

            if (start2Go)
                StartCoroutine(Go2Hour(leafPrefab));
            if (start5Go)
                StartCoroutine(Go5Hour(leafPrefab));
        }
    }

}
