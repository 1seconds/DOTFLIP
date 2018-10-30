using UnityEngine;
using System.Collections;

//  오브젝트가 y축으로 위아래로 이동할때 쓰이는 AI

public class MoveY : MonoBehaviour
{
    private float currentYPos;
    private bool isUpSideWay = true;

    private Vector3 currentPos;

    public float maxYPos;               //오브젝트의 최대 y위치값
    public float minYPos;               //오브젝트의 최소 y위치값
    public float speed;                 //오브젝트의 속도

    public GameObject moveSwitch;
    OutOfCamera outofcamera;

    void Start()
    {
        currentPos = gameObject.transform.position;
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();
        if (moveSwitch == null)
            return;
    }
    
    void Update()
    {
        //부딪혔을때 초기화
        if (outofcamera.enterResetFunction)
        {
            if (moveSwitch != null)
            {
                moveSwitch.GetComponent<SwitchMove>().isSwitchOn = false;
                gameObject.transform.position = currentPos;
                EnterResetFunction.isEnterFunction = false;
            }
        }

        if (moveSwitch != null)
        {
            if (moveSwitch.GetComponent<SwitchMove>().isSwitchOn)
            {
                //현재위치를 갱신
                currentYPos = gameObject.transform.position.y;

                //위쪽으로 이동
                if (isUpSideWay)
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);

                //아래쪽으로 이동
                else
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime);

                //스위칭
                if (currentYPos > maxYPos)
                    isUpSideWay = false;
                if (currentYPos < minYPos)
                    isUpSideWay = true;
            }
        }
        else
        {
            //현재위치를 갱신
            currentYPos = gameObject.transform.position.y;

            //위쪽으로 이동
            if (isUpSideWay)
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);

            //아래쪽으로 이동
            else
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime);

            //스위칭
            if (currentYPos > maxYPos)
                isUpSideWay = false;
            if (currentYPos < minYPos)
                isUpSideWay = true;
        }
    }

    void LateUpdate()
    {        
        if (outofcamera.enterResetFunction)
        {
            EnterResetFunction.isEnterFunction = false;
        }
    }
}