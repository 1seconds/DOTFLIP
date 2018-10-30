using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GamePlayStartTime : MonoBehaviour
{
    private int daySec;
    private int hourSec;
    private int minSec;
    [HideInInspector] private int totalSec;

    void Start ()
    {
        //60초 * 60분 * 24시간
        daySec = Convert.ToInt32(System.DateTime.Now.ToString("dd")) * 60 * 60 * 24;                    //일
        hourSec = Convert.ToInt32(System.DateTime.Now.ToString("hh")) * 60 * 60;                        //시
        minSec = Convert.ToInt32(System.DateTime.Now.ToString("mm")) * 60;                              //분
        totalSec = daySec + hourSec + minSec + Convert.ToInt32(System.DateTime.Now.ToString("ss"));     //초
        SingletonScript.Instance._TotalStartSec = totalSec + 3;
    }
}
