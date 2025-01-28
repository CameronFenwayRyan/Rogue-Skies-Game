using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsBehavior : MonoBehaviour
{
    public GameObject healthScriptableObject;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public Sprite heartRed;
    public Sprite heartGold;
    public Sprite heartLost;
    public Button getMoreHeartsAtEndOfLevel;

    void Start()
    {
        healthScriptableObject = GameObject.FindGameObjectWithTag("Health");
    }
    void Update()
    {
        if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 6)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartGold;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartGold;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartGold;

            //Can't choose to upgrade hearts from the menu
            getMoreHeartsAtEndOfLevel.interactable = false;
        }
        if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 5)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartGold;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartGold;

            //Can't choose to upgrade hearts from the menu
            getMoreHeartsAtEndOfLevel.interactable = false;
        }
        //lives = healthScriptableObject.health;
        if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 4)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartGold;

            //Can't choose to upgrade hearts from the menu
            getMoreHeartsAtEndOfLevel.interactable = false;
        }
        else if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 3)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartRed;

            //Can't choose to upgrade hearts from the menu
            getMoreHeartsAtEndOfLevel.interactable = false;

        }
        else if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 2)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartLost;

            getMoreHeartsAtEndOfLevel.interactable = true;
        }
        else if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 1)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartRed;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartLost;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartLost;

            getMoreHeartsAtEndOfLevel.interactable = true;
        }
        else if (healthScriptableObject.GetComponent<healthScriptableObject>().health <= 0)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartLost;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartLost;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartLost;
        }
    }
}
