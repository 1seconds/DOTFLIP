using UnityEngine;
using System.Collections;

public class BallCntScript : MonoBehaviour
{
    public GameObject ball_1;
    public GameObject ball_2;

    static public GameObject[] tmp;
    public GameObject tmp2;
    static public GameObject[] readyball;

    public static bool isReadyBallDouble = false;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length > 1)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = false;
        }
    }

    void Start()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
            tmp2 = GameObject.FindWithTag("Ball");
        else
        {
            GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = false;
            tmp = GameObject.FindGameObjectsWithTag("Ball");
        }

    }


    void Update()
    {
        readyball = GameObject.FindGameObjectsWithTag("ReadyBall");

        if (readyball.Length > 1)
            isReadyBallDouble = true;
        else
            isReadyBallDouble = false;

        if (GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
            return;

        else
        {
            ball_1 = tmp[0];
            ball_2 = tmp[1];
        }
    }
}
