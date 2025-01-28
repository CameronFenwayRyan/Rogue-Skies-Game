using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownScroll : MonoBehaviour
{
    float startTime;
    public bool scrollStop;
    public float speed = 0.01f;
    void Start()
    {
        startTime = Time.time;
    }
    void FixedUpdate()
    {
        if (scrollStop == false)
        {
            if (Time.time - startTime >= speed)
            {
                transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, 1f);
                startTime = Time.time;
            }
            if (transform.position.x <= -18.75f)
            {
                transform.position = new Vector3 (26.49f, 0.0175f, 0f);
            }
        }
    }
}
