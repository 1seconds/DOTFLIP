using UnityEngine;
using System.Collections;

public class Go7hourScript : MonoBehaviour
{

    public float speed;
    BallStatus ballstatus;

    void Start()
    {
        ballstatus = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallStatus>();
    }

    IEnumerator Go()
    {
        yield return new WaitForSeconds(0.1f);

        //ballstatus.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        ballstatus.isGoDown = false;
        ballstatus.isGoUp = false;
        ballstatus.isGoLeft = false;
        ballstatus.isGoRight = false;

        ballstatus.gameObject.transform.position = gameObject.transform.position;

        ballstatus.isGoDown = true;
        ballstatus.isGoLeft = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
        {
            StartCoroutine(Go());
        }
    }
}
