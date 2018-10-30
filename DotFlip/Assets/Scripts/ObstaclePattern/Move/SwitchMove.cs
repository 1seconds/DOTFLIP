using UnityEngine;
using System.Collections;

public class SwitchMove : MonoBehaviour
{
    public bool isSwitchOn = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ReadyBall")
            isSwitchOn = true;
    }
}
