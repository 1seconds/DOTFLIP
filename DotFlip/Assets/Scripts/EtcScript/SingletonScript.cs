using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScript : MonoBehaviour
{


    public int currentTime = 150;
    public int ballCnt = 20;
    public int isCancelAds = 0;     //bool타입 대체 0 => false, 1 => true
    public int quitSec;             //종료시에 시간
    public int startSec;            //시작시에 시간
    public int enterCoroutine = 0;
    public int deleteKey;           //휴지통 on // off
    public int freezeKey;           //방향키저장 on // off
    public int soundkey;            //사운드저장 on // off


    private static SingletonScript _instance;
    private static GameObject container;

    public static SingletonScript Instance
    {
        get
        {
            if (!_instance)
            {
                container = new GameObject();
                container.name = "Logger";
                _instance = container.AddComponent(typeof(SingletonScript)) as SingletonScript;
            }
            return _instance;
        }
    }


    public void OnApplicationQuit()
    {
        _instance = null;
    }

    public int _BallCnt
    {
        get
        {
            if (PlayerPrefs.HasKey("BallCnt"))
            {
                ballCnt = PlayerPrefs.GetInt("BallCnt");
            }
            else
            {
                ballCnt = 0;
            }
            return ballCnt;
        }
        set
        {
            ballCnt = value;
            PlayerPrefs.SetInt("BallCnt", ballCnt);
        }
    }

    //1이면 정상적으로 종료 , 0이면 비정상적으로 종료
    public int _AdsCancel
    {
        get
        {
            if (PlayerPrefs.HasKey("AdsCancelBool"))
            {
                isCancelAds = PlayerPrefs.GetInt("AdsCancelBool");
            }
            else
            {
                isCancelAds = 1;
            }
            return isCancelAds;
        }
        set
        {
            isCancelAds = value;
            PlayerPrefs.SetInt("AdsCancelBool", isCancelAds);
        }
    }

    public int _DeleteKey
    {
        get
        {
            if (PlayerPrefs.HasKey("DeleteKey"))
            {
                deleteKey = PlayerPrefs.GetInt("DeleteKey");
            }
            else
            {
                deleteKey = 0;
            }
            return deleteKey;
        }
        set
        {
            deleteKey = value;
            PlayerPrefs.SetInt("DeleteKey", deleteKey);
        }
    }

    public int _FreezeKey
    {
        get
        {
            if (PlayerPrefs.HasKey("Freeze"))
            {
                freezeKey = PlayerPrefs.GetInt("Freeze");
            }
            else
            {
                freezeKey = 0;
            }
            return freezeKey;
        }
        set
        {
            freezeKey = value;
            PlayerPrefs.SetInt("Freeze", freezeKey);
        }
    }

    public int _SoundKey
    {
        get
        {
            if (PlayerPrefs.HasKey("Sound"))
            {
                soundkey = PlayerPrefs.GetInt("Sound");
            }
            else
            {
                soundkey = 1;
            }
            return soundkey;
        }
        set
        {
            soundkey = value;
            PlayerPrefs.SetInt("Sound", soundkey);
        }
    }

    //게임 종료시간
    public int _TotalQuitSec
    {
        get
        {
            if (PlayerPrefs.HasKey("SecQuit"))
            {
                quitSec = PlayerPrefs.GetInt("SecQuit");
            }
            else
            {
                quitSec = 0;
            }
            return quitSec;
        }
        set
        {
            quitSec = value;
            PlayerPrefs.SetInt("SecQuit", quitSec);
        }
    }

    //게임 시작시간
    public int _TotalStartSec
    {
        get
        {
            if (PlayerPrefs.HasKey("SecStart"))
            {
                startSec = PlayerPrefs.GetInt("SecStart");
            }
            else
            {
                startSec = 0;
            }
            return startSec;
        }
        set
        {
            startSec = value;
            PlayerPrefs.SetInt("SecStart", startSec);
        }
    }

    //현재시간
    public int _currentTime
    {
        get
        {
            if (PlayerPrefs.HasKey("limitTime"))
            {
                currentTime = PlayerPrefs.GetInt("limitTime");
            }
            else
            {
                currentTime = 0;
            }
            return currentTime;
        }
        set
        {
            currentTime = value;
            PlayerPrefs.SetInt("limitTime", currentTime);
        }
    }
}