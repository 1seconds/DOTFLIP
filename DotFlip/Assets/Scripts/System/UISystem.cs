using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public GameObject downSideCanvas;

    public GameObject settingBtn;
    public GameObject soundBtn;
    public GameObject hintBtn;
    public Direct shootDirect;

    public Sprite[] btnSprSet;
    private GameObject player;
    public Text messageText;
    private char[] messageCharArray;

    static public bool isTriggerEnter = false;
    private bool isSettingBtnOn = false;

    private StageSystem stageSystem;
    public Transform obstacleTrans;
    private GameObject objPrefab;

    public float waitingTime;
    private float time_;

    private void MakeNextStage()
    {
        for(int i =0; i < stageSystem.stage[stageSystem.currentStage - 1].stageInfo.Length; i++)
        {
            if (stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].stageDirect.Equals(Direct.DOWN))
            {
                for (int j = 0; j < stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo.Length; j++)
                {
                    objPrefab = Instantiate(stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo[j].obj);
                    objPrefab.transform.parent = obstacleTrans;
                    objPrefab.transform.position = stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo[j].pos;
                    objPrefab.transform.position += new Vector3(0, -11.65f, 0);
                }
            }
            else if(stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].stageDirect.Equals(Direct.RIGHT))
            {
                for (int j = 0; j < stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo.Length; j++)
                {
                    objPrefab = Instantiate(stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo[j].obj);
                    objPrefab.transform.parent = obstacleTrans;
                    objPrefab.transform.position = stageSystem.stage[stageSystem.stage[stageSystem.currentStage - 1].stageInfo[i].nextStage - 1].ObjectInfo[j].pos;
                    objPrefab.transform.position += new Vector3(20.68f, 0, 0);
                }
            }
            
                
        }

        
    }

    private void Start()
    {
        //init
        player = GameObject.FindWithTag("Player");
        stageSystem = gameObject.GetComponent<StageSystem>();
        MakeNextStage();
        messageText.transform.position = stageSystem.stage[stageSystem.currentStage - 1].messageInfo.pos;
        messageText.text = "";
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

    private IEnumerator CanvasMoveCor(GameObject canvas1, GameObject canvas2, Vector3 pos1, Vector3 pos2)
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
        player.GetComponent<PlayerMove>().currentDirect = shootDirect;

        MessageManager(stageSystem.stage[stageSystem.currentStage - 1].messageInfo.ment , stageSystem.stage[stageSystem.currentStage - 1].messageInfo.messageDisplayTime);
        StartCoroutine(CanvasMoveCor(downSideCanvas, new Vector3(0, -130, 0)));
        if (isSettingBtnOn)
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

    public void MessageManager(string message, float time)
    {
        StartCoroutine(MessageManagerCor(message, time));
    }

    private IEnumerator MessageManagerCor(string message, float time)
    {
        messageCharArray = message.ToCharArray();
        for (int i = 0; i < messageCharArray.Length; i++)
        {
            messageText.text += messageCharArray[i];
            yield return new WaitForSeconds(time / messageCharArray.Length);
        }
    }
}