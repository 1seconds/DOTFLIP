using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//  전반적으로 프리팹을 관리하는 스크립트
//  공의 갯수를 새려주는 스크립트

public class PrefabController : MonoBehaviour
{
    static public GameObject[] block = new GameObject[50];

    void FixedUpdate()
    {
        block = GameObject.FindGameObjectsWithTag("Block");
    }
}