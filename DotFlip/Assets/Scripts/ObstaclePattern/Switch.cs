﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [HideInInspector] public bool switchOn = false;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Player"))
        {
            if (switchOn)
                switchOn = false;
            else
                switchOn = true;
        }
    }
}
