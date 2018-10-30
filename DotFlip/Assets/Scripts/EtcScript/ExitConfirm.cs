using UnityEngine;
using System.Collections;

public class ExitConfirm : MonoBehaviour
{
    public GameObject ConFirmWindow;

	void Start ()
    {
        ConFirmWindow.SetActive(false);
    }

    public void DisplayConfirmWindow()
    {
        ConFirmWindow.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        ConFirmWindow.SetActive(false);
    }
}
