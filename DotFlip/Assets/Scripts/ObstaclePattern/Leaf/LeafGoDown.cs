using UnityEngine;
using System.Collections;

public class LeafGoDown : MonoBehaviour
{
    public GameObject leaf;
    public float leafSpeed;
    public float leafStart;
    public float limitY;
    public float maxX;
    public float minX;

    public bool start5Go;
    public bool start7Go;

    private float currentPosX;
    private GameObject leafPrefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(leafStart);

        leafPrefab = Instantiate(leaf);
        leafPrefab.transform.position = gameObject.transform.position;

        if (start5Go)
            StartCoroutine(Go5Hour(leafPrefab));
        if (start7Go)
            StartCoroutine(Go7Hour(leafPrefab));
    }


    //7시방향으로 이동하는 함수
    IEnumerator Go7Hour(GameObject obj)
    {
        while (true)
        {
            obj.transform.position = new Vector2(obj.transform.position.x - leafSpeed * Time.deltaTime, obj.transform.position.y - leafSpeed * Time.deltaTime);

            if (currentPosX < minX)
                break;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Go5Hour(obj));
    }

    //5시방향으로 이동하는 함수
    IEnumerator Go5Hour(GameObject obj)
    {
        while (true)
        {
            obj.transform.position = new Vector2(obj.transform.position.x + leafSpeed * Time.deltaTime, obj.transform.position.y - leafSpeed * Time.deltaTime);

            if (currentPosX > maxX)
                break;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Go7Hour(obj));
    }

    void Update()
    {
        if (leafPrefab != null)
            currentPosX = leafPrefab.transform.position.x;

        if (leafPrefab != null && leafPrefab.transform.position.y < limitY)
        {
            Destroy(leafPrefab);
            StopAllCoroutines();
            leafPrefab = Instantiate(leaf);
            leafPrefab.transform.position = gameObject.transform.position;

            if (start5Go)
                StartCoroutine(Go5Hour(leafPrefab));
            if (start7Go)
                StartCoroutine(Go7Hour(leafPrefab));
        }
    }
}
