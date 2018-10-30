using UnityEngine;
using System.Collections;

public class TimeMoveBtnScript : MonoBehaviour
{
    public Vector3[] point;
    public float speed;         //뗏목속도
    private float distance_;    //두 포인트 사이의 거리
    private float time_;        //걸리는시간
    private float calTime_;

    private Vector3 startpoint;
    //public float timedone;
    //private float tmpTime;
    public GameObject btnObj;
    private bool enterFunction = false;
    OutOfCamera outofcamera;

    void Awake()
    {
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();
        startpoint = gameObject.transform.position;
    }

    void Go()
    {
        enterFunction = true;
        StartCoroutine(Swimming());
    }

    IEnumerator Swimming()
    {
        for (int j = 0; j < point.Length; j++)
        {
            if (j > point.Length - 2)
                break;

            else
            {
                distance_ = Vector3.Distance(point[j], point[j + 1]);
                time_ = distance_ / speed;

                //point[j].pointTime = point[j].tmpTime;
                calTime_ = time_;

                while (true)
                {
                    //if (point[j].pointTime < 0)
                    //    break;

                    if (calTime_ < 0)
                        break;

                    else
                    {
                        //point[j].pointTime -= Time.deltaTime;
                        //gameObject.transform.position = Vector3.Lerp(point[j].pointPos, point[j + 1].pointPos,  1 - (point[j].pointTime / point[j].tmpTime));
                        calTime_ -= Time.deltaTime;
                        //Debug.Log("time_ " + time_);
                        //Debug.Log("calTime_ " + calTime_);
                        gameObject.transform.position = Vector3.Lerp(point[j], point[j + 1], 1 - (calTime_ / time_));

                        //Debug.Log(1 - (calTime_ / time_));
                    }
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        StartCoroutine(Swimming());
    }

    void Update()
    {
        if (btnObj.GetComponent<BoatBtn>().isEnter && !enterFunction)
            Go();
    }

    void LateUpdate()
    {
        if (outofcamera.enterResetFunction)
        {
            btnObj.GetComponent<BoatBtn>().isEnter = false;
            EnterResetFunction.isEnterFunction = false;
            StopAllCoroutines();
            gameObject.transform.position = startpoint;
            enterFunction = false;
        }
    }
}
