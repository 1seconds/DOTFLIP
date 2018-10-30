using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerBlink : MonoBehaviour
{
    private Color initColor;
    public Color toColor;
    public Color currentColor;

    private float time_;

    void Start()
    {
        initColor = new Color(0,0,0,1);
        StartCoroutine(BlinkStart());
    }


    IEnumerator BlinkStart()
    {
        while (true)
        {
            time_ += Time.deltaTime;
            currentColor = Color.Lerp(initColor, toColor, time_);
            gameObject.GetComponent<SpriteRenderer>().color = currentColor;
            yield return new WaitForEndOfFrame();

            if (time_ > 1.0f)
            {
                time_ = 0f;
                break;
            }
        }
        StartCoroutine(BlinkStart());
    }

    void Update()
    {
        if (!TutorialManager.isActive)
        {
            StartCoroutine(BlinkStart());
            TutorialManager.isActive = true;
        }
    }
}
