using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVec;

    void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position,ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVec = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            inputVec = (inputVec.magnitude > 1.0f) ? inputVec.normalized : inputVec;

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVec.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVec.y * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        inputVec = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputVec = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
