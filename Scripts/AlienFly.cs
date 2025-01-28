using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFly : MonoBehaviour
{
    public float scrollValue;
    public float framesBetweenShift;
    private float frames;
    private float risePos;
    private float lowerPos;
    public float riseAndLowerValue;
    private bool rise = true;
    public float riseAndLowerSpeed;
    public float FramesForAlienToStayInPlace;
    private float alienInPlaceCounter = 0f;

    void Start()
    {
        risePos = transform.position.y + riseAndLowerValue;
        lowerPos = transform.position.y - riseAndLowerValue;
    }
    void FixedUpdate()
    {
        // Basic x movement
        transform.position = new Vector2(transform.position.x - scrollValue, transform.position.y);

        // Basic y movement
        if (rise && transform.position.y < risePos)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + riseAndLowerSpeed);
        }
        else if(rise && transform.position.y >= risePos)
        {
            if (alienInPlaceCounter < FramesForAlienToStayInPlace)
            {
                alienInPlaceCounter++;
            }
            else
            {
                alienInPlaceCounter = 0;
                rise = false;
            }
        }
        else if(!rise && transform.position.y > lowerPos)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - riseAndLowerSpeed);
        }
        else
        {
            if (alienInPlaceCounter < FramesForAlienToStayInPlace)
            {
                alienInPlaceCounter++;
            }
            else
            {
                alienInPlaceCounter = 0;
                rise = true;
            }
        }

        // Frames between actual shift counter
        if (frames % framesBetweenShift == 0)
        {
            frames = 0; 
        }
        else
        {
            frames++;
        }

        if (transform.position.x <= -31f)
        {
            Destroy(gameObject);
        }
    }
}
