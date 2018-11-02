using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public GameObject switchObj;            //스위치 - 없을경우 null
    public Sprite[] digdaImg = new Sprite[3];
    public bool isUpStart;                 //위에서 시작 / 아래서 시작
    private Switch switchScript;            //스위치 스크립트
    private bool isSwitchNone;              //스위치가 있는지 여부 판단

    public float speed;                     //오브젝트 속도

    private void Start()
    {
        if (switchObj == null)
            isSwitchNone = true;

        else
        {
            switchScript = switchObj.GetComponent<Switch>();
            isSwitchNone = false;
        }


        StartCoroutine(Working());
    }

    IEnumerator Working()
    {

        while (true)
        {
            //스위치가있으면
            if (!isSwitchNone)
            {
                if (!switchScript.switchOn)
                    break;
            }
            else
            {
                for(int i=0; i< 3;i++)
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Working());
    }
}
