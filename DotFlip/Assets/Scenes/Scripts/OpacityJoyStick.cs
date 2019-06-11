using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpacityJoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject joystick;

    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVec;

    void Start()
    {
        bgImg = joystick.GetComponent<Image>();
        joystickImg = joystick.transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        joystick.SetActive(true);
        inputVec = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;

        joystick.transform.position = Input.mousePosition;

        OnDrag(ped);
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVec = new Vector3(pos.x, pos.y, 0);
            inputVec = (inputVec.magnitude > 1.0f) ? inputVec.normalized : inputVec;

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVec.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVec.y * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputVec = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        joystick.SetActive(false);
    }

    public float GetHorizontalValue()
    {
        return inputVec.x;
    }

    public float GetVerticalValue()
    {
        return inputVec.y;
    }
}
