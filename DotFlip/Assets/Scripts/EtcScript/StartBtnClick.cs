using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnClick : MonoBehaviour
{
    SoundManager soundmanager;
    InGameManager ingamemanager;
    public int highScene;
    private GameObject txtObj;

    //활성화 될 때
    void OnEnable()
    {
        //PlayerPrefs.SetInt("HighScene", 0);
        //highScene = PlayerPrefs.GetInt("HighScene");

        //GameObject.FindWithTag("MainCamera").GetComponent<PrefabController>().GetData();
        ingamemanager = GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>();
        PlayerPrefs.SetInt("oneCoinEnd", 0);
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        //ingamemanager.isOneCoinMode = false;
    }

    void GetData()
    {
        highScene = PlayerPrefs.GetInt("HighScene");
        //Debug.Log(highScene);
    }

    void OnMouseDown()
    {
        GetData();
        txtObj = GameObject.FindWithTag("TimeManager");
        GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(highScene.ToString());
        soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
        InGameManager.isStartScene = false;
        GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().enabled = true;
        ingamemanager.deleteBtn.SetActive(true);
        ingamemanager.settingBtn.SetActive(true);
        //ingamemanager.isOneCoinMode = false;
        ingamemanager.ballCntDisplay.transform.position = new Vector3(2880, 1770, 0);


        if (highScene == 0)
        {
            PlayerPrefs.SetInt("HighScene", 1);
            highScene = 1;
        }

        //씬이동
        if (highScene < 10)
            SceneManager.LoadScene("0" + highScene.ToString());
        else
            SceneManager.LoadScene(highScene.ToString());
    }
}
