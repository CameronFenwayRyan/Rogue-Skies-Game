using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Reflection;

public class SpinWheel : MonoBehaviour
{
    public float spinSpeed = 0;
    public float maxSpinSpeed = 20;
    public float spinAcceleration = 0.01f;
    public float spinDeceleration = 0.001f;

    public bool isSpinning = false;
    private string outcome;
    private bool speedUp;
    private int randomInt;

    public GameObject ContinueButton;

    //if item is false than it's a heart
    public bool item = true;

    //x is the number that random number is between, it changes depending on the role
    private int x;
    public Sprite HeartWheel;
    public Sprite ItemWheel;

    public GameObject powerUpScriptableObject;
    public GameObject healthScriptableObject;
    public GameObject HeartCard1;
    public GameObject HeartCard2;
    public GameObject HeartCard3;
    private GameObject spawnHeartCard;
    public GameObject Parent;

    private int ListCount;
    private int index;
    private string methodItemStrings;

    private bool common = false;
    private bool rare = false;
    private bool legendary = false;

    private string typeOfPowerUp;
    public TextMeshProUGUI powerUpLevel;

    public void heartActive()
    {
        item = false;
        GetComponent<Image>().sprite = HeartWheel;
        transform.localPosition = new Vector2(21f, -173f);
        gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0.5f, 0.5f);
    }

    void Start()
    {
        x = Random.Range(0, 100);
        healthScriptableObject = GameObject.FindGameObjectWithTag("Health");
        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
    }

    void FixedUpdate()
    {
        if (item == true)
        {
            transform.localPosition = new Vector2(21f, -173f);
            gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0.5f, 0.5f);
        }
        if (isSpinning)
        {
            if (speedUp == true)
            {
                spinSpeed += spinAcceleration;
                if (spinSpeed >= maxSpinSpeed)
                {
                    spinSpeed = maxSpinSpeed;
                    if (x == 0)
                    {
                        speedUp = false;
                    }
                    else
                    {
                        x -= 1;
                    }
                }
            }
            else
            {
                spinSpeed -= spinDeceleration;

                if (spinSpeed <= 0)
                {
                    spinSpeed = 0;
                    endSpin();
                }
            }
        }

        //common > 270 or < 129
        //rare >= 129 and < 225.5
        //legendary else 
        
        void endSpin()
        {
            if (item == true)
            {
                float angle = transform.rotation.eulerAngles.z;
                if (angle > 270f || angle < 129)
                {
                    outcome = "Common";
                    ListCount = powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().CommonCards.Count;
                    common = true;
                    DisplayItemCard();
                }
                else if (angle >= 129 && angle < 225.5f)
                {
                    outcome = "Rare";
                    ListCount = powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().RareCards.Count; 
                    rare = true;
                    DisplayItemCard();
                }
                else
                {
                    outcome = "Legendary";
                    //Change to legendary
                    ListCount = powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().LegendaryCards.Count;
                    legendary = true;
                    DisplayItemCard();
                }
            }
            else
            {
                float angle = transform.rotation.eulerAngles.z;
                if (angle >= 30f && angle < 150f)
                {
                    outcome = "1 Heart";
                    if (healthScriptableObject.GetComponent<healthScriptableObject>().health < 3)
                    {
                        healthScriptableObject.GetComponent<healthScriptableObject>().health += 1;
                    }
                    spawnHeartCard = Instantiate(HeartCard1, new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
                    DisplayHeartCard();
                }
                else if (angle >= 270 || angle < 30f)
                {
                    outcome = "2 Hearts";
                    if (healthScriptableObject.GetComponent<healthScriptableObject>().health < 2)
                    {
                        healthScriptableObject.GetComponent<healthScriptableObject>().health += 2;
                    }
                    else if (healthScriptableObject.GetComponent<healthScriptableObject>().health == 2)
                    {
                        healthScriptableObject.GetComponent<healthScriptableObject>().health += 1;
                    }
                    spawnHeartCard = Instantiate(HeartCard2, new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
                    DisplayHeartCard();
                }
                else
                {
                    outcome = "3 Hearts";
                    healthScriptableObject.GetComponent<healthScriptableObject>().health = 4;
                    spawnHeartCard = Instantiate(HeartCard3, new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
                    DisplayHeartCard();
                }
            }

            ContinueButton.transform.localPosition = new Vector2 (21f, -135f);
            
            isSpinning = false;
        }

        transform.Rotate(0, 0, -spinSpeed);
    }

    void DisplayHeartCard()
    {
        spawnHeartCard.transform.localPosition = new Vector2(31f,46.5f);
        spawnHeartCard.transform.localScale = new Vector2 (0.11f,0.11f);
    }

    void DisplayItemCard()
    {
        if (common)
        {
            ListCount--;
            index = Random.Range(0, ListCount);
            spawnHeartCard = Instantiate(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().CommonCards[index], new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
            
            initializeCard();

            spawnHeartCard.transform.localPosition = new Vector2(31f,46.5f);
            spawnHeartCard.transform.localScale = new Vector2 (0.11f,0.11f);

            if (typeOfPowerUp == "Faster Projectile Fire Rate(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterProjectileFire();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire < 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire);
                }
            }

            if (typeOfPowerUp == "Faster Projectiles(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterProjectileFire();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed);
                }
            }

            if (typeOfPowerUp == "Larger Projectiles(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainLargerProjectiles();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles);
                }
            }

            if (typeOfPowerUp == "Two Hearts(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainTwoHearts();
            }

        }
        else if (rare)
        {
            ListCount--;
            index = Random.Range(0, ListCount);
            spawnHeartCard = Instantiate(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().RareCards[index], new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
            
            initializeCard();

            spawnHeartCard.transform.localPosition = new Vector2(31f,46.5f);
            spawnHeartCard.transform.localScale = new Vector2 (0.11f,0.11f);

            if (typeOfPowerUp == "Critical Shot(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainCriticalShot();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot);
                }
            }

            if (typeOfPowerUp == "Extra Projectiles(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainExtraShot();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles);
                }
            }

            if (typeOfPowerUp == "Stretchy Bullets(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainStretchyBullets();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets);
                }          
            }

            if (typeOfPowerUp == "ZigZag Bullets(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainCrazyBullets();
            }

            if (typeOfPowerUp == "Faster Flying(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterFlying();
                if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying > 0f)
                {
                    powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying);
                }
            }
        }
        else
        {
            ListCount--;
            index = Random.Range(0, ListCount);
            spawnHeartCard = Instantiate(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().LegendaryCards[index], new Vector3 (97f,148f,-22f), Quaternion.Euler(0f, 180f, 0f), Parent.transform);
            
            initializeCard();

            spawnHeartCard.transform.localPosition = new Vector2(31f,46.5f);
            spawnHeartCard.transform.localScale = new Vector2 (0.11f,0.11f);

            if (typeOfPowerUp == "Max Health(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainMaxHealth();
            }

            if (typeOfPowerUp == "V Stream(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainvStream();
            }

            if (typeOfPowerUp == "Double Stream(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainDoubleStream();
            }

            if (typeOfPowerUp == "Follow Bullets(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFollowBullets();
            }

            if (typeOfPowerUp == "Semi Auto(Clone)")
            {
                powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainSemiAuto();
            }
        }
    }

    // Button starts wheel
    public void StartSpinning()
    {
        speedUp = true;
        isSpinning = true;
    }

    public void resetSpinWheel()
    {
        ContinueButton.transform.localPosition = new Vector2 (94f, 7000f);
        item = true;
        GetComponent<Image>().sprite = ItemWheel;
        transform.localPosition = new Vector2(44f, -624f);
        Destroy(spawnHeartCard);
    }

    public void initializeCard()
    {
        typeOfPowerUp = spawnHeartCard.name;
        TextMeshProUGUI[] cardTextOptions = spawnHeartCard.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textOption in cardTextOptions)
        {
            if (textOption.name == "Text (TMP)")
            {
                powerUpLevel = textOption;
            }
        }
    }
}
