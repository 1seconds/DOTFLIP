using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuitScript : MonoBehaviour
{
    private int daySec;
    private int hourSec;
    private int minSec;
    [HideInInspector]
    private int totalSec;

    //게임을 종료할때 시간 체크를 합니다.
    public void OnApplicationQuit()
    {
        //60초 * 60분 * 24시간
        daySec = Convert.ToInt32(System.DateTime.Now.ToString("dd")) * 60 * 60 * 24;                    //일
        hourSec = Convert.ToInt32(System.DateTime.Now.ToString("hh")) * 60 * 60;                        //시
        minSec = Convert.ToInt32(System.DateTime.Now.ToString("mm")) * 60;                              //분
        totalSec = daySec + hourSec + minSec + Convert.ToInt32(System.DateTime.Now.ToString("ss"));     //초

        SingletonScript.Instance._TotalQuitSec = totalSec;

        //정상적으로 광고 캔슬했는지 체크

        
        if(AdsManagerHelper.isCancel)
        {
            //비정상적 종료
            SingletonScript.Instance._AdsCancel = 0;
        }
        else
        {
            //정상적종료
            SingletonScript.Instance._AdsCancel = 1;
        }

    }
}
