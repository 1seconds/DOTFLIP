using UnityEngine;
using System.Collections;

public class GoDownScript : MonoBehaviour
{
    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
    }
    IEnumerator Go(GameObject obj)
    {
        yield return new WaitForSeconds(0.1f);

        //obj.GetComponent<Rigidbody2D>().simulated = true;
        obj.GetComponent<BallStatus>().isGoDown = false;
        obj.GetComponent<BallStatus>().isGoUp = false;
        obj.GetComponent<BallStatus>().isGoLeft = false;
        obj.GetComponent<BallStatus>().isGoRight = false;

        obj.transform.position = gameObject.transform.position;
        obj.GetComponent<BallStatus>().isGoDown = true;

        //장애물일경우
        if (gameObject.GetComponent<OutOfInGame>() == null)
        {
            gameObject.SetActive(false);
            soundmanager.setClip(soundmanager.effect_[2].clip, soundmanager.effect_[2].volume);
        }

        //방향키 UI일 경우
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            soundmanager.setClip(soundmanager.effect_[2].clip, soundmanager.effect_[2].volume);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
        {
            StartCoroutine(Go(collider.gameObject));
        }
    }
}

