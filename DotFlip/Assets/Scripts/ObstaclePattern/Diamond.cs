using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private float maxZ = 15;
    private float minZ = -15;
    private float time_ = 0;

    private void Start()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().diamond = GameObject.FindGameObjectsWithTag("Diamond");
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Working());
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Working()
    {
        time_ = 0;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            time_ += Time.deltaTime;
            gameObject.transform.eulerAngles = Vector3.Lerp(Vector3.zero, new Vector3(0,0,maxZ), time_ * 2);
            if (time_ > 0.5f)
                break;
        }

        time_ = 0;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            time_ += Time.deltaTime;
            gameObject.transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, maxZ), new Vector3(0, 0, minZ), time_ * 2);
            if (time_ > 0.5f)
                break;
        }

        time_ = 0;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            time_ += Time.deltaTime;
            gameObject.transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, minZ), Vector3.zero, time_ * 2);
            if (time_ > 0.5f)
                break;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Working());
    }
}
