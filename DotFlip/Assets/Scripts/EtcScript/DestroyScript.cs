using UnityEngine;
using System.Collections;

//쓰레기통 스크립트 - UI블럭에 스크립트 첨부

public class DestroyScript : MonoBehaviour
{
    private bool isSureDestroy = false;
    private bool isEnterTrigger = false;

    void OnMouseUp()
    {
        isSureDestroy = true;
    }

    void OnMouseDown()
    {
        isSureDestroy = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("Delete"))
            isEnterTrigger = true;
        else
            isEnterTrigger = false;
    }
    
    void Update()
    {
        if (isSureDestroy && isEnterTrigger)
        {
            Destroy(gameObject);
        }
    }
}
