using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject text_;
    static public int cnt;
    static public bool[] isGetReady = new bool[5];
    static public bool isEnterFunction= false;

    public GameObject[] point;
    //point 0 - block click
    //point 1 - delKey click
    //point 2 - Setting click
    //point 3 - freeze click
    //point 4 - setting click
    //point 5 - rabbit click

    public GameObject[] images;
    //point 0 - block
    //point 1 - delKey
    //point 2 - Setting
    //point 3 - freeze
    //point 4 - rabbit
    //point 5 - other

    void Start()
    {
        //포인트 비활성화
        for (int i = 0; i < point.Length; i++)
            point[i].SetActive(false);

        //불투명도 짙게
        for(int i=0; i<images.Length;i++)
            images[i].SetActive(true);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        for (int i =0; i<isGetReady.Length;i++)
        {
            isGetReady[i] = false;
        }
        cnt = 0;
        DoBlockPlace_1(text_);
        
    }

    void OnMouseDown()
    {
        if (cnt == 1)
        {
            DoBlockPlace_2(text_);
            return;
        }

        else if (cnt == 2)
        {
            DoBlockPlace_3(text_);
            return;
        }

        if (cnt == 9)
        {
            DoTipDisplay(text_);
            return;
        }

        //초기화면
        if (cnt == 8)
        {
            DisplayDefault(text_);
            return;
        }


    }

    void DoBlockPlace_1(GameObject obj)
    {
        text_.GetComponent<Text>().text = "안녕 ~ 게임 방법에 대해서 간단하게 설명할게 . ";
        cnt = 1;
    }

    void DoBlockPlace_2(GameObject obj)
    {
        text_.GetComponent<Text>().text = "밑에 보이는 화살표를 적절하게 배치해서 똥을 변기통에 넣는 게 게임의 목표야 . ";
        cnt = 2;
    }
    void DoBlockPlace_3(GameObject obj)
    {
        text_.GetComponent<Text>().text = "배치 방법은 방향키 누른 후 드래그해서 원하는 위치에 놓으면 돼!! ";
        isEnterFunction = false;
        cnt = 3;
        point[0].SetActive(true);
        images[0].SetActive(false);
    }

    public void DoDelete_1(GameObject obj)
    {
        images[0].SetActive(true);
        images[1].SetActive(false);
        point[0].SetActive(false);
        point[1].SetActive(true);
        text_.GetComponent<Text>().text = "잘했어 !! 만약 배치한 방향키를 삭제하고 싶다면 우측 하단 쓰레기통을 누른 후 방향키를 다시 누르면 돼!! ";
        isEnterFunction = false;
        cnt = 4;
    }

    public void DoFreeze_1(GameObject obj)
    {
        images[1].SetActive(true);
        images[2].SetActive(false);
        point[1].SetActive(false);
        point[2].SetActive(true);   //셋팅이미지 
        text_.GetComponent<Text>().text = "마지막으로 현재 배치한 방향키를 저장하고 싶다면 설정 클릭 ";
        cnt = 5;
    }

    void DoFreeze_2(GameObject obj)
    {
        images[2].SetActive(true);
        images[3].SetActive(false);
        point[2].SetActive(false);
        point[3].SetActive(true);   //freeze이미지
        text_.GetComponent<Text>().text = "방향키 저장 버튼을 ON 상태로 설정하면 돼!! ";
        cnt = 6;
    }

    void ExitSetting(GameObject obj)
    {
        text_.GetComponent<Text>().text = "설정창을 한번 더 누른후, 게임 준비를 완료했다면 내 엉덩이를 눌러서 날 자극시켜봐 ";

        point[3].SetActive(false);
        point[4].SetActive(true);

        images[3].SetActive(true);
        images[2].SetActive(false);

        cnt = 7;
    }


    void DoDrop(GameObject obj)
    {
        point[4].SetActive(false);
        point[5].SetActive(true);

        images[2].SetActive(true);
        images[4].SetActive(false);

        text_.GetComponent<Text>().text = "설정창을 한번 더 누른후, 게임 준비를 완료했다면 내 엉덩이를 눌러서 날 자극시켜봐 ";
        cnt = 8;
    }


    void DoTipDisplay(GameObject obj)
    {
        text_.GetComponent<Text>().text = "안녕~ TIP하나 줄게 이번 스테이지부터는 미리 배치된 방향키를 모두 부숴야 똥을 변기통에 넣을 수 있어 ";
    }

    void DisplayDefault(GameObject obj)
    {
        text_.GetComponent<Text>().text = "";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (point[4] == null)
            return;

        point[4].SetActive(false);
        point[5].SetActive(false);

        for(int i =0; i<images.Length;i++)
            images[i].SetActive(false);
    }

    void Update()
    {
        if (cnt == 3 && isGetReady[0] && isEnterFunction)
            DoDelete_1(text_);
        else if (cnt == 4 && isGetReady[1] && isEnterFunction)
            DoFreeze_1(text_);
        else if (cnt == 5 && isGetReady[2] && isEnterFunction)
            DoFreeze_2(text_);
        else if (cnt == 6 && isGetReady[3] && isEnterFunction)
            ExitSetting(text_);
        else if (cnt == 7 && isGetReady[4] && isEnterFunction)
            DoDrop(text_);
    }
}
