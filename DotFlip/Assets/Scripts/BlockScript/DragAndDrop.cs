using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//블럭을 이동시키는 스크립트

public class DragAndDrop : MonoBehaviour
{
    Vector3 screenSpace;
    Vector3 offset;

    SoundManager soundmanager;
    TutorialManager tutorialmanager;
    StageClearScript stageclearscript;

    void Start()
    {
        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
    }

    void OnMouseDown()
    {
        if (SingletonScript.Instance._DeleteKey == 1)
        {
            soundmanager.setClip(soundmanager.effect_[2].clip, soundmanager.effect_[2].volume);
            Destroy(gameObject);

            if(TutorialManager.tutorialCnt == 2 && stageclearscript.currentScene == 1)
            {
                tutorialmanager = GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>();
                tutorialmanager.fingerImage.transform.position = new Vector3(5.45f, -3.94f, -1f);
                TutorialManager.tutorialCnt = 3;
            }
        }
        else
        {
            //공이 출발하면 드래그 금지
            if (BallCntScript.readyball.Length > 0 || StageClearScript.isEnterBall)
                return;

            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
                screenSpace = Camera.main.WorldToScreenPoint(transform.position);
                offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
    }
    void OnMouseDrag()
    {
        //공이 출발하면 드래그 금지
        if (BallCntScript.readyball.Length > 0 || StageClearScript.isEnterBall)
            return;
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        soundmanager.setClip(soundmanager.effect_[0].clip, soundmanager.effect_[0].volume);
    }
}