using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            GameObject.FindWithTag("GameManager").GetComponent<GameSystem>().GameMiss();
    }
}
