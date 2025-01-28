using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakeMissile : MonoBehaviour
{
    public float health = 2; // the enemy's health
    public Sprite redVersion;
    public float damageTimeCounter;
    public ParticleSystem particleExplosion;
    public GameObject camerA;
    public float EXPgain;
    public GameObject expScriptableObject;
    private Sprite mySprite;

    public AudioSource audioSource;
    public AudioClip funnyAlienNoiseHAHA;
    private bool dead = false;
    public GameObject powerUpScriptableObject;
    public ParticleSystem impactExplosion;
    void Start()
    {
        audioSource.clip = funnyAlienNoiseHAHA;
        EXPgain = health;
        camerA = GameObject.FindGameObjectWithTag("MainCamera");
        mySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        expScriptableObject = GameObject.FindGameObjectWithTag("EXP");
        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
    }

    void FixedUpdate()
    {
        if (damageTimeCounter >= 1)
        {
            damageTimeCounter++;
            gameObject.GetComponent<missile>().timeStop = true;
        }
        if (damageTimeCounter >= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mySprite;
            gameObject.GetComponent<missile>().timeStop = false;
            damageTimeCounter = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the enemy has been hit by a projectile
        if (other.gameObject.tag == "Projectile" && dead == false)
        {
            // reduce the enemy's health by the damage of the projectile
            health -= other.gameObject.GetComponent<damageGive>().damage;

            // destroy the projectile
            Destroy(other.gameObject);

            audioSource.Play();

            // check if the enemy is dead
            if (health <= 0)
            {
                // Waits for kill to add give EXP to the player, determined EXP gain by amount of initial enemy health
                expScriptableObject.GetComponent<EXPScriptableObject>().IncreaseEXP(EXPgain);
                //ScreenShake
                camerA.GetComponent<ScreenShake>().TriggerShake();
                //BOOOMM EXPLOSION
                ParticleSystem particleSystem = Instantiate(particleExplosion, transform.position, transform.rotation);
                dead = true;
                transform.position = new Vector2(100f, 100f);
                
                // destroy the enemy
                Destroy(gameObject, 1f);
            }

            // Red shows damage
            gameObject.GetComponent<SpriteRenderer>().sprite = redVersion;
            damageTimeCounter = 1;
        }
    }
}


