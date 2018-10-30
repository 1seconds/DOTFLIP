using UnityEngine;
using System.Collections;

public class CreatePrefabScript : MonoBehaviour
{
    public GameObject prefab;                       //프리팹 생성 오브젝트
    private bool isEnterTriggerNotCreate = false;

    Vector3 screenSpace;    //  카메라의 위치영역을 월드좌표로 수치화
    Vector3 offset;         //  월드좌표에서 이동한 위치 수치화
    Vector3 currentPos;     //  초기위치 기억

    SoundManager soundmanager;
    TutorialManager tutorialmanager;

    void Start()
    {
        currentPos = gameObject.transform.position;
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        tutorialmanager = GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>();

        if (tutorialmanager == null)
            return;

    }

    void OnMouseDown()
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
        //이미지가 파괴하는곳이나 UI블럭에 위치할경우 다시 이미지를 초기위치로 반환
        if(isEnterTriggerNotCreate)
            gameObject.transform.position = currentPos;

        //블럭이 인게임상에서 동작할시 프리팹생성
        else
        {

            //튜토리얼
            if (tutorialmanager != null)
            {
                //1스테이지일경우
                if (tutorialmanager.GetComponent<StageClearScript>().currentScene == 1)
                {
                    if (TutorialManager.tutorialCnt == 0)
                    {
                        TutorialManager.tutorialCnt = 1;
                        tutorialmanager.tutorialSkip.SetActive(true);
                        tutorialmanager.tutorialMSG[3].SetActive(true);
                        tutorialmanager.fingerImage.GetComponent<MoveDrag>().enabled = false;
                        tutorialmanager.fingerImage.SetActive(false);
                        TutorialManager.isActive = false;
                    }

                }
            }

            Instantiate(prefab);
            prefab.transform.position = gameObject.transform.position;
            prefab.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1.0f);
            prefab.tag = "Block";
            gameObject.transform.position = currentPos;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            soundmanager.setClip(soundmanager.effect_[0].clip, soundmanager.effect_[0].volume);

        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("NotAllocate"))
            isEnterTriggerNotCreate = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("NotAllocate"))
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

