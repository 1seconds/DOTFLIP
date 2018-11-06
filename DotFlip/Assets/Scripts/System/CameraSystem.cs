using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject camera_;

    public Vector3 horizonMovedPos;
    public Vector3 verticalMovedPos;

    private float time_ = 0;
    public float waitingTime;

    private StageSystem stageSystem;

    public void Start()
    {
        stageSystem = gameObject.GetComponent<StageSystem>();
    }

    private void Update()
    {
        if(player.transform.position.y < - 5f)
        {
            player.GetComponent<PlayerMove>().speed = 1.0f;
            time_ += Time.deltaTime;
            camera_.transform.position = Vector3.Lerp(camera_.transform.position, verticalMovedPos, time_ / waitingTime);
            if (0.1f < time_ / waitingTime)
            {
                for(int i =0; i < stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo.Length; i++)
                {
                    if (stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].stageDirect.Equals(Direct.DOWN))
                    {
                        if(stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage < 10)
                            SceneManager.LoadScene("0" + (stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage).ToString());
                        else
                            SceneManager.LoadScene(stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage.ToString());
                    }
                        
                    else
                        continue;
                }
            }

        }

        else if(player.transform.position.x > 9.5f)
        {
            player.GetComponent<PlayerMove>().speed = 0.5f;
            time_ += Time.deltaTime;
            camera_.transform.position = Vector3.Lerp(camera_.transform.position, horizonMovedPos, time_ / waitingTime);
            if (0.1f < time_ / waitingTime)
            {
                for (int i = 0; i < stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo.Length; i++)
                {
                    if (stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].stageDirect.Equals(Direct.RIGHT))
                    {
                        if (stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage < 10)
                            SceneManager.LoadScene("0" + (stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage).ToString());
                        else
                            SceneManager.LoadScene(stageSystem.stage[stageSystem.currentStage - 1].nextStageInfo[i].nextStage.ToString());
                    }
                    else
                        continue;
                }
            }
        }
    }
}
