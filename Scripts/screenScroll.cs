using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenScroll : MonoBehaviour
{
    public float scrollValue;
    public float framesBetweenShift;
    private float frames;
    void FixedUpdate()
    {
        // Parallax x values
        // 1: x = -4.6
        // 2: x = 15.86
        // 3: x = 35.15

        // Moves the sky object to the left every couple of frames
        if (frames % framesBetweenShift == 0)
        {
            transform.position = new Vector2(transform.position.x - scrollValue, transform.position.y);  
            frames = 0; 
        }
        else
        {
            frames++;
        }

        // Once the sky object reaches a certain position on the x axis
        // it moves to become the rightmost sky object
        if (transform.position.x <= -34f)
        {
            transform.position = new Vector2(27f, transform.position.y);
        }
    }
}
