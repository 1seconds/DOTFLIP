using UnityEngine;
using System.Collections;

public class CenterColliderKernel : MonoBehaviour
{
    public bool isEnterTrigger = false;
    public GameObject thisBall = null;

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "ReadyBall")
        {
            isEnterTrigger = true;
            thisBall = obj.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "ReadyBall")
        {
            isEnterTrigger = false;
            thisBall = obj.gameObject;
        }
    }
}
