using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightManager : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Vector3[] desPos;
    private Vector3 desNormalVec;

    private void Start()
    {
        StartCoroutine(Moving(0));
    }

    IEnumerator Moving(int index)
    {
        desNormalVec = desPos[index] - gameObject.transform.position;
        desNormalVec.Normalize();
        while (true)
        {
            gameObject.transform.Translate(desNormalVec);
            yield return new WaitForEndOfFrame();
            //if()
        }
        StartCoroutine(Moving(index += 1));
    }
}
