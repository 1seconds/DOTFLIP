using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//클릭할때 발생하는 이벤트를 관리하는 스크립트
public class ClickEvent : MonoBehaviour
{

    public GameObject ball;
    static public int isDoClick = 0;

    private bool isMouseDown = false;
    private bool isMouseUp = false;

    static public GameObject rightImage;
    static public GameObject leftImage;
    static public GameObject upImage;
    static public GameObject downImage;

    StageClearScript stageclearscript;

    public enum ballstate
    {
        beforeClick = 0,
        afterClick,
        waitingAnotherBall
    }

    public ballstate currentState;

    void OnMouseDown()
    {
        isMouseDown = true;
    }

    void OnMouseUp()
    {
        isMouseUp = true;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        //Debug.Log("clickevent : " + obj.gameObject);
        if (obj.tag.Contains("Ball"))
        {
            ball = obj.gameObject;
            //ball.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    public void Findtag()
    {
        rightImage = GameObject.FindWithTag("RightImage");
        leftImage = GameObject.FindWithTag("LeftImage");
        downImage = GameObject.FindWithTag("DownImage");
        upImage = GameObject.FindWithTag("UpImage");
    }

    void Start()
    {
        //soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        currentState = ballstate.beforeClick;
        Findtag();
        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();
    }

    public void DoClick()
    {
        //공두개
        if (!GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
        {
            if (BallCntScript.isReadyBallDouble)
                isDoClick = 0;
        }

        //공한개
        else
        {
            isDoClick = 1;
        }

        currentState = ballstate.afterClick;
        //soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
        //ball.GetComponent<Rigidbody2D>().simulated = false;

        isDoClick += 1;
        isMouseDown = false;
        isMouseUp = false;
        ball.tag = "ReadyBall";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ball.GetComponent<BallStatus>().isGoDown = true;

        if (isDoClick > 1)
        {
            //찍어내기 불가능
            upImage.SetActive(false);
            downImage.SetActive(false);
            rightImage.SetActive(false);
            leftImage.SetActive(false);
        }
    }

    void Update()
    {
        if(stageclearscript.currentScene == 1)
        {
            if (isMouseDown && isMouseUp && currentState == ballstate.beforeClick && !InGameManager.cantClick && TutorialManager.tutorialCnt > 6)
            {
                if(GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.activeSelf)
                {
                    GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.SetActive(false);
                    TutorialManager.isActive = false;
                }
                    

                DoClick();
            }
                
        }

        else if(isMouseDown && isMouseUp && currentState == ballstate.beforeClick && !InGameManager.cantClick)
            DoClick();
            
    }
}
