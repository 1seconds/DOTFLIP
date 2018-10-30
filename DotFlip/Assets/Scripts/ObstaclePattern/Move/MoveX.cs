using UnityEngine;
using System.Collections;

//  오브젝트가 x축으로 좌우로 이동할때 쓰이는 AI

public class MoveX : MonoBehaviour
{
    private float currentXPos;  
    private bool isRightSideWay = true;

    public float maxXPos;                   //오브젝트의 최대 x위치값
    public float minXPos;                   //오브젝트의 최소 X위치값
    public float speed;                     //오브젝트의 속도

    public GameObject moveSwitch;
    OutOfCamera outofcamera;

    private Vector3 currentPos;

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

        //스위치가 있을때
        if (moveSwitch != null)
        {
            if (moveSwitch.GetComponent<SwitchMove>().isSwitchOn)
            {
                //현재위치를 갱신
                currentXPos = gameObject.transform.position.x;

                //오른쪽으로 이동
                if (isRightSideWay)
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y);
                //왼쪽으로 이동
                else
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y);

                //스위칭
                if (currentXPos > maxXPos)
                    isRightSideWay = false;
                if (currentXPos < minXPos)
                    isRightSideWay = true;
            }
        }

        //스위치가없을때
        else
        {
            //현재위치를 갱신
            currentXPos = gameObject.transform.position.x;

            //오른쪽으로 이동
            if (isRightSideWay)
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y);
            //왼쪽으로 이동
            else
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y);

            //스위칭
            if (currentXPos > maxXPos)
                isRightSideWay = false;
            if (currentXPos < minXPos)
                isRightSideWay = true;
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