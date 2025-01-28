using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using ZSerializer;

[CreateAssetMenu(fileName = "PowerUpScriptableObject", menuName = "ScriptableObjects/PowerUpScriptableObject", order = 1)]
public class PowerUpScriptableObject : PersistentMonoBehaviour
{
    //List of powerups and whether they're active or not with a value, the higher the value, the higher they're stacked, if they're stacked to the max,
    //They'll no longer appear

    //Also ScriptableObject saves progress from scene to scene

    //Set to the number plus 0.1 so that every powerup only happens once
    public int largerProjectiles = 0; //Implemented Common
    public int fasterProjectileFire = 0; //Implemented Common
    public int fasterProjectileSpeed = 0; //Implemented Common
    public int twoHearts = 0; //Implemented Common
    public int maxHealth = 0; //Implemented Legendary
    public int extraProjectiles = 0; //Implemented Rare
    public int criticalShot = 0; //Implemented Rare
    public int fasterFlying = 0; //Implemented Rare
    public int stretchyBullets = 0; //Implemented Rare
    public int doubleStream = 0; //Implemented Legendary
    public int vStream = 0; //Implemented Legendary
    public int crazyBullets = 0; //Implemented Rare
    public int followBullets = 0; //Implemented Legendary
    public int semiAuto = 0; //Implemented Legendary
    private int threeCommons = 0; 
    private int twoCommons = 0; 
    private int continuousDamage = 0;
    private int continuousHearts = 0;

    [NonZSerialized] public GameObject camerA;

    public GameObject FasterProjectileFire;
    public GameObject FasterProjectiles;
    public GameObject LargerProjectiles;
    public GameObject TwoHearts;
    public GameObject MaxHealth;
    public GameObject ExtraShot;
    public GameObject CriticalShot;
    public GameObject DoubleStream;
    public GameObject StretchyBullets;
    public GameObject VStream;
    public GameObject ZigZagBullets;
    public GameObject FasterFlying;
    public GameObject FollowBullets;
    public GameObject SemiAuto;

    [NonZSerialized] public List<GameObject> CommonCards;
    [NonZSerialized] public List<GameObject> RareCards;
    [NonZSerialized] public List<GameObject> LegendaryCards;

    public GameObject PowerUpUICanvas;
    public GameObject healthScriptableObject;
    public int impactExplosionDamage = 2;

    void Start()
    {
        CommonCards = new List<GameObject>() {FasterProjectileFire, FasterProjectiles, LargerProjectiles, TwoHearts};
        RareCards = new List<GameObject>() {CriticalShot, ExtraShot, StretchyBullets, ZigZagBullets, FasterFlying};
        LegendaryCards = new List<GameObject>() {DoubleStream, MaxHealth, VStream, FollowBullets, SemiAuto};
    }

    public void reset()
    {
        healthScriptableObject = GameObject.FindGameObjectWithTag("Health");
        camerA = GameObject.FindGameObjectWithTag("MainCamera");
        largerProjectiles = 0;
        fasterProjectileFire = 0;
        fasterProjectileSpeed = 0;
        criticalShot = 0;
        extraProjectiles = 0;
        fasterFlying = 0;
        stretchyBullets = 0;
        doubleStream = 0;
        vStream = 0;
        crazyBullets = 0;
        followBullets = 0;
        semiAuto = 0;
    }

    // COMMON

    public void gainLargerProjectiles()
    {
        // Iterates PowerUp
        largerProjectiles++;
        print("largerProjectiles " + largerProjectiles);

        unpauseAndReset();

        if (largerProjectiles > 4)
        {
            CommonCards.Remove(LargerProjectiles);
        }
    }
    public void gainFasterProjectiles()
    {
        // Iterates PowerUp
        fasterProjectileSpeed++;

        unpauseAndReset();
        
        if (fasterProjectileSpeed > 4)
        {
            CommonCards.Remove(FasterProjectiles);
        }
    }

    public void gainFasterProjectileFire()
    {
        // Iterates PowerUp
        fasterProjectileFire++;

        unpauseAndReset();

        if (fasterProjectileFire > 4)
        {
            CommonCards.Remove(FasterProjectileFire);
        }
    }

    public void gainTwoHearts()
    {
        // Iterates PowerUp
        healthScriptableObject.GetComponent<healthScriptableObject>().health += 2;
        if (healthScriptableObject.GetComponent<healthScriptableObject>().health > 6)
        {
            healthScriptableObject.GetComponent<healthScriptableObject>().health = 6;
        }

        unpauseAndReset();
    }

    public void gainFasterFlying()
    {
        fasterFlying++;

        unpauseAndReset();

        if (fasterFlying > 4)
        {
            CommonCards.Remove(FasterFlying);
        }
    }

    public void gainStretchyBullets()
    {
        stretchyBullets++;

        unpauseAndReset();

        if (stretchyBullets > 4)
        {
            CommonCards.Remove(StretchyBullets);
        }
    }

    // RARE

    public void gainMaxHealth()
    {
        healthScriptableObject.GetComponent<healthScriptableObject>().health = 6;

        unpauseAndReset();
    }

    public void gainExtraShot()
    {
        extraProjectiles++;

        unpauseAndReset();

        if (extraProjectiles > 4)
        {
            RareCards.Remove(ExtraShot);
        }
    }

    public void gainCriticalShot()
    {
        criticalShot++;

        unpauseAndReset();

        if (criticalShot > 4)
        {
            CommonCards.Remove(CriticalShot);
        }
    }
    public void gainCrazyBullets()
    {
        crazyBullets++;

        unpauseAndReset();

        if (crazyBullets > 0)
        {
            RareCards.Remove(ZigZagBullets);
        }
    }


    // LEGENDARY

    public void gainDoubleStream()
    {
        doubleStream++;

        unpauseAndReset();

        if (doubleStream > 0)
        {
            LegendaryCards.Remove(DoubleStream);
        }
    }

    public void gainvStream()
    {
        vStream++;

        unpauseAndReset();

        if (vStream > 0)
        {
            LegendaryCards.Remove(VStream);
        }
    }

    public void gainFollowBullets()
    {
        followBullets++;
        
        unpauseAndReset();

        if (followBullets > 0)
        {
            LegendaryCards.Remove(FollowBullets);
        }
    } 

    public void gainSemiAuto()
    {
        semiAuto++;

        unpauseAndReset();

        if (crazyBullets > 1)
        {
            LegendaryCards.Remove(SemiAuto);
        }
    }

    void unpauseAndReset()
    {
        GameObject.FindGameObjectWithTag("powerUpScreen").GetComponentInChildren<Canvas>().enabled = false;
        Time.timeScale = 1f;

        PowerUpUICanvas = GameObject.FindGameObjectWithTag("powerUpScreen");
        PowerUpUICanvas.GetComponent<RandomCards>().ResetCards();
    }

    public async void save()
    {
        await ZSerialize.SaveScene();
    }
}

