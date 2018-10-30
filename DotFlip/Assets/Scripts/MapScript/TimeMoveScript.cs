using UnityEngine;
using System.Collections;

[System.Serializable]
public class Point
{
    public Vector3 pointPos;
    //public float pointTime;
    //[HideInInspector] public float tmpTime;
}


public class TimeMoveScript : MonoBehaviour
{
    public Point[] point;
    public float speed;         //뗏목속도
    private float distance_;    //두 포인트 사이의 거리
    private float time_;        //걸리는시간
    private float calTime_;

    void Awake()
    {
        //for(int i=0; i< point.Length;i++)
        //    point[i].tmpTime = point[i].pointTime;

        Go();
    }

    void Go()
    {
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
                distance_ = Vector3.Distance(point[j].pointPos, point[j + 1].pointPos);
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
                        //Debug.Log("time_ "  + time_);
                        //Debug.Log("calTime_ " + calTime_);
                        gameObject.transform.position = Vector3.Lerp(point[j].pointPos, point[j + 1].pointPos, 1 - (calTime_ / time_));

                        //Debug.Log(1 - (calTime_ / time_));
                    }
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        Go();
    }
}
