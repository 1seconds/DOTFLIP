using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//블럭을 이동시키는 스크립트

public class TutorialBlockSet : MonoBehaviour
{
    Vector3 screenSpace;
    Vector3 offset;

    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
    }

    void OnMouseDown()
    {

        if (SingletonScript.Instance._DeleteKey == 1)
        {
            soundmanager.setClip(soundmanager.effect_[2].clip, soundmanager.effect_[2].volume);
            Destroy(gameObject);
            TutorialScript.isEnterFunction = true;
            TutorialScript.isGetReady[1] = true;
        }
            
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            screenSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        }
    }

    void OnMouseDrag()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        soundmanager.setClip(soundmanager.effect_[0].clip, soundmanager.effect_[0].volume);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
}