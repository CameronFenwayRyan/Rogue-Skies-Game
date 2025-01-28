using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpCard : MonoBehaviour
{
    public TextMeshProUGUI powerUpLevel;
    public GameObject powerUpScriptableObject;
    private float powerUpRefined;
    public string typeOfPowerUp;
    public Button myButton;

    void Start()
    {
        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
        myButton = gameObject.GetComponent<Button>();
        typeOfPowerUp = gameObject.name;

        if (typeOfPowerUp == "Faster Projectile Fire Rate(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire < 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterProjectileFire);
            }
        }

        if (typeOfPowerUp == "Faster Projectiles(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterProjectiles);
            }
        }

        if (typeOfPowerUp == "Larger Projectiles(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainLargerProjectiles);
            }
        }

        if (typeOfPowerUp == "Extra Projectiles(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainExtraShot);
            }
        }

        if (typeOfPowerUp == "Critical Shot(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainCriticalShot);
            }
        }

        if (typeOfPowerUp == "Stretchy Bullets(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainStretchyBullets);
            }
        }

        if (typeOfPowerUp == "Double Stream(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainDoubleStream);
            }
        }

        if (typeOfPowerUp == "V Stream(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainvStream);
            }
        }

        if (typeOfPowerUp == "Faster Flying(Clone)")
        {
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying > 0f)
            {
                powerUpLevel.text = new string ("Power Up Level " + powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying);
            }
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFasterFlying);
            }
        }

        if (typeOfPowerUp == "Max Health(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainMaxHealth);
            }
        }

        if (typeOfPowerUp == "ZigZag Bullets(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainCrazyBullets);
            }
        }

        if (typeOfPowerUp == "Two Hearts(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainTwoHearts);
            }
        }

        if (typeOfPowerUp == "Follow Bullets(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainFollowBullets);
            }    
        }

        if (typeOfPowerUp == "Semi Auto(Clone)")
        {
            if (myButton.onClick.GetPersistentEventCount() < 1)
            {
                myButton.onClick.AddListener(powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().gainSemiAuto);
            }    
        }
    }
}