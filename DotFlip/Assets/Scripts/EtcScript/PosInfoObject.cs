using UnityEngine;
using System.Collections;

[System.Serializable]
public class Object
{
    public GameObject obj;
    public float xPos;
    public float yPos;
}

public class PosInfoObject : MonoBehaviour
{
    public Object[] infoGameObject;

    void Start()
    {
        for(int i =0; i<infoGameObject.Length;i++)
        {
            infoGameObject[i].obj.transform.position = new Vector2(infoGameObject[i].xPos, infoGameObject[i].yPos);
        }
        
    }
}





