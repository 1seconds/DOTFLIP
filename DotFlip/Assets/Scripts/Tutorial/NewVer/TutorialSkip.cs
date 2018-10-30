using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkip : MonoBehaviour
{
    StageClearScript stageclearscript;
    TutorialManager tutorialmanager;

    void Start()
    {
        TutorialManager.isActive = false;
        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();
        tutorialmanager = stageclearscript.GetComponent<TutorialManager>();
    }

    void OnMouseDown()
    {
        //스테이지 9,21,51일경우
        if(stageclearscript.currentScene != 1)
        {
            tutorialmanager.tutorialMSG[0].SetActive(false);
            gameObject.SetActive(false);
            return;
        }
            
        
        //스테이지 1일경우
        else
        {
            //1단계 진입시 종료 - 인트로1
            if(tutorialmanager.tutorialMSG[0].activeSelf)
            {
                tutorialmanager.tutorialMSG[0].SetActive(false);
                tutorialmanager.tutorialMSG[1].SetActive(true);
            }

            //2단계 진입시 종료 - 인트로2
            else if(tutorialmanager.tutorialMSG[1].activeSelf)
            {
                tutorialmanager.tutorialMSG[1].SetActive(false);
                tutorialmanager.tutorialMSG[2].SetActive(true);
            }

            //3단계 진입시 종료 - 방향키
            else if (tutorialmanager.tutorialMSG[2].activeSelf)
            {
                tutorialmanager.tutorialMSG[2].SetActive(false);
                tutorialmanager.fingerImage.SetActive(true);
                gameObject.SetActive(false);
                
            }

            //4단계 진입시 종료 - 휴지통
            else if (tutorialmanager.tutorialMSG[3].activeSelf)
            {
                tutorialmanager.fingerImage.SetActive(true);
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.gameObject.transform.position = new Vector2(5.8f, -4.04f);
                tutorialmanager.tutorialMSG[3].SetActive(false);
                gameObject.SetActive(false);
            }

            //5단계 진입시 종료 - 설정1
            else if (tutorialmanager.tutorialMSG[4].activeSelf)
            {
                tutorialmanager.fingerImage.SetActive(true);
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.gameObject.transform.position = new Vector2(7.83f, -4.01f);
                tutorialmanager.tutorialMSG[4].SetActive(false);
                gameObject.SetActive(false);
            }

            //7단계 진입시 종료
            else if (tutorialmanager.tutorialMSG[5].activeSelf)
            {
                tutorialmanager.fingerImage.SetActive(true);
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.gameObject.transform.position = new Vector2(7.53f, -3.83f);
                tutorialmanager.tutorialMSG[5].SetActive(false);
                gameObject.SetActive(false);
                return;
            }
        }
    }
}
