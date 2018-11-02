﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kernel : MonoBehaviour
{
    public GameObject kernel;
    public static GameObject enterKernel;

    static public bool isEnter = false;


    public void KernelOn(GameObject obj)
    {
        obj.transform.position = kernel.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (enterKernel == null)
        {
            if (obj.CompareTag("Player"))
            {
                enterKernel = gameObject;
                KernelOn(obj.gameObject);
            }
        }
        else
            return;
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (enterKernel == gameObject)
            return;
        else
        {
            if (obj.CompareTag("Player"))
            {
                enterKernel = null;
            }
        }
    }
}
