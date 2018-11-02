using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosDebug_ForDev : MonoBehaviour
{
	void Start ()
    {
        Debug.Log(gameObject.transform.position);
	}
}
