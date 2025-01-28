using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCards : MonoBehaviour
{
    private int RanNumRarity;
    private int RanNumCard;
    private int iterations = 1;
    public GameObject powerupscriptableobject;
    private int RanUpperLimit;
    private GameObject myCard;
    private Transform PowerUpUICanvas;
    private bool doNotUse = false;

    private GameObject cardOne;
    private GameObject cardTwo;
    private GameObject cardThree;

    private List<GameObject> UsedCards;

    private float startSpawn;
    private bool timerStart = false;
    private int timer;
    private bool timerComplete;

    void Start()
    {
        powerupscriptableobject = GameObject.FindGameObjectWithTag("PowerUp");
        UsedCards = new List<GameObject>();
    }

    public void RandomCardsActive()
    {
        while (iterations <= 3)
        {
            //Generate random number between 1 and 8            
            RanNumRarity = Random.Range(1, 13);
            doNotUse = false;
            print(RanNumRarity);

            //ONLY COMMONS FOR NOW

            if (RanNumRarity == 1)
            {
                //LEGENDARY YIPPEE
                RanUpperLimit = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().LegendaryCards.Count;
                RanNumCard = Random.Range(0, RanUpperLimit);
                myCard = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().LegendaryCards[RanNumCard];

                noRepeatCards();

                if (doNotUse == false)
                {
                    SpawnCard();
                    iterations++;
                }
            }
            else if (RanNumRarity == 2 || RanNumRarity == 3 || RanNumRarity == 4)
            {
                //Rare wahoo
                RanUpperLimit = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().RareCards.Count;
                RanNumCard = Random.Range(0, RanUpperLimit);
                myCard = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().RareCards[RanNumCard];
                
                noRepeatCards();

                if (doNotUse == false)
                {
                    SpawnCard();
                    iterations++;
                }
                
            }
            else
            {
                //Common heh
                RanUpperLimit = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().CommonCards.Count;
                RanNumCard = Random.Range(0, RanUpperLimit);
                myCard = powerupscriptableobject.GetComponent<PowerUpScriptableObject>().CommonCards[RanNumCard];

                noRepeatCards();

                if (doNotUse == false)
                {
                    SpawnCard();
                    iterations++;
                }
            }
        }
    }

    void SpawnCard()
    {
        startSpawn = Time.time;
        UsedCards.Add(myCard);
        PowerUpUICanvas = gameObject.GetComponent<Transform>();
        if (iterations == 1)
        {
            cardOne = Instantiate(myCard, new Vector2(-100f, -100f), Quaternion.identity, PowerUpUICanvas);
            cardOne.transform.localPosition = new Vector2(1983.323f, 667.2454f);
        }
        else if (iterations == 2)
        {
            cardTwo = Instantiate(myCard, new Vector2(-100f, -100f), Quaternion.identity, PowerUpUICanvas);
            cardTwo.transform.localPosition = new Vector2(-22.26421f, 667.2454f);
        }
        else
        {
            cardThree = Instantiate(myCard, new Vector2(-100f, -100f), Quaternion.identity, PowerUpUICanvas);
            cardThree.transform.localPosition = new Vector2(-2021.057f, 667.2454f);
        }
    }

    void noRepeatCards()
    {
        if (UsedCards.Count > 0)
        {
            foreach (Object card in UsedCards)
            {
                if (myCard == card)
                {
                    doNotUse = true;
                }  
            }
        }
    }

    public void ResetCards()
    {
        //Called from powerUpScriptableObject
        Destroy(cardOne);
        Destroy(cardTwo);
        Destroy(cardThree);
        UsedCards = new List<GameObject>();
        iterations = 1;
    }
}

