using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//  스테이지가 클리어 될시 씬전환시키는 스크립트

public class TutorialClear : MonoBehaviour
{
    BallStatus ballstatus;
    public string nextStage;
    public int highScene;
    public int currentScene;

    private bool isNullComponent = false;
    void Awake()
    {
        currentScene = int.Parse(nextStage) - 1;

        GetData();
        SaveData();
    }
    void Start()
    {
        
        ballstatus = GameObject.FindWithTag("Ball").GetComponent<BallStatus>();

        if (gameObject.GetComponent<StageClearManager>() == null)
            isNullComponent = true;

        else
            isNullComponent = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
        {
            ballstatus.isGoDown = false;
            ballstatus.isGoUp = false;
            ballstatus.isGoLeft = false;
            ballstatus.isGoRight = false;
            TutorialDropDong.isDoClick = false;

            SceneClear(nextStage);
        }
    }

    void SceneClear(string nextStage)
    {

        if (isNullComponent)
        {
            GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(nextStage);
            SceneManager.LoadScene(nextStage);
            GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = true;
            return;
        }

        if (StageClearManager.RemainNull)
        {
            GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(nextStage);
            GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = true;
            SceneManager.LoadScene(nextStage);
        }


        //여기 수정 - 모든블럭이 깨지지 않았을때
        else
            gameObject.GetComponent<StageClearManager>().InitFunction();
    }


    void SaveData()
    {
        if (currentScene > highScene)
        {
            PlayerPrefs.SetInt("HighScene", currentScene);
            highScene = PlayerPrefs.GetInt("HighScene");
        }

            
    }

    void GetData()
    {
        highScene = PlayerPrefs.GetInt("HighScene");
    }
}
