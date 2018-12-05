using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switchOn = false;

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag.Equals("Player") || obj.CompareTag("Auto"))
        {
            switchOn = true;
        }
    }
}
