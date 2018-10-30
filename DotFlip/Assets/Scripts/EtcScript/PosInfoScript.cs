using UnityEngine;
using System.Collections;

public class PosInfoScript : MonoBehaviour
{
    public GameObject[] basicObj;

    void Start()
    {
        //Down UI
        basicObj[0].transform.position = new Vector3(-2f, -5.0f, -1);
        basicObj[1].transform.position = new Vector3(-2f, -5.0f, -1);

        //Up UI
        basicObj[2].transform.position = new Vector3(4.0f, -5.0f, -1);
        basicObj[3].transform.position = new Vector3(4.0f, -5.0f, -1);

        //Right UI
        basicObj[4].transform.position = new Vector3(1.0f, -5.0f, -1);
        basicObj[5].transform.position = new Vector3(1.0f, -5.0f, -1);

        //Left UI
        basicObj[6].transform.position = new Vector3(-5f, -5.0f, -1);
        basicObj[7].transform.position = new Vector3(-5f, -5.0f, -1);

        //변기통
        basicObj[8].transform.position = new Vector2(9.5f, 0f);
        basicObj[8].transform.eulerAngles = new Vector3(0, 0, 270);

        //토끼
        basicObj[9].transform.position = new Vector2(-8f, 4.5f);

        //토끼똥
        basicObj[10].transform.position = new Vector2(-8f, 6f);
    }

}
