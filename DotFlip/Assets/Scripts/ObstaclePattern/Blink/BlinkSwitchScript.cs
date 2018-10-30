using UnityEngine;
using System.Collections;

public class BlinkSwitchScript : MonoBehaviour
{
    public bool isAbleBlink = false;

    //스위치 작동 - 회전 화성화
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
            isAbleBlink = true;
        else
            return;
    }
}
