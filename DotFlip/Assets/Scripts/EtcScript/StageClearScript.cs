using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//  스테이지가 클리어 될시 씬전환시키는 스크립트

public class StageClearScript : MonoBehaviour
{
    BallStatus ballstatus;
    public string nextStage;
	public int highScene;
	public int currentScene;

	private int oneCoinCurrentScene;
	private int oneCoinHighScene;

    private bool isNullComponent = false;
    static public int ballCnt = 0;
    static public bool isEnterBall = false;

    void Awake()
    {
        currentScene = int.Parse(nextStage) - 1;
        oneCoinCurrentScene = int.Parse(nextStage) - 1;

        GetData();
        SaveData();

        //if (GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().isOneCoinMode)
        //{
        //    GetOneCoinData();
        //    SaveOneCoinData();
        //}
    }
    void Start()
    {
		if(GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
            ballstatus = GameObject.FindWithTag("Ball").GetComponent<BallStatus>();



        if (gameObject.GetComponent<StageClearManager>() == null)
            isNullComponent = true;

        else
            isNullComponent = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall" && GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
        {
            ballstatus.isGoDown = false;
            ballstatus.isGoUp = false;
            ballstatus.isGoLeft = false;
            ballstatus.isGoRight = false;
            ClickEvent.isDoClick = 0;

            SceneClear(nextStage);
        }
        else if(collider.tag == "ReadyBall" && !GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
        {
            SceneClear(nextStage);
        }
    }

    void SceneClear(string nextStage)
    {
        if(isNullComponent || StageClearManager.RemainNull)
        {
            //블록제거 요소가 없거나 싱글볼일때
            if (isNullComponent || GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
            {
                PlayerPrefs.SetInt("HighScene", currentScene);
                GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(nextStage);
                GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = true;
                SceneManager.LoadScene(nextStage);
                return;
            }

            //두개의 볼이 있을때
            else if(!GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall)
            {
                ballCnt += 1;
                isEnterBall = true;

                if (ballCnt > 1)
                {
                    isEnterBall = false;
                    PlayerPrefs.SetInt("HighScene", currentScene);
                    GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(nextStage);
                    GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().isSingleBall = true;
                    ballCnt = 0;
                    ClickEvent.isDoClick = 0;
                    SceneManager.LoadScene(nextStage);
                    return;
                }
            }

            else
            {
                Debug.Log("error");
            }
                
        }
        //여기 수정 - 모든블럭이 깨지지 않았을때
        else
        {
            gameObject.GetComponent<StageClearManager>().InitFunction();
        }
            
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

	void GetOneCoinData(){
		oneCoinHighScene = PlayerPrefs.GetInt("oneCoinHighScene");
	}

	void SaveOneCoinData(){
		  if (oneCoinCurrentScene > oneCoinHighScene)
		{
			PlayerPrefs.SetInt("oneCoinHighScene", oneCoinCurrentScene);
			oneCoinHighScene = PlayerPrefs.GetInt("oneCoinHighScene");
		}
	}


}
