using UnityEngine;
using System.Collections;

public class LeafGoUp : MonoBehaviour
{
    public GameObject leaf;
    public float leafSpeed;
    public float leafStart;
    public float limitY;
    public float maxX;
    public float minX;

    public bool start2Go;
    public bool start11Go;

    private float currentPosX;
    private GameObject leafPrefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(leafStart);

        leafPrefab = Instantiate(leaf);
        leafPrefab.transform.position = gameObject.transform.position;

        if (start2Go)
            StartCoroutine(Go2Hour(leafPrefab));
        if (start11Go)
            StartCoroutine(Go11Hour(leafPrefab));

    }

    //11시방향으로 이동하는 함수
    IEnumerator Go11Hour(GameObject obj)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            obj.transform.position = new Vector2(obj.transform.position.x - leafSpeed * Time.deltaTime, obj.transform.position.y + leafSpeed * Time.deltaTime);

            if (currentPosX < minX)
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

            if (currentPosX > maxX)
                break;
        }
        StartCoroutine(Go11Hour(obj));
    }

    void Update()
    {
        if (leafPrefab != null)
            currentPosX = leafPrefab.transform.position.x;

        if (leafPrefab != null && leafPrefab.transform.position.y > limitY)
        {
            Destroy(leafPrefab);
            StopAllCoroutines();
            leafPrefab = Instantiate(leaf);
            leafPrefab.transform.position = gameObject.transform.position;

            if (start2Go)
                StartCoroutine(Go2Hour(leafPrefab));
            if (start11Go) 
                StartCoroutine(Go11Hour(leafPrefab));
        }
    }
}
