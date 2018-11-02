using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public Direct direct;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            obj.transform.position = gameObject.transform.position;
            obj.GetComponent<PlayerMove>().currentDirect = direct;
        }

    }
}
