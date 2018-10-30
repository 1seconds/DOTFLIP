using UnityEngine;
using System.Collections;

public class WebScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
		if(collider.gameObject.GetComponent<BallStatus>() != null)
        	collider.gameObject.GetComponent<BallStatus>().speed  = 5;
    }
}
