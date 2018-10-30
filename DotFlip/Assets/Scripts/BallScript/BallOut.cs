using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallOut : MonoBehaviour
{
    public Vector2 ballInitPos;
    OutOfCamera outofcamera;
    BallCntScript ballcntscript;
    SoundManager soundmanager;

    //공이 이동가능한 좌표값 정보
    public float xMaxPos = 11f;
    public float xMinPos = -11f;
    public float yMaxPos = 6.5f;
    public float yMinPos = -6.5f;

    void Awake()
    {
        ballInitPos = gameObject.transform.position;
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();
        ballcntscript = GameObject.FindWithTag("Toilet").GetComponent<BallCntScript>();
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        //Debug.Log(ballInitPos);
    }

    //더블 공
    public void Init(GameObject ball_1, GameObject ball_2)
    {
        Debug.Log("44444");
        EnterResetFunction.isEnterFunction = false;
        //SingletonScript.Instance._BallCnt -= 1;
        //GameObject.FindWithTag("MainCamera").GetComponent<PrefabController>().SaveData();

        // 애즈띄우기
        //if (SingletonScript.Instance._BallCnt < 1)
        //{
        //    //효과줄것
        //    GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().ads.SetActive(true);
        //    GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().dontClickAnything.SetActive(true);
        //}




        outofcamera.enterResetFunction = true;
        //사운드
        soundmanager.setClip(soundmanager.effect_[5].clip, soundmanager.effect_[5].volume);
        //Debug.Log("3333");
        //위치초기화
        ball_1.transform.position = ball_1.GetComponent<BallOut>().ballInitPos;

        //일시정지
        ball_1.GetComponent<BallStatus>().isGoDown = false;
        ball_1.GetComponent<BallStatus>().isGoLeft = false;
        ball_1.GetComponent<BallStatus>().isGoRight = false;
        ball_1.GetComponent<BallStatus>().isGoUp = false;

        ball_1.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ball_1.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

        ball_1.tag = "Ball";
        ball_1.SetActive(true);

        //위치초기화
        ball_2.transform.position = ball_2.GetComponent<BallOut>().ballInitPos; ;

        //일시정지
        ball_2.GetComponent<BallStatus>().isGoDown = false;
        ball_2.GetComponent<BallStatus>().isGoLeft = false;
        ball_2.GetComponent<BallStatus>().isGoRight = false;
        ball_2.GetComponent<BallStatus>().isGoUp = false;

        ball_2.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ball_2.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

        ball_2.tag = "Ball";
        ball_2.SetActive(true);

        StageClearScript.ballCnt = 0;
        StageClearScript.isEnterBall = false;

        ClickEvent.isDoClick = 0;

        //찍어내기 가능
        ClickEvent.rightImage.SetActive(true);
        ClickEvent.leftImage.SetActive(true);
        ClickEvent.downImage.SetActive(true);
        ClickEvent.upImage.SetActive(true);

        //인게임상의 블럭 파괴 - 프리즈안할시       
        if (SingletonScript.Instance._FreezeKey == 1)
        {
            for (int i = 0; i < PrefabController.block.Length; i++)
            {
                PrefabController.block[i].GetComponent<BoxCollider2D>().enabled = true;
                PrefabController.block[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < PrefabController.block.Length; i++)
                Destroy(PrefabController.block[i]);
        }

        outofcamera.KernelInit();

        //if (GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().isOneCoinMode)
        //{
        //    SceneManager.LoadScene("Rank");
        //}
    }

    //단일공
    public void Init()
    {
        EnterResetFunction.isEnterFunction = false;
        //SingletonScript.Instance._BallCnt -= 1;
        //GameObject.FindWithTag("MainCamera").GetComponent<PrefabController>().SaveData();
        // 애즈띄우기

        if (SingletonScript.Instance._BallCnt < 1)
        {
            //효과줄것
            GameObject.FindWithTag("MainCamera").GetComponent<AdsManagerHelper>().ads.SetActive(true);
            GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().dontClickAnything.SetActive(true);
        }


        outofcamera.enterResetFunction = true;
        //Debug.Log("2222");
        //사운드
        soundmanager.setClip(soundmanager.effect_[5].clip, soundmanager.effect_[5].volume);

        //위치초기화
        gameObject.transform.position = ballInitPos;

        //일시정지
        gameObject.GetComponent<BallStatus>().isGoDown = false;
        gameObject.GetComponent<BallStatus>().isGoLeft = false;
        gameObject.GetComponent<BallStatus>().isGoRight = false;
        gameObject.GetComponent<BallStatus>().isGoUp = false;

        gameObject.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

        gameObject.tag = "Ball";

        StageClearScript.ballCnt = 0;
        StageClearScript.isEnterBall = false;

        ClickEvent.isDoClick = 0;

        //찍어내기 가능
        ClickEvent.rightImage.SetActive(true);
        ClickEvent.leftImage.SetActive(true);
        ClickEvent.downImage.SetActive(true);
        ClickEvent.upImage.SetActive(true);

        //인게임상의 블럭 파괴 - 프리즈안할시       
        if (SingletonScript.Instance._FreezeKey == 1)
        {
            for (int i = 0; i < PrefabController.block.Length; i++)
            {
                PrefabController.block[i].GetComponent<BoxCollider2D>().enabled = true;
                PrefabController.block[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < PrefabController.block.Length; i++)
                Destroy(PrefabController.block[i]);
        }

        outofcamera.KernelInit();
        //if (GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().isOneCoinMode)
        //{
        //    SceneManager.LoadScene("Rank");
        //}
    }

    void Update()
    {
        //단일공일때
        if (outofcamera.isSingleBall)
        {
            //x, y범위가 벗어나면 리셋
            if (ballcntscript.tmp2.transform.position.x > xMaxPos || ballcntscript.tmp2.transform.position.x < xMinPos || ballcntscript.tmp2.transform.position.y > yMaxPos || ballcntscript.tmp2.transform.position.y < yMinPos)
                Init();
            else
                return;
        }

        //공이 두개일때
        else if (!outofcamera.isSingleBall)
        {
            //ball 1이 충돌나서 초기화되는경우
            if (ballcntscript.ball_1.transform.position.x > xMaxPos || ballcntscript.ball_1.transform.position.x < xMinPos || ballcntscript.ball_1.transform.position.y > yMaxPos || ballcntscript.ball_1.gameObject.transform.position.y < yMinPos)
                Init(ballcntscript.ball_1, ballcntscript.ball_2);

            //ball 2가 충돌나서 초기화되는경우
            if (ballcntscript.ball_2.transform.position.x > xMaxPos || ballcntscript.ball_2.transform.position.x < xMinPos || ballcntscript.ball_2.transform.position.y > yMaxPos || ballcntscript.ball_2.gameObject.transform.position.y < yMinPos)
                Init(ballcntscript.ball_1, ballcntscript.ball_2);
            else
                return;
        }

    }
}
