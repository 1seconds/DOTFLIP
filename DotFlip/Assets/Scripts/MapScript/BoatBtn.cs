using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBtn : MonoBehaviour
{
    public bool isEnter = false;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Contains("Ball"))
            isEnter = true;
    }
}
