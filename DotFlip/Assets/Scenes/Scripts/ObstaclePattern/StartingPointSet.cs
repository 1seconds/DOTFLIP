using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointSet : MonoBehaviour
{
    private Vector3 tmpVector;
    private float restX;    //나머지
    private float restY;
    private int modX;       //몫
    private int modY;

    void Start ()
    {
        tmpVector = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
        restX = tmpVector.x % 80;
        restY = tmpVector.y % 80;
        modX = (int)(tmpVector.x / 80);
        modY = (int)(tmpVector.y / 80);
        
        //아래방향
        if(modY < 0)
        {
            if (restX < 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * modY, 0));
                    GameSystem.TileObject(CameraView.DOWNSIDE, modX - 1, modY + 8 , false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.DOWNSIDE, modX - 1, modY + 8, false);
                }
            }
            else if (restX >= 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * modY, 0));
                    GameSystem.TileObject(CameraView.DOWNSIDE, modX, modY + 8, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.DOWNSIDE, modX, modY + 8, false);
                }
            }
            gameObject.transform.position += new Vector3(0, 0, 10);
        }

        //위쪽
        else if(modY > 6)
        {
            if (restX < 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * modY, 0));
                    GameSystem.TileObject(CameraView.UPSIDE, modX - 1, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.UPSIDE, modX - 1, modY, false);
                }
            }
            else if (restX >= 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * modY, 0));
                    GameSystem.TileObject(CameraView.UPSIDE, modX, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.UPSIDE, modX, modY, false);
                }
            }
            gameObject.transform.position += new Vector3(0, 0, 10);
        }

        //왼쪽
        else if (modX > 13)
        {
            if (restX < 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * modY, 0));
                    GameSystem.TileObject(CameraView.RIGHTSIDE, modX - 1, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.RIGHTSIDE, modX - 1, modY, false);
                }
            }
            else if (restX >= 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * modY, 0));
                    GameSystem.TileObject(CameraView.RIGHTSIDE, modX, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.RIGHTSIDE, modX, modY, false);
                }
            }
            gameObject.transform.position += new Vector3(0, 0, 10);
        }

        //센터
        else
        {
            if (restX < 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * modY, 0));
                    GameSystem.TileObject(CameraView.CENTER, modX - 1, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * modX, 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.CENTER, modX - 1, modY, false);
                }
            }
            else if (restX >= 40)
            {
                if (restY < 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * modY, 0));
                    GameSystem.TileObject(CameraView.CENTER, modX, modY - 1, false);
                }
                else if (restY >= 40)
                {
                    gameObject.transform.position = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * (modY + 1), 0));
                    GameSystem.TileObject(CameraView.CENTER, modX, modY, false);
                }
            }
            gameObject.transform.position += new Vector3(0, 0, 10);
        }

        
    }
}
