using UnityEngine;
using System.Collections;

//  블링크는 오브젝트가 활성화되있을시 스크립트에 접근을 할 수 없으므로
//  다른 오브젝트에서 스크립트를 관리하고, 링크를 걸어놓아서 컨트롤하는것이 맞다고 생각된다.

[System.Serializable]
public class BlinkObj
{
    public GameObject blinkObj;
}

public class JustBlink : MonoBehaviour
{
    public BlinkObj[] obstacle;      //블링크되는 오브젝트의 갯수
    public float delayTime;                                 //처음시작할때 딜레이되는 시간
    public float blinkOffTime;                              //오브젝트가 비활성화되는 시간
    public float blinkOnTime;                               //오브젝트가 활성화 되는 시간

    public Sprite digda_1;          //콜라이더 활성화
    public Sprite digda_2;          //콜라이더 비활성화
    public Sprite digda_3;          //콜라이더 비활성화
    public bool DownToUp = false;

    void Start()
    {

        //두더지가 나타난상태에서 시작
        if(!DownToUp)
        {
            StartCoroutine(BlinkStartUpToDown(delayTime, 0));

            for (int i = 0; i < obstacle.Length; i++)
            {
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
                obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = true;
            }
        }


        //두더지가 없는 상태에서 시작
        else
        {
            StartCoroutine(BlinkStartDownToUp(delayTime , 0));

            for (int i = 0; i < obstacle.Length; i++)
            {
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
                obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

    //위에서 아래로 시작
    IEnumerator BlinkStartUpToDown(float delayTime, int obj)
    {
        yield return new WaitForSeconds(delayTime);

        for (int i = obj; i < obstacle.Length; i++)
        {
            //1/2만 보이기
            obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;

            if(obstacle.Length == 1)
            {
                yield return new WaitForSeconds(blinkOnTime / 2);

                //안보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
                yield return new WaitForSeconds(blinkOffTime / 2);


                //1/2만 보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
                yield return new WaitForSeconds(blinkOffTime / 2);

                //전체 다보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
                obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = true;
                yield return new WaitForSeconds(blinkOffTime / 2);
                StartCoroutine(BlinkStartUpToDown(delayTime, 0));          //재귀
                break;
            }

            else
            {
                if (i + 1 < obstacle.Length)
                    StartCoroutine(BlinkStartUpToDown(delayTime, i + 1));          //재귀

                else
                    StartCoroutine(BlinkStartUpToDown(delayTime, 0));          //재귀
            }

            yield return new WaitForSeconds(blinkOnTime / 2);

            //안보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            yield return new WaitForSeconds(blinkOffTime / 2);


            //1/2만 보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            yield return new WaitForSeconds(blinkOffTime / 2);

            //전체 다보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(blinkOffTime / 2);
            break;
        }
        

    }

    //아래서 위로 시작
    IEnumerator BlinkStartDownToUp(float delayTime, int obj)
    {
        yield return new WaitForSeconds(delayTime);
        for (int i = obj; i < obstacle.Length; i++)
        {
            //1/2만 보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;

            if (obstacle.Length == 1)
            {
                yield return new WaitForSeconds(blinkOnTime / 2);

                //안보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
                yield return new WaitForSeconds(blinkOffTime / 2);


                //1/2만 보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
                yield return new WaitForSeconds(blinkOffTime / 2);

                //전체 다보이기
                obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
                obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = true;
                yield return new WaitForSeconds(blinkOffTime / 2);
                StartCoroutine(BlinkStartUpToDown(delayTime, 0));          //재귀
                break;
            }

            else
            {
                if (i + 1 < obstacle.Length)
                    StartCoroutine(BlinkStartUpToDown(delayTime, i + 1));          //재귀

                else
                    StartCoroutine(BlinkStartUpToDown(delayTime, 0));          //재귀
            }

            yield return new WaitForSeconds(blinkOnTime / 2);

            //전체 다보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_1;
            obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = true;

            yield return new WaitForSeconds(blinkOffTime / 2);

            //1/2만 보이기
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_2;
            obstacle[i].blinkObj.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(blinkOffTime / 2);

            //블링크 끗
            obstacle[i].blinkObj.GetComponent<SpriteRenderer>().sprite = digda_3;
            yield return new WaitForSeconds(blinkOffTime / 2);
            break;
        }


    }
}
