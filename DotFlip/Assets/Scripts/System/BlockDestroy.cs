using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private float power = 100;
    private float time_;
    private int randomValue(int min, int max)
    {
        return Random.Range(min, max);
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((randomValue(25, 75) - 50) * 0.1f, (randomValue(0, 25)) * 0.1f) * power);
        Destroy(gameObject.GetComponent<UIDrag>());
    }

    private void Update()
    {
        time_ += Time.deltaTime;
        if (time_ > 2.0f)
            Destroy(gameObject);
    }
}
