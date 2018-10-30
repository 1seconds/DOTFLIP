using UnityEngine;
using System.Collections;

public class MoveDrag : MonoBehaviour
{
    public Vector3 lerpStart;
    public Vector3 lerpEnd;
    private float time;
    public float speedConst;

    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.position = Vector3.Lerp(lerpStart, lerpEnd, time * speedConst);

        if (time * speedConst > 1)
        {
            time = 0;
        }
            
    }
}
