using UnityEngine;
using System.Collections;

public class BlinkScript : MonoBehaviour
{
    public GameObject btn;                                  //버튼
    public GameObject blinkObj;

    public float blinkOffTime;                              //오브젝트가 비활성화되는 시간
    public float blinkOnTime;                               //오브젝트가 활성화 되는 시간

    OutOfCamera outofcamera;

    private bool isEnterFunction = false;

    public Sprite digda_1;
    public Sprite digda_2;
    public Sprite digda_3;

    public bool isUpstart = true;

    void Start()
    {
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();

        if(isUpstart)
        {
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            blinkObj.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            blinkObj.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator BlinkStart(bool isUpstart)
    {
        isEnterFunction = true;

        if(isUpstart)
        {
            //1/2만 보이기
            blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            yield return new WaitForSeconds(blinkOnTime / 2);

            //안에 있는 두더지
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            yield return new WaitForSeconds(blinkOnTime / 2);

            //1/2만 보이기
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            yield return new WaitForSeconds(blinkOnTime / 2);

            //전체 다보이기
            blinkObj.GetComponent<BoxCollider2D>().enabled = true;
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            yield return new WaitForSeconds(blinkOffTime / 2);
        }

        else
        {
            //1/2만 보이기
            blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            yield return new WaitForSeconds(blinkOnTime / 2);

            //전체 다보이기
            blinkObj.GetComponent<BoxCollider2D>().enabled = true;
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            yield return new WaitForSeconds(blinkOffTime / 2);

            //1/2만 보이기
            blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            yield return new WaitForSeconds(blinkOnTime / 2);

            //안에 있는 두더지
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            yield return new WaitForSeconds(blinkOnTime / 2);
        }
        isEnterFunction = false;
    }

    void InitBlink(bool isUpstart)
    {
        if (isUpstart)
        {
            //전체 다보이기
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            blinkObj.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            //전체 다보이기
            blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            blinkObj.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        //부딪혔을때 초기화
        if (outofcamera.enterResetFunction)
        {
            //Debug.Log("88888");
            InitBlink(isUpstart);
            outofcamera.InitFunction();
            StopAllCoroutines();
            btn.GetComponent<BlinkSwitchScript>().isAbleBlink = false;
            isEnterFunction = false;
        }

        if (btn.GetComponent<BlinkSwitchScript>().isAbleBlink && !isEnterFunction)
        {
            StartCoroutine(BlinkStart(isUpstart));
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
