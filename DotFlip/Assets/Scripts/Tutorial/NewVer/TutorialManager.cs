using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    StageClearScript stageclearscript;

    //튜토리얼 관련
    public GameObject tutorialSkip;
    public GameObject[] tutorialMSG;
    public GameObject fingerImage;
    static public int tutorialCnt = 0;
    static public bool isActive = false;

    void Awake()
    {
        stageclearscript = gameObject.GetComponent<StageClearScript>();

        //듀토리얼해당 - 9, 21, 51
        if (stageclearscript.currentScene == 9 || stageclearscript.currentScene == 21 || stageclearscript.currentScene == 51)
        {
            tutorialSkip.SetActive(true);   //클릭방지 이미지 액티브
            tutorialMSG[0].SetActive(true);    //메세지 출력
        }

        // 듀토리얼해당 - 1
        else if(stageclearscript.currentScene == 1)
        {
            tutorialSkip.SetActive(true);   //클릭방지 이미지 액티브
            tutorialMSG[0].SetActive(true);    //메세지 출력
        }
    }
}
