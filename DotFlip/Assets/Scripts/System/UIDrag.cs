using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UISet uiSet;
    public GameObject block;
    private Camera mainCamera;
    private GameObject blockPrefab;
    static public GameObject targetBlock;
    private bool isPaintOn = false;

    private float restX;    //나머지
    private float restY;
    private int modX;       //몫
    private int modY;

    private float intervalValue = 35;

    private void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        targetBlock = null;
        blockPrefab = Instantiate(block);
        blockPrefab.transform.parent = GameObject.FindWithTag("GameManager").transform.GetChild(1);
    }

    private void SetTilePos(GameObject obj)
    {
        restX = Input.mousePosition.x % 80;
        restY = Input.mousePosition.y % 80;
        modX = (int)(Input.mousePosition.x / 80);
        modY = (int)(Input.mousePosition.y / 80);

        if (modX < 2)
        {
            restX = 50;
            modX = 1;
        }
        else if (modX > 13)
        {
            restX = 50;
            modX = 13;
        }
        if (modY < 2)
        {
            restY = 50;
            modY = 1;
        }
        else if (modY > 6)
        {
            restY = 50;
            modY = 6;
        }

        if (restX < 40)
        {
            if (restY < 40)
            {
                obj.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(80 * modX, 80 * modY, 0));
            }
            else if (restY >= 40)
            {
                obj.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(80 * modX, 80 * (modY + 1), 0));
            }
        }
        else if (restX >= 40)
        {
            if (restY < 40)
            {
                obj.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * modY, 0));
            }
            else if (restY >= 40)
            {
                obj.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(80 * (modX + 1), 80 * (modY + 1), 0));
            }
        }
        obj.transform.position += new Vector3(0, 0, 6);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetTilePos(blockPrefab);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnMouseDown()
    {
        if (ItemSystem.paintPrefab == null)
            return;

        isPaintOn = true;
        if (ItemSystem.paintPrefab.name.Contains("Slow"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,255,255, 0.5f);
            gameObject.GetComponent<BlockMove>().currentBlock = Block.SLOW;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red + new Color(0, 0, 0, -0.5f);
            gameObject.GetComponent<BlockMove>().currentBlock = Block.BOOSTER;
        }

        ItemSystem.CancelItem();
    }

    public void OnMouseUp()
    {
        isPaintOn = false;
    }

    public void OnMouseDrag()
    {
        if (isPaintOn)
            return;

        SetTilePos(gameObject);
    }
}