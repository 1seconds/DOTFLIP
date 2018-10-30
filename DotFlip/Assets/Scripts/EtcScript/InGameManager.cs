using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class InGameManager : MonoBehaviour
{
    public GameObject listDisplay;
    public GameObject confirmWindow;
    public GameObject dontdestroy;
    public GameObject ballCntDisplay;
    public GameObject timeTxt;
    public Text timeTxtMin;
    public Text timeTxtSec;
    public AudioSource backgroundSound;     //배경음
    public AudioSource effectiveSoundSet;   //효과음 - playoneshot으로 담을 그릇

    public GameObject soundBtn;         
    public GameObject freezeBtn;            
    public GameObject deleteBtn;            //00씬일때 inactive
    public GameObject settingBtn;           //00씬일때 inactive

    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite freezeOn;
    public Sprite freezeOff;
    public Sprite deleteModeOn;
    public Sprite deleteModeOff;

    //static public int deleteKey = 0;       //bool타입 대체 0 => false, 1 => true
    //static public int freezeKey = 0;       //bool타입 대체 0 => false, 1 => true
    //static public int soundKey = 1;        //bool타입 대체 0 => false, 1 => true

    public static bool isStart = false;         //시작할때 이외에 00씬으로 들어올경우 true가되어 파괴
    public static bool isStartScene = true;     //스타트씬일때 true반환
    public static bool cantClick = false;

    public GameObject dontClickAnything;

    private Vector3 tutorialTmpBlock;

    //public bool isTutorial = false;
    //public bool isOneCoinMode = false;
    StageClearScript stageclearscript;

    void Awake()
    {

        isStartScene = true;
        //게임시작이후 다시 00씬으로 들어올때 적용
        if (dontdestroy != null && isStart)
            Destroy(dontdestroy);

        //게임 시작할때 한번 적용
        else
            DontDestroyOnLoad(dontdestroy);
    }

    //void OnEnable()
    //{
    //    timeTxt = GameObject.FindWithTag("TimeManager");
    //    timeTxtMin = timeTxt.GetComponent<linkScript>().linkObj[0].GetComponent<Text>();
    //    timeTxtSec = timeTxt.GetComponent<linkScript>().linkObj[1].GetComponent<Text>();
    //}

    void Start ()
    {
        //ballCntDisplay.transform.position = new Vector3(1280, 710, 0);

        //Debug.Log(initVector);
        if (SingletonScript.Instance._DeleteKey == 1)
        {
            deleteBtn.GetComponent<Image>().sprite = deleteModeOn;
        }

        else
        {
            deleteBtn.GetComponent<Image>().sprite = deleteModeOff;
        }

        //Debug.Log(SingletonScript.Instance._FreezeKey);
        if (SingletonScript.Instance._FreezeKey == 1)
        {
            freezeBtn.GetComponent<Image>().sprite = freezeOn;
        }

        else
        {
            freezeBtn.GetComponent<Image>().sprite = freezeOff;
        }

        if (SingletonScript.Instance._SoundKey == 1)
        {
            backgroundSound.GetComponent<AudioSource>().volume = 1;
            effectiveSoundSet.GetComponent<AudioSource>().volume = 1;
            soundBtn.GetComponent<Image>().sprite = soundOn;
        }
            

        else
        {
            backgroundSound.GetComponent<AudioSource>().volume = 0;
            effectiveSoundSet.GetComponent<AudioSource>().volume = 0;
            soundBtn.GetComponent<Image>().sprite = soundOff;
        }

        isStart = true;
        listDisplay.SetActive(false);
        confirmWindow.SetActive(false);
        dontClickAnything.SetActive(false);
    }

    void Display()
    {
        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();

        if (TutorialManager.tutorialCnt == 4 && stageclearscript.currentScene == 1)
        {
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.gameObject.transform.position = new Vector2(7.16f, -0.59f);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialMSG[6].SetActive(true);
            TutorialManager.tutorialCnt = 5;
            listDisplay.SetActive(true);
        }

        // 1 튜토리얼이 아닐때
        else if (stageclearscript.currentScene != 1 || (TutorialManager.tutorialCnt > 4 && stageclearscript.currentScene == 1))
        {
            listDisplay.SetActive(true);
        }
    }

    public void SettingClick()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();

        //켜져있으면 - 비활성화
        if (listDisplay.activeSelf)
        {
            if(TutorialManager.tutorialCnt == 6 && stageclearscript.currentScene == 1)
            {
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialMSG[7].SetActive(false);
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.transform.position = new Vector3(-6.4f, 4.68f, -0.01f);
                GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.transform.eulerAngles = new Vector3(-0.393f, -0.58f, -319.721f);
                GameObject.FindWithTag("Click").GetComponent<BoxCollider2D>().enabled = true;
                TutorialManager.tutorialCnt = 7;
                listDisplay.SetActive(false);
                cantClick = false;
            }

            // 1 튜토리얼이 아닐때
            else if (stageclearscript.currentScene != 1 || (TutorialManager.tutorialCnt > 6 && stageclearscript.currentScene == 1))
            {
                listDisplay.SetActive(false);
                cantClick = false;
            }
        }


        //꺼져있으면 - 활성화
        else
        {
            Display();
            cantClick = true;
        }

    }

    public void FreezeClick()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
        //Debug.Log("55555");

        if (SingletonScript.Instance._FreezeKey == 1)
            FreezeOff();
        else
            FreezeOn();

    }

    public void SoundClick()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        if (SingletonScript.Instance._SoundKey == 1)
            SoundOff();
        else
            SoundOn();
    }

    public void DeleteClick()
    {
        stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();

        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        if (SingletonScript.Instance._DeleteKey == 1)
            DeleteOff();
        else
            DeleteOn();
    }

    void FreezeOn()
    {
        if(TutorialManager.tutorialCnt == 5 && stageclearscript.currentScene == 1)
        {
            //GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialSkip.SetActive(true);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialMSG[6].SetActive(false);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialMSG[7].SetActive(true);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.transform.position = new Vector3(7.39f, -4.12f, 0);
            TutorialManager.tutorialCnt = 6;
        }


        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        freezeBtn.GetComponent<Image>().sprite = freezeOn;
        SingletonScript.Instance._FreezeKey = 1;
        TutorialScript.isEnterFunction = true;
    }
    void FreezeOff()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        freezeBtn.GetComponent<Image>().sprite = freezeOff;
        SingletonScript.Instance._FreezeKey = 0;
        TutorialScript.isEnterFunction = true;
    }

    void SoundOn()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
        soundBtn.GetComponent<Image>().sprite = soundOn;
        backgroundSound.GetComponent<AudioSource>().volume = 1;
        effectiveSoundSet.GetComponent<AudioSource>().volume = 1;
        SingletonScript.Instance._SoundKey = 1;
    }
    void SoundOff()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        soundBtn.GetComponent<Image>().sprite = soundOff;
        backgroundSound.GetComponent<AudioSource>().volume = 0;
        effectiveSoundSet.GetComponent<AudioSource>().volume = 0;
        SingletonScript.Instance._SoundKey = 0;
    }

    void DeleteOn()
    {
        if(TutorialManager.tutorialCnt == 1 && stageclearscript.currentScene == 1)
        {

            tutorialTmpBlock = GameObject.FindWithTag("Block").gameObject.transform.position;
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.transform.position = new Vector3(tutorialTmpBlock.x - 1f, tutorialTmpBlock.y, tutorialTmpBlock.z);
            TutorialManager.tutorialCnt = 2;

            SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
            deleteBtn.GetComponent<Image>().sprite = deleteModeOn;
            SingletonScript.Instance._DeleteKey = 1;
        }

        else if(stageclearscript.currentScene != 1 || (TutorialManager.tutorialCnt > 1 && stageclearscript.currentScene == 1))
        {
            SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
            deleteBtn.GetComponent<Image>().sprite = deleteModeOn;
            SingletonScript.Instance._DeleteKey = 1;
        }
    }

    void DeleteOff()
    {
        if(TutorialManager.tutorialCnt == 3 && stageclearscript.currentScene == 1)
        {
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialSkip.SetActive(true);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().tutorialMSG[5].SetActive(true);
            GameObject.FindWithTag("Toilet").GetComponent<TutorialManager>().fingerImage.SetActive(false);
            TutorialManager.isActive = false;

            TutorialManager.tutorialCnt = 4;
            SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
            deleteBtn.GetComponent<Image>().sprite = deleteModeOff;
            SingletonScript.Instance._DeleteKey = 0;
        }

        else if(stageclearscript.currentScene != 1 || (TutorialManager.tutorialCnt > 3 && stageclearscript.currentScene == 1))
        {
            SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
            deleteBtn.GetComponent<Image>().sprite = deleteModeOff;
            SingletonScript.Instance._DeleteKey = 0;
        }         
    }

    public void QuitConfirm()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
        confirmWindow.SetActive(true);
    }

    public void Quit()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        //00씬일경우 - 게임종료
        if (isStartScene)
        {
            Debug.Log("게임을 종료합니다.");
            Application.Quit();
        }
            
        //인게임 씬일경우 - 00씬으로 이동
        else
        {
            //Debug.Log(initVector);
            ballCntDisplay.transform.position = new Vector3(1280,710,0);
            GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumberInit();
            TutorialManager.tutorialCnt = 0;
            isStartScene = true;
            deleteBtn.SetActive(false);
            settingBtn.SetActive(false);
            confirmWindow.SetActive(false);
            listDisplay.SetActive(false);
            SceneManager.LoadScene("00");
            gameObject.GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();
            //Debug.Log("11111");
        }
    }

    //캔슬
    public void Cancel()
    {
        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
        listDisplay.SetActive(false);
        confirmWindow.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);
            

            if (listDisplay.activeSelf || confirmWindow.activeSelf)
            {
                stageclearscript = GameObject.FindWithTag("Toilet").GetComponent<StageClearScript>();

                if(stageclearscript.currentScene == 1 && listDisplay.activeSelf)
                {
                    confirmWindow.SetActive(false);
                }

                else
                {
                    listDisplay.SetActive(false);
                    confirmWindow.SetActive(false);
                }

            }
            else
                QuitConfirm();
        }
    }

}
