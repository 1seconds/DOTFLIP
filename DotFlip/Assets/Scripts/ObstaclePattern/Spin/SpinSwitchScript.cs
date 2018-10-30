using UnityEngine;
using System.Collections;

//  회전할시 필요한 버튼 스크립트 - 초기화하는 스크립트 필요, spinscript도 초기화하는 스크립트 필요

public class SpinSwitchScript : MonoBehaviour
{
    public bool isAbleSpin = false;
    
    //스위치 작동 - 회전 화성화
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
            isAbleSpin = true;
        else
            return;
    }
}
