using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class AdsManagerHelper : MonoBehaviour
{
    public GameObject ballCntDummy;
    public GameObject ads;
    public GameObject dontClickAnything;

    public static bool isCancel = false;

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            //광고 시청후에 보상처리
            case ShowResult.Finished:
                ads.SetActive(false);
                SingletonScript.Instance._BallCnt = 20;
                gameObject.GetComponent<BallCntDisplayScript>().displayObj.text = SingletonScript.Instance._BallCnt.ToString();
                GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>().dontClickAnything.SetActive(false);
                break;

            case ShowResult.Skipped:
                SingletonScript.Instance._BallCnt = 0;
                SingletonScript.Instance._currentTime = 150;
                isCancel = true;
                break;
            case ShowResult.Failed:
                SingletonScript.Instance._BallCnt = 0;
                SingletonScript.Instance._currentTime = 150;
                isCancel = true;
                break;
        }
    }

    void Start()
    {
        ads.SetActive(false);
    }
    //광고캔슬
    public void AdsCancel()
    {
        SingletonScript.Instance._BallCnt = 0;
        SingletonScript.Instance._currentTime = 150;

        SoundManager.instance.setClip(SoundManager.instance.effect_[1].clip, SoundManager.instance.effect_[1].volume);

        TutorialManager.tutorialCnt = 0;
        ballCntDummy.transform.position = new Vector3(1280, 710, 0);
        GameObject.FindWithTag("BGMNumber").GetComponent<StageNumberDisplay>().DisplayNumberInit();
        InGameManager.isStartScene = true;
        gameObject.GetComponent<InGameManager>().deleteBtn.SetActive(false);
        gameObject.GetComponent<InGameManager>().settingBtn.SetActive(false);
        gameObject.GetComponent<InGameManager>().confirmWindow.SetActive(false);
        gameObject.GetComponent<InGameManager>().listDisplay.SetActive(false);

        SceneManager.LoadScene("00");
        ads.SetActive(false);
        dontClickAnything.SetActive(false);
        //GameObject.FindWithTag("MainCamera").GetComponent<PrefabController>().SaveData();
    }
}