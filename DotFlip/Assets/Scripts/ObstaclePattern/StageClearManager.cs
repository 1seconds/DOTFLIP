using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class RemainBlocks
{
    public GameObject blocks;
    public bool chk;
}

public class StageClearManager : MonoBehaviour
{
    private int cnt = 0;
    public RemainBlocks[] remainBlocks;
    public static bool RemainNull = false;

    OutOfCamera outofcamera;

    void Start()
    {
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();
        for (int i = 0; i < remainBlocks.Length; i++)
            remainBlocks[i].chk = false;
    }

    void CheckFunction(int i)
    {
        cnt += 1;
        remainBlocks[i].chk = true;

        //다음 씬 로드
        if(cnt == remainBlocks.Length)
             RemainNull = true;
    }

    public void InitFunction()
    {

        //Debug.Log("77777");
        outofcamera.InitFunction();
        GameObject.FindWithTag("Click").GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;
        GameObject.FindWithTag("Click").GetComponent<ClickEvent>().ball.SetActive(true);
        for (int i = 0; i < remainBlocks.Length; i++)
        {
            remainBlocks[i].blocks.SetActive(true);
            remainBlocks[i].chk = false;
        }
        cnt = 0;
        RemainNull = false;
        EnterResetFunction.isEnterFunction = false;
    }

    void Update()
    {
        if (outofcamera.enterResetFunction)
            InitFunction();
        
        if (remainBlocks.Length == 0)
        {
            RemainNull = true;
            return;
        }

        for (int i =0; i< remainBlocks.Length; i++)
        {

            if(!remainBlocks[i].blocks.activeSelf && !remainBlocks[i].chk)
            {
                CheckFunction(i);
            }
        }
    }
}
