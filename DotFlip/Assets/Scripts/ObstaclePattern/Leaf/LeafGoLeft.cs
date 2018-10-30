using UnityEngine;
using System.Collections;

public class LeafGoLeft : MonoBehaviour
{
    public GameObject leaf;
    public float leafSpeed;
    public float leafStart;
    public float limitX;
    public float maxY;
    public float minY;

    public bool start7Go;
    public bool start11Go;

    private float currentPosY;
    private GameObject leafPrefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(leafStart);
        
        leafPrefab = Instantiate(leaf);
        leafPrefab.transform.position = gameObject.transform.position;

        if (start7Go)
            StartCoroutine(Go7Hour(leafPrefab));
        if (start11Go)
            StartCoroutine(Go11Hour(leafPrefab));
    }


    //11시방향으로 이동하는 함수
    IEnumerator Go11Hour(GameObject obj)
    {
        while (true)
        {
            obj.transform.position = new Vector2(obj.transform.position.x - leafSpeed * Time.deltaTime, obj.transform.position.y + leafSpeed * Time.deltaTime);

            if (currentPosY > maxY)
                break;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Go7Hour(obj));
    }

    //7시방향으로 이동하는 함수
    IEnumerator Go7Hour(GameObject obj)
    {
        while (true)
        {
            obj.transform.position = new Vector2(obj.transform.position.x - leafSpeed * Time.deltaTime, obj.transform.position.y - leafSpeed * Time.deltaTime);

            if (currentPosY < minY)
                break;

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Go11Hour(obj));
    }

    void Update()
    {
        if (leafPrefab != null)
            currentPosY = leafPrefab.transform.position.y;

        if (leafPrefab != null && leafPrefab.transform.position.x < limitX)
        {
            Destroy(leafPrefab);
            StopAllCoroutines();
            leafPrefab = Instantiate(leaf);
            leafPrefab.transform.position = gameObject.transform.position;

            if (start7Go)
                StartCoroutine(Go7Hour(leafPrefab));
            if (start11Go)
                StartCoroutine(Go11Hour(leafPrefab));
        }
    }
}
