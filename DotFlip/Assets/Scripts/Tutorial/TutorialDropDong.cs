using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//클릭할때 발생하는 이벤트를 관리하는 스크립트 - 버튼에 스크립트 첨부

public class TutorialDropDong : MonoBehaviour
{
    private GameObject ball;
    public static bool isDoClick = false;   

    private bool isMouseDown = false;
    private bool isMouseUp = false;

    private GameObject rightImage;
    private GameObject leftImage;
    private GameObject upImage;
    private GameObject downImage;

    //SoundManager soundmanager;

    void OnMouseDown()
    {
        isMouseDown = true;
    }

    void OnMouseUp()
    {
        isMouseUp = true;
    }

    void Start()
    {
        //soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        ball = GameObject.FindWithTag("Ball");
        //ball.GetComponent<Rigidbody2D>().simulated = true;

        rightImage = GameObject.FindWithTag("RightImage");
        leftImage = GameObject.FindWithTag("LeftImage");
        downImage = GameObject.FindWithTag("DownImage");
        upImage = GameObject.FindWithTag("UpImage");
    }

    public void DoClick()
    {

        //셋팅중일때는 클릭할수없다.
        if (InGameManager.cantClick)
        {
            isMouseDown = false;
            isMouseUp = false;
            return;
        }

        else
        {
            //soundmanager.setClip(soundmanager.effect_[0].clip, soundmanager.effect_[0].volume);
            isDoClick = true;
            isMouseDown = false;
            isMouseUp = false;
            ball.tag = "ReadyBall";
            //ball.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //찍어내기 가능
            upImage.SetActive(false);
            downImage.SetActive(false);
            rightImage.SetActive(false);
            leftImage.SetActive(false);
        }
    }

    void Update()
    {
        if (isMouseDown && isMouseUp && !isDoClick && TutorialScript.cnt > 5)
            DoClick();
    }
}
