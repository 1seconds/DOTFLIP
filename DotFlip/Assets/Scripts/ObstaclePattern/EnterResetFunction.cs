using UnityEngine;
using System.Collections;

public class EnterResetFunction : MonoBehaviour
{
    static public bool isEnterFunction = true;
    private float sec = 0.5f;
    private bool isEnter = false;

    IEnumerator Reset(float sec)
    {
        isEnter = true;

        SingletonScript.Instance._BallCnt -= 1;
        //Debug.Log("6666");
        // 애즈띄우기
        //gameObject.GetComponent<PrefabController>().SaveData();

        if (SingletonScript.Instance._BallCnt < 1)
        {
            SingletonScript.Instance._BallCnt = 0;

            //효과줄것
            gameObject.GetComponent<AdsManagerHelper>().ads.SetActive(true);
            gameObject.GetComponent<InGameManager>().dontClickAnything.SetActive(true);
        }

        GameObject.FindWithTag("MainCamera").GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();

        yield return new WaitForSeconds(sec);
        isEnterFunction = true;
        gameObject.GetComponent<OutOfCamera>().enterResetFunction = false;
        isEnter = false;

        
    }

    void LateUpdate()
    {
        if (!isEnterFunction && !isEnter)
            StartCoroutine(Reset(sec));
    }
}
