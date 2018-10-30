using UnityEngine;
using System.Collections;

//공의 상태를 관리하는 스크립트 - 공에 스크립트 첨부

public class BallStatus : MonoBehaviour
{
    public Vector2 ball_InitPos;

    public float speed = 5;

    public bool isGoUp = false;
    public bool isGoDown = false;
    public bool isGoRight = false;
    public bool isGoLeft = false;

    public GameObject click;

    void OnTriggerEnter2D(Collider2D obj)
    {
       // Debug.Log("ballstatus : "+obj.gameObject);
        if (obj.tag == "Click")
            click = obj.gameObject;
        if (obj.tag == "Toilet")
            gameObject.SetActive(false);
    }


    void Start()
    {
        ball_InitPos = gameObject.transform.position;
    }

    void Update()
    {
        //Debug.Log(ball_InitPos);
        if (isGoUp)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);
        else if (isGoDown)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime);
        else if (isGoRight)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y);
        else if (isGoLeft)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y);
    }
}
