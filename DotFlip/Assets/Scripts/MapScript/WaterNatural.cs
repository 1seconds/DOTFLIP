using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNatural : MonoBehaviour
{
    private int randomNum = 0;

    void Start()
    {
        randomNum = Random.Range(0, 3);

        if (randomNum == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }

        else if(randomNum == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }

        else if (randomNum == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
