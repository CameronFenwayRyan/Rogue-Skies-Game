using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly2 : MonoBehaviour
{
    public float flapFrames = 0;
    public Sprite birdWingUp;
    public Sprite birdWingDown;
    public float birdSpeed;
    public float birdRiseOrFall;
    void FixedUpdate()
    {
            
        transform.position = new Vector2(transform.position.x - birdSpeed, transform.position.y + birdRiseOrFall);

        if (flapFrames < 30)
        {
            flapFrames++;
        }
        else
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == birdWingDown)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = birdWingUp;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == birdWingUp)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = birdWingDown;
            }
            flapFrames = 0;
        }
        
        if (transform.position.x <= -31f)
        {
            Destroy(gameObject);
        }
    }
}
