using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageNumberDisplay : MonoBehaviour
{
    public void DisplayNumber(string num)
    { 
        gameObject.GetComponent<Text>().text = "Stage " + num;
    }

    public void DisplayNumberInit()
    {
        gameObject.GetComponent<Text>().text = "";
    }
}
