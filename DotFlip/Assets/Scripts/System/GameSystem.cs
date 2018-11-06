using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public GameState currentGameState;

    private UISystem uiSystem;
    private StageSystem stageSystem;

    private GameObject player;
    public GameObject[] blocks;

    static public Stack<GameObject> switchContainObjectsStack = new Stack<GameObject>();           //스위치가 있는 오브젝트들
    private Vector2[] switchContainObjectPos;               //스위치가 있는 오브젝트의 위치값
    private GameObject[] switchContainObject;

    private void SaveSwitchContainObjectPos()
    {
        switchContainObject = new GameObject[switchContainObjectsStack.Count];
        switchContainObjectPos = new Vector2[switchContainObjectsStack.Count];

        //초기 위치 저장
        for (int i =0; i< switchContainObject.Length; i++)
        {
            switchContainObject[i] = switchContainObjectsStack.Pop();
            switchContainObjectPos[i] = switchContainObject[i].transform.position;
        }
    }

    private void Start()
    {
        stageSystem = gameObject.GetComponent<StageSystem>();
        uiSystem = gameObject.GetComponent<UISystem>();
        player = GameObject.FindWithTag("Player");

        SaveSwitchContainObjectPos();
    }

    //게임 시작
    public void GameStart()
    {
        currentGameState = GameState.DISPLAYING;
        uiSystem.MessageManager(stageSystem.stage[stageSystem.currentStage - 1].messageInfo.ment, stageSystem.stage[stageSystem.currentStage - 1].messageInfo.messageDisplayTime);
        player.GetComponent<PlayerMove>().currentDirect = stageSystem.stage[stageSystem.currentStage - 1].playerInfo.shootDirect;
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }

    //라이프를 1개 소진
    public void GameMiss()
    {
        player.transform.position = stageSystem.stage[stageSystem.currentStage - 1].playerInfo.pos;
        player.GetComponent<PlayerMove>().currentDirect = Direct.HOLD;
        currentGameState = GameState.READY;
        uiSystem.DownSideCanvasOn();

        //Init
        for(int i =0; i< switchContainObjectPos.Length; i++)
        {
            switchContainObject[i].transform.eulerAngles = new Vector3(0, 0, 0);
            switchContainObject[i].transform.position = switchContainObjectPos[i];
            if(switchContainObject[i].GetComponent<Move>() != null)
                switchContainObject[i].GetComponent<Move>().switchObj.GetComponent<Switch>().switchOn = false;
            else if (switchContainObject[i].GetComponent<Spin>() != null)
                switchContainObject[i].GetComponent<Spin>().switchObj.GetComponent<Switch>().switchOn = false;
            else if (switchContainObject[i].GetComponent<Blink>() != null)
                switchContainObject[i].GetComponent<Blink>().switchObj.GetComponent<Switch>().switchOn = false;
        }

        if (UISystem.isSaveBlockOn)
        {
            for (int i = 0; i < blocks.Length; i++)
                blocks[i].SetActive(true);
        }
        else
            return;
    }

    //라이프를 모두 다 사용했을 때
    public void GameEnd()
    {

    }
   
}
