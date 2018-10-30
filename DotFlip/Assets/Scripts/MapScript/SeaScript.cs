using UnityEngine;
using System.Collections;

public class SeaScript : MonoBehaviour
{
    OutOfCamera outofcamera;            //스크립트 참조

    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();     //참조링크
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //트리거안에 Ball이 들어갈경우 리셋
        if (collider.tag == "ReadyBall" || collider.tag == "Ball")
        {
            if (gameObject.tag.Contains("BoatArea"))
                return;

            else if (gameObject.tag.Contains("Sea"))
            {
                //Debug.Log("1111");
                soundmanager.setClip(soundmanager.effect_[5].clip, soundmanager.effect_[5].volume);
                outofcamera.InitFunction();
            }
            else
                Debug.Log("error");
        }

    }
}
