using UnityEngine;
using System.Collections;

//  UI블럭이 인게임 영역 밖에 생성될경우 제한시키는 스크립트

public class OutOfInGame : MonoBehaviour
{
    private bool isSureAllocate = false;
    private bool isEnterTrigger = false;

    private Vector3 beforePos;

    void OnMouseDrag()
    {
        isSureAllocate = true;
    }

    void OnMouseDown()
    {
        beforePos = gameObject.transform.position;
        isSureAllocate = false;
        isEnterTrigger = false;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains("DoNotAllocate"))
            isEnterTrigger = true;
        else
            isEnterTrigger = false;
    }

    void Update()
    {
        if (isSureAllocate && isEnterTrigger)
            gameObject.transform.position = beforePos;
        else
            return;
    }
}