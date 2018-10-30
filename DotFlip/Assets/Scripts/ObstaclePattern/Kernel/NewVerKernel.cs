using UnityEngine;
using System.Collections;

public class NewVerKernel : MonoBehaviour
{
    public GameObject otherKernel;
    public GameObject CenterColliderObj;
    public GameObject SideColliderObj;

    CenterColliderKernel centercolliderobj;
    SideColliderKernel sidecolliderobj;

    static public bool isEnterFunction = false;
    //OutOfCamera outofcamera;

    //private bool isAbleKernel = false;

    void Start()
    {
        //outofcamera = GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>();
        centercolliderobj = CenterColliderObj.GetComponent<CenterColliderKernel>();
        sidecolliderobj = SideColliderObj.GetComponent<SideColliderKernel>();
    }

    public static IEnumerator EnterKernel()
    {
        isEnterFunction = true;
        yield return new WaitForSeconds(0.3f);
        isEnterFunction = false;
    }

    void PassToOtherKernel(GameObject obj)
    {
        obj.transform.position = otherKernel.transform.position;
    }

    void Update()
    {
        ////커널동작여부확인
        //if (outofcamera.isSingleBall)
        //    if (GameObject.FindWithTag("Click").GetComponent<ClickEvent>().currentState == ClickEvent.ballstate.beforeClick)
        //        isAbleKernel = false;
        //    else if (GameObject.FindWithTag("Click").GetComponent<ClickEvent>().currentState == ClickEvent.ballstate.afterClick)
        //        isAbleKernel = true;

        //밖에서 안으로
        if (!centercolliderobj.isEnterTrigger && sidecolliderobj.isEnterTrigger && !isEnterFunction/* && isAbleKernel*/)
        {
            StartCoroutine(EnterKernel());
            PassToOtherKernel(sidecolliderobj.thisBall);
        }

    }
}
