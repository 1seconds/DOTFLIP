using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{

	public int index;
	Button myselfButton;

    SoundManager soundmanager;

    void Start()
    {
        soundmanager = GameObject.FindWithTag("MainCamera").GetComponentInChildren<SoundManager>();
        myselfButton = GetComponent<Button>();
		myselfButton.onClick.AddListener (ClickLoadBtn);
	}

	void ClickLoadBtn()
    {
        soundmanager.setClip(soundmanager.effect_[1].clip, soundmanager.effect_[1].volume);
        InGameManager.isStartScene = false;
        string loadtext = "0";	

		if (index < 10)
			loadtext += index.ToString ();
		else
			loadtext = index.ToString ();

        InGameManager.isStartScene = false;
        GameObject.FindWithTag("MainCamera").GetComponent<OutOfCamera>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().deleteBtn.SetActive(true);
        GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().settingBtn.SetActive(true);
        GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumber(loadtext);

        GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().ballCntDisplay.transform.position = new Vector3(2880, 1770, 0);
        SceneManager.LoadScene (loadtext);
	}



}
