using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
    }

    public void ConfirmWindow()
    {
        soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
        GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().confirmWindow.SetActive(true);

    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);

            //확인창이 활성화 되어있다면
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ExitConfirm>().ConFirmWindow.activeSelf)
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ExitConfirm>().ConFirmWindow.SetActive(false);

            //활성화가 안되있다면
            else
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ExitConfirm>().DisplayConfirmWindow();
        }
    }
}
