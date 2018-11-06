using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public Direct direct;
    public Block currentBlock;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            switch(currentBlock)
            {
                case Block.SLOW:
                    obj.GetComponent<PlayerMove>().SpeedDown();
                    break;
                case Block.BOOSTER:
                    obj.GetComponent<PlayerMove>().SpeedUp();
                    break;
            }
            obj.transform.position = gameObject.transform.position;
            obj.GetComponent<PlayerMove>().currentDirect = direct;
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!UISystem.isDelBtnOn)
            return;
        else
            gameObject.GetComponent<BlockDestroy>().enabled = true;
    }
}
