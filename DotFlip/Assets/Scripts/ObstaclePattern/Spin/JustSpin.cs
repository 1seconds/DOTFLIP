using UnityEngine;
using System.Collections;

//단지 해당 오브젝트의 회전을 시키는 스크립트

public class JustSpin : MonoBehaviour
{
    public float speed;
    private float curAngle;

    void Update()
    {
        curAngle += speed;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, curAngle);
    }
}
