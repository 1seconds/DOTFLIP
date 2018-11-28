using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
            GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().GameMiss();
    }
}
