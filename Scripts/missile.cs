using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public float flameFrames = 0;
    private float missileFrames;
    public Sprite Missile1;
    public Sprite Missile2;
    public float missileSpeed;
    public Transform planeTransform;
    public GameObject planeObject;
    public bool timeStop = false;
    void Start()
    {
        planeObject = GameObject.Find("Plane");
        planeTransform = planeObject.transform;
    }
    void FixedUpdate()
    {
        missileFrames++;

        if (transform.position.x < 10f)
        {
            if ((transform.position.y < planeTransform.position.y + 0.05f) && (transform.position.y > planeTransform.position.y - 0.05f))
            {

            }
            else if (planeTransform.position.y > transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.045f);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.045f);
            }
            missileFrames = 0;
        }

        if (timeStop == false)
        {
            transform.position = new Vector2(transform.position.x - missileSpeed, transform.position.y);
        }

        if (flameFrames < 30)
        {
            flameFrames++;
        }
        else
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Missile1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Missile2;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == Missile2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Missile1;
            }
            flameFrames = 0;
        }
        
        if (transform.position.x <= -31f)
        {
            Destroy(gameObject);
        }
    }
}