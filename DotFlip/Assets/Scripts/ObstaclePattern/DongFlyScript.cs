using UnityEngine;
using System.Collections;

public class DongFlyScript : MonoBehaviour
{
    //똥파리 갯수 4개로 제한
    public GameObject flyprefab;
    private bool isChase = false;
    private GameObject[] fly = new GameObject[4];
    public float flySpeed;
    private bool isReadyFly = false;
    private bool isTriggerEnter = false;

    private GameObject ball;
    private Vector3 ballPos;
    private Vector3[] direction = new Vector3[4];
    OutOfCamera outofcamera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
            isChase = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
            isChase = false;
    }
    
    IEnumerator ChaseStart()
    {
        isTriggerEnter = true;

        for (int i=0; i< fly.Length; i++)
        {
            fly[i] = Instantiate(flyprefab);
            fly[i].transform.position = gameObject.transform.position;
            fly[i].transform.eulerAngles =new Vector3(0,0,45);
        }
        
        yield return new WaitForSeconds(0.5f);

        isReadyFly = true;
        flySpeed *= 2f;
        
        while(true)
        {
            for(int i =0; i<fly.Length;i++)
            {
                direction[i] = (ballPos - fly[i].transform.position).normalized;        //똥파리와 공 간의 방향
                fly[i].transform.position = new Vector3(fly[i].transform.position.x + direction[i].x * flySpeed * Time.deltaTime, fly[i].transform.position.y + direction[i].y * flySpeed * Time.deltaTime, fly[i].transform.position.z);   //추적시작
            }
            yield return new WaitForEndOfFrame();
        }

        
    }

    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();

    }

    void Update()
    {
        ballPos = ball.transform.position;

        if (isChase && !isTriggerEnter)
            StartCoroutine(ChaseStart());

        if (fly[0] != null && !isReadyFly)
            fly[0].transform.Translate(flySpeed * Time.deltaTime, 0, 0);
        if (fly[1] != null && !isReadyFly)
            fly[1].transform.Translate(-flySpeed * Time.deltaTime, 0, 0);
        if (fly[2] != null && !isReadyFly)
            fly[2].transform.Translate(0, flySpeed * Time.deltaTime, 0);
        if (fly[3] != null && !isReadyFly)
            fly[3].transform.Translate(0, -flySpeed * Time.deltaTime, 0);    
    }

    void LateUpdate()
    {
        if (outofcamera.enterResetFunction)
        {
            for (int i = 0; i < fly.Length; i++)
            {
                Destroy(fly[i]);
            }

            isChase = false;
            isTriggerEnter = false;
            flySpeed = 2f;
            isReadyFly = false;
            EnterResetFunction.isEnterFunction = false;
        }
    }
}
