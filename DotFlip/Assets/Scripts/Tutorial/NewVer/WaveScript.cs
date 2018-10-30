using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 endScale;
    private float time_;

    public GameObject fingerImage;
    private Vector2 blockPosTmp;
    private Vector2 waveTmpPos;
    private Camera camera;

    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    IEnumerator WaveStart()
    {
        time_ = 0;
        while (true)
        {
            if (!fingerImage.activeSelf)
            {
                time_ = 0f;
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                break;
            }
                
            if (TutorialManager.tutorialCnt == 0)
            {
                //블럭위치
                gameObject.transform.position =  camera.WorldToScreenPoint(new Vector3(-8.56f, -0.13f));
            }

            else if(TutorialManager.tutorialCnt == 1 || TutorialManager.tutorialCnt == 3)
            {
                //쓰레기통위치
                gameObject.transform.position = camera.WorldToScreenPoint(new Vector2(6.97f, -4.86f));
            }

            else if (TutorialManager.tutorialCnt == 2)
            {
                //지정된 블럭위치
                gameObject.transform.position = camera.WorldToScreenPoint(GameObject.FindWithTag("Block").transform.position);
            }

            else if (TutorialManager.tutorialCnt == 4 || TutorialManager.tutorialCnt == 6)
            {
                //설정위치
                gameObject.transform.position = camera.WorldToScreenPoint(new Vector2(8.93f, -4.86f));
            }

            else if (TutorialManager.tutorialCnt == 5)
            {
                //프리즈위치
                gameObject.transform.position = camera.WorldToScreenPoint(new Vector2(8.85f, -1.23f));
            }

            else if (TutorialManager.tutorialCnt == 7)
            {
                //토끼위치
                gameObject.transform.position = camera.WorldToScreenPoint(new Vector2(-7.96f, 5.22f));
            }

            time_ += Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(startScale, endScale, time_);

            yield return new WaitForEndOfFrame();

            if (time_ > 1.0f)
            {
                time_ = 0f;
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }

        }
    }

    void Update()
    {
        if(!TutorialManager.isActive && fingerImage.activeSelf)
        {
            StartCoroutine(WaveStart());
            //TutorialManager.isActive = true;
        }
        
    }
}
