using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public GameObject downSideCanvas;

    public GameObject settingBtn;
    public GameObject soundBtn;
    public GameObject hintBtn;

    public Sprite[] btnSprSet;
    private GameObject player;

    static public bool isTriggerEnter = false;
    private bool isSettingBtnOn = false;

    public float waitingTime;
    private float time_;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private IEnumerator CanvasMoveCor(GameObject canvas, Vector3 pos)
    {
        isTriggerEnter = true;
        time_ = 0;

        while (true)
        {
            time_ += Time.deltaTime;
            canvas.transform.localPosition = Vector3.Lerp(canvas.transform.localPosition, pos, time_ / waitingTime);
            yield return new WaitForEndOfFrame();
            if (waitingTime < time_ + 0.2f)
                break;
        }
        canvas.transform.localPosition = pos;
        isTriggerEnter = false;
    }

    private IEnumerator CanvasMoveCor(GameObject canvas1,GameObject canvas2, Vector3 pos1, Vector3 pos2)
    {
        isTriggerEnter = true;
        time_ = 0;

        while (true)
        {
            time_ += Time.deltaTime;
            canvas1.transform.localPosition = Vector3.Lerp(canvas1.transform.localPosition, pos1, time_ / waitingTime);
            canvas2.transform.localPosition = Vector3.Lerp(canvas2.transform.localPosition, pos2, time_ / waitingTime);
            yield return new WaitForEndOfFrame();
            if (waitingTime < time_ + 0.2f)
                break;
        }
        canvas1.transform.localPosition = pos1;
        canvas2.transform.localPosition = pos2;
        isTriggerEnter = false;
    }

    //비활성화 - 게임시작
    public void DownSideCanvasOff()
    {
        player.GetComponent<PlayerMove>().currentDirect = Direct.DOWN;

        StartCoroutine(CanvasMoveCor(downSideCanvas, new Vector3(0,-130,0)));
        if(isSettingBtnOn)
            StartCoroutine(CanvasMoveCor(soundBtn, hintBtn, new Vector3(576, -295, 0), new Vector3(576, -295, 0)));
    }

    //활성화
    public void DownSideCanvasOn()
    {
        StartCoroutine(CanvasMoveCor(downSideCanvas, Vector3.zero));
    }

    public void SettingCanvasActive()
    {
        if (isTriggerEnter)
            return;

        //비활성화
        if (isSettingBtnOn)
        {
            StartCoroutine(CanvasMoveCor(soundBtn, hintBtn, new Vector3(576, -295, 0), new Vector3(576, -295, 0)));
            isSettingBtnOn = false;
        }
        
        //활성화
        else
        {
            StartCoroutine(CanvasMoveCor(soundBtn, hintBtn, new Vector3(576, -190, 0), new Vector3(576, -85, 0)));
            isSettingBtnOn = true;
        }
            
    }
}
