using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction
{
    up = 0,
    down,
    right,
    left
}

public class BoatMoveNewVer : MonoBehaviour
{
    public Point[] point;
    public float speed;
    private direction direction_;
    private int currentPoint;

    void PointCheck(direction dir ,int pointNum)
    {
        
    }

    void Update()
    {

    }

}
 