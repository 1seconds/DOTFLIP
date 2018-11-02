using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosmos : MonoBehaviour
{
    public GameObject cosmosMisaile;
    private GameObject misailePrefab;
    public float waitingShootTime;

    private void Start()
    {
        StartCoroutine(ShootMisaile());
    }

    IEnumerator ShootMisaile()
    {
        for(int i =0; i < 4;i++)
        {
            misailePrefab = Instantiate(cosmosMisaile);
            misailePrefab.transform.position = gameObject.transform.position;
            misailePrefab.transform.eulerAngles = new Vector3(0, 0, gameObject.transform.eulerAngles.z + (90 * i));
            misailePrefab.transform.parent = GameObject.FindWithTag("GameManager").transform.GetChild(0).transform;
        }
        yield return new WaitForSeconds(waitingShootTime);
        StartCoroutine(ShootMisaile());
    }
}
