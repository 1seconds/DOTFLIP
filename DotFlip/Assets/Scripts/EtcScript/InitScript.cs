using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    ////reset
    void Start()
    {
        PlayerPrefs.SetInt("HighScene", 0);
        PlayerPrefs.SetInt("Freeze", 0);
        SingletonScript.Instance._BallCnt = 20;
        SingletonScript.Instance._currentTime = -1;
        SingletonScript.Instance._TotalStartSec = 0;
    }
}
