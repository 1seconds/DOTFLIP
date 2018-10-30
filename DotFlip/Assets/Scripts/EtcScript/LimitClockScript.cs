using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimitClockScript : MonoBehaviour
{
    private float initTime;
    private Text text;
    private string tmp;
    private bool isEnterFunction = false;
    public GameObject mainCamera;
    
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        tmp = gameObject.GetComponent<Text>().text;
        initTime = float.Parse(tmp.Substring(8, 3));        //8번째자리부터 3개만큼 float형으로 형변환
        text = gameObject.GetComponent<Text>();
    }

    IEnumerator ReduceTime(float time)
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;

            time = Mathf.Round(time / 0.1f) * 0.1f;         //소수점 첫째 자리 수까지 표현
            time.ToString();                                //string형으로 형변환

            text.text = "Limit : " + time;
            yield return new WaitForEndOfFrame();

            if (time < 0)
                break;
        }

        //mainCamera.GetComponent<OutOfCamera>().Init();

    }

    void Update()
    {
        //제한시간 시작
        //if (ClickEvent.isDoClick && !isEnterFunction)
        //{
        //    StartCoroutine(ReduceTime(initTime));
        //    isEnterFunction = true;
        //}

        //공이 인게임에서 벗어났을때
        //if (mainCamera.GetComponent<OutOfCamera>().enterResetFunction && !ClickEvent.isDoClick)
        //{
        //    StopAllCoroutines();
        //    text.text = "Limit : " + initTime;
        //    isEnterFunction = false;
        //}
            
    }
}
