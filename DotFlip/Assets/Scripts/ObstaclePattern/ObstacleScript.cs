using UnityEngine;
using System.Collections;

//  Ball이 장애물 오브젝트에 충돌이 나서 게임을 리셋시키는 스크립트

public class ObstacleScript : MonoBehaviour
{
    OutOfCamera outofcamera;            //스크립트 참조
    public GameObject link;

    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();     //참조링크
        if (link == null)
            return;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //트리거안에 Ball이 들어갈경우 리셋
        if (collider.tag == "ReadyBall" || collider.tag == "Ball")
        {
            if (link == null || link.GetComponent<StageClearManager>() == null)
            {
                //Debug.Log("5555");
                soundmanager.setClip(soundmanager.effect_[5].clip, soundmanager.effect_[5].volume);
                outofcamera.InitFunction();
            }

            else
                link.GetComponent<StageClearManager>().InitFunction();
        }
           
    }
}
