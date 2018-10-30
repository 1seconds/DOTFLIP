using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OutOfCamera : MonoBehaviour
{
    [HideInInspector] public bool enterResetFunction = false;
    BallCntScript ballcntscript;
    public bool isSingleBall = true;

    SoundManager soundmanager;

    public GameObject kernel_1;
    public GameObject kernel_2;

    void Start()
    {
        soundmanager = gameObject.GetComponentInChildren<SoundManager>();
    }

    ////원코인모드인지 판별하는 함수
    //public void OneGameModeOnOff()
    //{
    //    if (gameObject.GetComponent<InGameManager>().isOneCoinMode)
    //        Debug.Log("원코인모드에서 죽었다,.");           
    //}

    public void KernelInit()
    {
        kernel_1 = GameObject.Find("Kernel_1");
        kernel_2 = GameObject.Find("Kernel_2");

        //커널 초기화
        if (kernel_1 != null && kernel_2 != null)
        {
            //1초기화
            kernel_1.GetComponentInChildren<SideColliderKernel>().isEnterTrigger = false;
            kernel_1.GetComponentInChildren<CenterColliderKernel>().isEnterTrigger = false;

            //2초기화
            kernel_2.GetComponentInChildren<SideColliderKernel>().isEnterTrigger = false;
            kernel_2.GetComponentInChildren<CenterColliderKernel>().isEnterTrigger = false;
        }
    }

    public void InitFunction()
    {
        //OneGameModeOnOff();
        enterResetFunction = true;
        EnterResetFunction.isEnterFunction = false;
        ballcntscript = GameObject.FindWithTag("Toilet").GetComponent<BallCntScript>();
        KernelInit();

        //단일공
        if (isSingleBall)
        {
            //위치초기화
            ballcntscript.tmp2.transform.position = ballcntscript.tmp2.GetComponent<BallOut>().ballInitPos;

            //일시정지
            ballcntscript.tmp2.GetComponent<BallStatus>().isGoDown = false;
            ballcntscript.tmp2.GetComponent<BallStatus>().isGoLeft = false;
            ballcntscript.tmp2.GetComponent<BallStatus>().isGoRight = false;
            ballcntscript.tmp2.GetComponent<BallStatus>().isGoUp = false;

            ballcntscript.tmp2.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            ballcntscript.tmp2.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

            ballcntscript.tmp2.tag = "Ball";
        }

        //멀티공
        else
        {
            //위치초기화
            ballcntscript.ball_1.transform.position = ballcntscript.ball_1.GetComponent<BallOut>().ballInitPos;

            //일시정지
            ballcntscript.ball_1.GetComponent<BallStatus>().isGoDown = false;
            ballcntscript.ball_1.GetComponent<BallStatus>().isGoLeft = false;
            ballcntscript.ball_1.GetComponent<BallStatus>().isGoRight = false;
            ballcntscript.ball_1.GetComponent<BallStatus>().isGoUp = false;

            ballcntscript.ball_1.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            ballcntscript.ball_1.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

            ballcntscript.ball_1.tag = "Ball";

            //위치초기화
            ballcntscript.ball_2.transform.position = ballcntscript.ball_2.GetComponent<BallOut>().ballInitPos;

            //일시정지
            ballcntscript.ball_2.GetComponent<BallStatus>().isGoDown = false;
            ballcntscript.ball_2.GetComponent<BallStatus>().isGoLeft = false;
            ballcntscript.ball_2.GetComponent<BallStatus>().isGoRight = false;
            ballcntscript.ball_2.GetComponent<BallStatus>().isGoUp = false;

            ballcntscript.ball_2.GetComponent<BallStatus>().click.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            ballcntscript.ball_2.GetComponent<BallStatus>().click.gameObject.GetComponent<ClickEvent>().currentState = ClickEvent.ballstate.beforeClick;

            ballcntscript.ball_2.tag = "Ball";
        }

        //사운드
        if (!soundmanager.GetComponent<AudioSource>().isPlaying)
        {
            soundmanager.setClip(soundmanager.effect_[5].clip, soundmanager.effect_[5].volume);
            //Debug.Log("4444");
        }


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

        StageClearScript.ballCnt = 0;
        StageClearScript.isEnterBall = false;
        ClickEvent.isDoClick = 0;
    }
}