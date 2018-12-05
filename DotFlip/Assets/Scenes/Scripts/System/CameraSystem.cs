using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    public GameObject camera_;
    public CameraView currentCameraView;
    

    private Vector3 rightMovedPos = new Vector3(20.6f, 0, -10);
    private Vector3 downMovedPos = new Vector3(0, -11.7f, -10);
    private Vector3 leftMovedPos = new Vector3(-20.6f, 0, -10);
    private Vector3 upMovedPos = new Vector3(0, 11.7f, -10);

    private float time_ = 0;

    private StageSystem stageSystem;

    public void Start()
    {
        stageSystem = gameObject.GetComponent<StageSystem>();
        currentCameraView = CameraView.CENTER;
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if ((player.transform.localPosition.y < -5f && player.transform.localPosition.y > -6.5f) && player.GetComponent<PlayerMove>().currentDirect.Equals(Direct.DOWN))
        {
            currentCameraView = CameraView.DOWNSIDE;
            player.GetComponent<PlayerMove>().speed = 1.0f;
            time_ += Time.deltaTime;
            camera_.transform.position = Vector3.Lerp(camera_.transform.position, downMovedPos, time_);
        }
        else if ((player.transform.localPosition.y < -5f && player.transform.localPosition.y > -6.5f) && player.GetComponent<PlayerMove>().currentDirect.Equals(Direct.UP))
        {
            currentCameraView = CameraView.CENTER;
            player.GetComponent<PlayerMove>().speed = 1.0f;
            time_ += Time.deltaTime;
            camera_.transform.position = Vector3.Lerp(camera_.transform.position, new Vector3(0, 0, -10), time_);
        }
        else
        {
            time_ = 0;
            player.GetComponent<PlayerMove>().speed = 5.0f;
        }
    }
}
