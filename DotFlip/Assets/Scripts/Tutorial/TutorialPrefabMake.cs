using UnityEngine;
using System.Collections;

public class TutorialPrefabMake : MonoBehaviour
{
    public GameObject prefab;                       //프리팹 생성 오브젝트
    private bool isEnterTriggerNotCreate = false;
    private bool isEnterTriggerDestroy = false;

    Vector3 screenSpace;    //  카메라의 위치영역을 월드좌표로 수치화
    Vector3 offset;         //  월드좌표에서 이동한 위치 수치화
    Vector3 currentPos;     //  초기위치 기억

    SoundManager soundmanager;

    void Start()
    {
        currentPos = gameObject.transform.position;
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
    }



    void OnMouseDown()
    {
        if (TutorialScript.cnt > 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            screenSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        }
        else
            return;
    }

    void OnMouseDrag()
    {
        if (TutorialScript.cnt > 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
        }
        else
            return;
    }

    void OnMouseUp()
    {
        //이미지가 파괴하는곳이나 UI블럭에 위치할경우 다시 이미지를 초기위치로 반환
        if (isEnterTriggerDestroy || isEnterTriggerNotCreate)
            gameObject.transform.position = currentPos;

        //블럭이 인게임상에서 동작할시 프리팹생성
        else
        {
            soundmanager.setClip(soundmanager.effect_[0].clip, soundmanager.effect_[0].volume);
            Instantiate(prefab);
            prefab.transform.position = gameObject.transform.position;
            prefab.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1.0f);
            prefab.tag = "Block";
            gameObject.transform.position = currentPos;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            TutorialScript.isGetReady[0] = true;
            TutorialScript.isEnterFunction = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("Delete"))
            isEnterTriggerDestroy = true;
        else
            isEnterTriggerDestroy = false;
        if (collider.gameObject.name.Contains("DoNotAllocate"))
            isEnterTriggerNotCreate = true;
        else
            isEnterTriggerNotCreate = false;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("Delete"))
            isEnterTriggerDestroy = false;
        if (collider.gameObject.name.Contains("DoNotAllocate"))
            isEnterTriggerNotCreate = false;
    }

    void Update()
    {
        //프리팹이 계속 생산되어지고, 연결이 끊어질때마다 자동으로 링크를 연결시켜줌
        if (prefab == null)
        {
            if (gameObject.name.Contains("Left"))
                prefab = GameObject.FindGameObjectWithTag("NotYetMovedLeft");
            if (gameObject.name.Contains("Right"))
                prefab = GameObject.FindGameObjectWithTag("NotYetMovedRight");
            if (gameObject.name.Contains("Up"))
                prefab = GameObject.FindGameObjectWithTag("NotYetMovedUp");
            if (gameObject.name.Contains("Down"))
                prefab = GameObject.FindGameObjectWithTag("NotYetMovedDown");
        }
    }
}

