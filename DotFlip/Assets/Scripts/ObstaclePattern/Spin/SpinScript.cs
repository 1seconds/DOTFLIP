using UnityEngine;
using System.Collections;

//btn이 활성화 될시 회전하는 스크립트

public class SpinScript : MonoBehaviour
{
    public GameObject btn;
    private GameObject mainCamera;

    public float speed;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {   
        if(btn.GetComponent<SpinSwitchScript>().isAbleSpin)
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (mainCamera.GetComponent<OutOfCamera>().enterResetFunction)
        {
            btn.GetComponent<SpinSwitchScript>().isAbleSpin = false;
            EnterResetFunction.isEnterFunction = false;
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
