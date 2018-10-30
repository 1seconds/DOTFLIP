using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Contains("Sea"))
            col.gameObject.tag = "BoatArea";
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Contains("BoatArea"))
            col.gameObject.tag = "Sea";
    }

}
