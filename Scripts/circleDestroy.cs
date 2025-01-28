using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleDestroy : MonoBehaviour
{
    public GameObject powerUpScriptableObject;
    private int randomNum;
    private int timer;
    public GameObject plane;
    public float recordedPlaneTransform;

    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane");
        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");

        recordedPlaneTransform = plane.transform.localPosition.y;
    }
    void FixedUpdate()
    {
        if (transform.position.x > 11.264f)
        {
            Destroy(gameObject);
        }

        if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().crazyBullets != 0)
        {
            if (timer <= 10)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.2f, gameObject.transform.localPosition.z);
            }
            else if (timer <= 30)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - 0.2f, gameObject.transform.localPosition.z);
            }
            else if (timer <= 40)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.2f, gameObject.transform.localPosition.z);
            }
            else
            {
                timer = 0;
            }
            timer++;
        }

        if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().followBullets != 0)
        {
            if (plane.transform.localPosition.y < recordedPlaneTransform)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - 0.035f, gameObject.transform.localPosition.z);
            }
            else if (plane.transform.localPosition.y > recordedPlaneTransform)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.035f, gameObject.transform.localPosition.z);
            }
            else
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            }
        }
    }
}


