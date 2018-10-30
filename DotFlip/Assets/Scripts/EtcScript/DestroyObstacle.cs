using UnityEngine;
using System.Collections;

//인게임 영역에서 벗어난 장애물을 파괴하는 스크립트

public class DestroyObstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
            Destroy(collider.gameObject);
    }
}
