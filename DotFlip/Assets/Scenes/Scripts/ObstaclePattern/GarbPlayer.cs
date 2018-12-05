using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbPlayer : MonoBehaviour
{
    private bool isGrabOn = false;

    private void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            isGrabOn = false;
        }
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Player") && !isGrabOn)
        {
            switch (obj.GetComponent<PlayerMove>().currentDirect)
            {
                case Direct.DOWN:
                    if (obj.transform.position.y < gameObject.transform.position.y)
                    {
                        obj.transform.position = gameObject.transform.position;
                        obj.GetComponent<PlayerMove>().currentDirect = Direct.HOLD;
                        GameObject.FindWithTag("GameManager").GetComponent<UISystem>().DownSideCanvasOn();
                        GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().currentGameState = GameState.READY;
                        isGrabOn = true;
                    }
                    break;
                case Direct.UP:
                    if (obj.transform.position.y > gameObject.transform.position.y)
                    {
                        obj.transform.position = gameObject.transform.position;
                        obj.GetComponent<PlayerMove>().currentDirect = Direct.HOLD;
                        GameObject.FindWithTag("GameManager").GetComponent<UISystem>().DownSideCanvasOn();
                        GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().currentGameState = GameState.READY;
                        isGrabOn = true;
                    }
                    break;
                case Direct.RIGHT:
                    if (obj.transform.position.x > gameObject.transform.position.x)
                    {
                        obj.transform.position = gameObject.transform.position;
                        obj.GetComponent<PlayerMove>().currentDirect = Direct.HOLD;
                        GameObject.FindWithTag("GameManager").GetComponent<UISystem>().DownSideCanvasOn();
                        GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().currentGameState = GameState.READY;
                        isGrabOn = true;
                    }
                    break;
                case Direct.LEFT:
                    if (obj.transform.position.x < gameObject.transform.position.x)
                    {
                        obj.transform.position = gameObject.transform.position;
                        obj.GetComponent<PlayerMove>().currentDirect = Direct.HOLD;
                        GameObject.FindWithTag("GameManager").GetComponent<UISystem>().DownSideCanvasOn();
                        GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().currentGameState = GameState.READY;
                        isGrabOn = true;
                    }
                    break;
            }
        }
    }
}
