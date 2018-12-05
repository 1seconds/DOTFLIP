using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switchOn = false;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Player") || obj.CompareTag("Auto"))
        {
            if (switchOn)
                switchOn = false;
            else
                switchOn = true;
        }
    }
}
