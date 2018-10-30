using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour
{
    private Color initColor;
    private Color doneColor;

    private float time;

    void Start()
    {
            

        initColor = new Color(1, 1, 1, 1);
        doneColor = new Color(1, 1, 1, 0);
        StartCoroutine(FadeColor());
    }


    IEnumerator FadeColor()
    {
        while(true)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            gameObject.GetComponent<Image>().color = Color.Lerp(initColor, doneColor, time * 0.5f);

            if (time * 0.5f > 1f)
                break;
        }

        SceneManager.LoadScene("00");
    }
}
