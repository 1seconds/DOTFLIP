using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//  00씬에서 스타트화면에서 발생하는 이벤트들의 스크립트

public class StartScripts : MonoBehaviour
{
    InGameManager ingamemanager;

    public GameObject startBtn;
    public GameObject clockActive;

    private int timeMin;
    private int timeSec;

    //활성화 될때
    void OnEnable()
    {
        ingamemanager = GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>();
        ingamemanager.timeTxt = GameObject.FindWithTag("TimeManager");
        ingamemanager.timeTxtMin = GameObject.FindWithTag("TimeManager").GetComponent<linkScript>().linkObj[0].GetComponent<Text>();
        ingamemanager.timeTxtSec = GameObject.FindWithTag("TimeManager").GetComponent<linkScript>().linkObj[1].GetComponent<Text>();
    }

    //비활성화 될때
    void OnDisable()
    {
        StopAllCoroutines();
    }

    void BallExistCheckFunction(bool isNoneBall)
    {
        if(isNoneBall)
        {
            //액티브 On / Off
            clockActive.SetActive(true);
            startBtn.SetActive(false);

            //공 갯수 표기
            GameObject.FindWithTag("MainCamera").GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();

            //시간계산 함수로 들어감
            StartCoroutine(TimeKeepGoing());
        }

        else
        {
            //액티브 On / Off
            startBtn.SetActive(true);
            clockActive.SetActive(false);

            //공 갯수 표기
            GameObject.FindWithTag("MainCamera").GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();
        }
    }

    void Start()
    {
        PlayerPrefs.SetInt("oneCoinEnd", 0);

        //광고종료시 비정상적으로 종료할경우
        if (SingletonScript.Instance._AdsCancel == 0)
        {
            Debug.Log("2222222");
            SingletonScript.Instance._currentTime = 150;
            SingletonScript.Instance._BallCnt = 0;
            SingletonScript.Instance._AdsCancel = 1;
            AdsManagerHelper.isCancel = false;

            BallExistCheckFunction(true);
            return;
        }

        // _currentTime이 -1일경우, 공이 남아있음. - 처음
        if (SingletonScript.Instance._currentTime < 0)
        {
            Debug.Log("111111");
            BallExistCheckFunction(false);
            return;
        }

        //공이 남아있지않을때
        else
        {
            //광고 캔슬하자마자
            if(SingletonScript.Instance._currentTime == 150)
            {
                Debug.Log("33333333");
                BallExistCheckFunction(true);
            }

            //나갔다왔을 때
            else
            {
                Debug.Log("444444444");
                SingletonScript.Instance._currentTime -= (SingletonScript.Instance._TotalStartSec - SingletonScript.Instance._TotalQuitSec);
                //설정값 셋팅
                BallExistCheckFunction(true);
            }
        }
    }

    //시간 1초씩감소
    public IEnumerator TimeKeepGoing()
    {
        timeSec = SingletonScript.Instance._currentTime % 60;
        timeMin = SingletonScript.Instance._currentTime / 60;

        while (true)
        {
            //if (InGameManager.isStartScene)
            //{
            timeSec = SingletonScript.Instance._currentTime % 60;
            timeMin = SingletonScript.Instance._currentTime / 60;

            ingamemanager.timeTxt.SetActive(true);

            if (timeSec < 10)
                ingamemanager.timeTxtSec.text = "0" + timeSec.ToString();       // 초단위가 10 이하일경우 앞에 0 추가삽입
            else
                ingamemanager.timeTxtSec.text = timeSec.ToString();             // 문구출력


            if (timeMin < 10)
                ingamemanager.timeTxtMin.text = "0" + timeMin.ToString();       // 분단위가 10 이하일경우 앞에 0 추가삽입
            else
                ingamemanager.timeTxtMin.text = timeMin.ToString();             //문구출력

            //}
            if (timeSec < 1)
            {
                timeMin -= 1;
                timeSec += 60;
            }

            timeSec -= 1;                   //1초씩감소
            SingletonScript.Instance._currentTime -= 1;

            yield return new WaitForSeconds(1f);

            if (SingletonScript.Instance._currentTime < 1)
                break;
        }

        //액티브 On / Off
        startBtn.SetActive(true);
        clockActive.SetActive(false);

        //설정값 셋팅
        SingletonScript.Instance._currentTime = -1;
        SingletonScript.Instance._BallCnt = 20;

        //공 갯수 표기
        GameObject.FindWithTag("MainCamera").GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();
    }
}