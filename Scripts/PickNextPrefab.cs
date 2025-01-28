using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PickNextPrefab : MonoBehaviour
{
    private List<GameObject> NextPrefabNoRepeats;
    public bool easy;
    public bool medium;
    public bool hard;
    public bool finished;

    public GameObject orderScriptableObject;
    public float TimeWhereOtherStuffCanSpawnIn;
    private float timer;
    public Vector3 spawnLocation;
    private bool spawnedNextPreset;
    private GameObject plane;
    public bool finishAnimationActive = false;
    private int initialOrder;

    public float fadeDuration = 4f; // duration of the fade in seconds

    private Image blackScreen;
    //public UIScriptableObject uiscriptableObject;

    public GameObject EndOfDemoMessage;

    private int i;

    void Start()
    {
        // Grabs plane object for win animation
        orderScriptableObject = GameObject.FindGameObjectWithTag("Order");
        initialOrder = orderScriptableObject.GetComponent<OrderScriptableObject>().order;
        plane = GameObject.FindGameObjectWithTag("Plane");
        blackScreen = GameObject.FindGameObjectWithTag("ScreenFade").GetComponent<Image>();
        NextPrefabNoRepeats = new List<GameObject>();
        orderScriptableObject.GetComponent<OrderScriptableObject>().IterateVariable();
        EndOfDemoMessage = GameObject.FindGameObjectWithTag("EndOfDemo");
        //uiscriptableObject.LevelMenu.GetComponent<Canvas>().enabled = false;
    }
    
    void Update()
    {
        if (timer >= TimeWhereOtherStuffCanSpawnIn && !spawnedNextPreset && orderScriptableObject.GetComponent<OrderScriptableObject>().spawnEnemies == true && orderScriptableObject.GetComponent<OrderScriptableObject>().order < 12)
        {
            //Runs the nextPrefab method in order to pick the next prefab to run
            GameObject nextPrefab = pickNextPrefab();
            //Adds the current prefab to a list of prefabs that cannot be used again
            orderScriptableObject.GetComponent<OrderScriptableObject>().addToPrefabsUsed(nextPrefab);

            //Instantiates the prefab, gets the prefabs position from its spawnLocation variable which is
            //set individually
            Instantiate(nextPrefab, nextPrefab.GetComponent<PickNextPrefab>().spawnLocation, transform.rotation);
            spawnedNextPreset = true;
        }
        // If you complete the level successfully
        if (finished && finishAnimationActive == false)
        {
            //Coroutine stuff to fade screen
            blackScreen.enabled = true;
            blackScreen.color = new Color(0f, 0f, 0f, 0f); // set initial alpha to 0 (fully transparent)
            
            // Kicks off event that makes the screen fade out, pulls up the menu after you beat a level and then fades back in
            StartCoroutine(FadeSpriteOut());

            // Plays the plane's win animation where it flies off screen
            plane.GetComponent<DragAndThrow>().winAnimation = true;
            
            finishAnimationActive = true;
        }
        //TimeWhereOtherStuffCanSpawnIn set individually for each prefab
    }

    void FixedUpdate()
    {
        timer++;
        if (timer > TimeWhereOtherStuffCanSpawnIn + 150f && orderScriptableObject.GetComponent<OrderScriptableObject>().order < 12)
        {
            Destroy(gameObject);
        }
        if (timer > TimeWhereOtherStuffCanSpawnIn && initialOrder == 11)
        {
            finished = true;
            orderScriptableObject.GetComponent<OrderScriptableObject>().level++;
            initialOrder = 100;
        }     
    }

    GameObject pickNextPrefab()
    {
        //Responsible for transitions between difficulties
        //If it's on a # where it should transition difficulties, manually transfer difficuly values
        if (orderScriptableObject.GetComponent<OrderScriptableObject>().order == 4)
        {
            easy = false;
            medium = true;
        }
        if (orderScriptableObject.GetComponent<OrderScriptableObject>().order == 8)
        {
            medium = false;
            hard = true;
        }
        //Past 12/finished handled outside of this method
        
        //Chooses list to pick next prefab from differently depending on the difficulty
        List<GameObject> PrefabList;
        
        if (easy == true)
        {
            if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 1 || orderScriptableObject.GetComponent<OrderScriptableObject>().level == 2)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level1Easy;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 3)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level3Easy;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 4)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level4Easy;
            }
            else
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Levels3and4Complete;
            }
        }
        else if (medium == true)
        {
            if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 1 || orderScriptableObject.GetComponent<OrderScriptableObject>().level == 2)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level1Medium;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 3)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level3Medium;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 4)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level4Medium;
            }
            else
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Levels3and4Complete;
            }
        }
        else
        {
            if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 1 || orderScriptableObject.GetComponent<OrderScriptableObject>().level == 2)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level1Hard;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 3)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level3Hard;
            }
            else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 4)
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Level4Hard;
            }
            else
            {
                PrefabList = orderScriptableObject.GetComponent<OrderScriptableObject>().Levels3and4Complete;
            }
        }

        if (orderScriptableObject.GetComponent<OrderScriptableObject>().level <= 4)
        {
            //For each Object within the difficulties folder
            foreach (Object Prefab in PrefabList)
            {
                bool repeat = false;
                //Cast the regular Object to a GameObject
                GameObject UltimatePrefab = Prefab as GameObject;
                //Check to see which prefabs in the list of choices has already been played
                if (orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed != null)
                {
                    // Checks to see if the object is in the list of already used objects
                    foreach (Object o in orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed)
                    {
                        if (o == UltimatePrefab)
                        {
                            repeat = true;
                        }
                    }
                }
                // If it's not it's added to the list of objects that can be chosen from
                if (repeat == false || orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed == null)
                {
                    NextPrefabNoRepeats.Add(UltimatePrefab);
                }
            }
        //Pick a random prefab that does not repeat and is the same difficulty
        i = Random.Range(0, NextPrefabNoRepeats.Count);

        return NextPrefabNoRepeats[i];
        }
        else
        {
            i = Random.Range(0,24);
            print(i);
            
            return orderScriptableObject.GetComponent<OrderScriptableObject>().Levels3and4Complete[i];
        }
    }

    IEnumerator FadeSpriteOut()
    {
        Color startColor = blackScreen.color;
        Color endColor = new Color(0f, 0f, 0f, 1f); // set alpha to 1f (fully opaque)
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / fadeDuration;
            blackScreen.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        nextLevelMenu();
    }

    void nextLevelMenu()
    {
        plane.GetComponent<UIController>().LevelMenu.GetComponent<Canvas>().enabled = true;
        if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 5)
        {
            EndOfDemoMessage.GetComponent<Canvas>().enabled = true;
        }
        Destroy(gameObject);
    } 
}
