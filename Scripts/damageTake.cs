using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageTake : MonoBehaviour
{
    public float health; // the enemy's health
    public Sprite redVersion;
    public float damageTimeCounter;
    public ParticleSystem particleExplosion;
    public ParticleSystem impactExplosion;
    private GameObject camerA;
    public float EXPgain;
    public GameObject expScriptableObject;
    private Sprite mySprite;

    public AudioSource audioSource;
    public AudioClip birdExplosionSoundEffect;
    public AudioClip alienSoundEffect;
    public GameObject powerUpScriptableObject;

    private bool dead = false;

    void Start()
    {
        audioSource.clip = birdExplosionSoundEffect;
        mySprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
        expScriptableObject = GameObject.FindGameObjectWithTag("EXP");
        camerA = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void FixedUpdate()
    {
        if (damageTimeCounter >= 1)
        {
            damageTimeCounter++;
        }
        if (damageTimeCounter >= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mySprite;
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

            // check if the enemy is dead
            if (health <= 0 && dead == false)
            {
                // Waits for kill to add give EXP to the player, determined EXP gain by amount of initial enemy health
                expScriptableObject.GetComponent<EXPScriptableObject>().IncreaseEXP(EXPgain);
                // Explosion

                ParticleSystem particleSystem = Instantiate(particleExplosion, new Vector3 (transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation);
                
                // ScreenShake
                if (GameObject.FindGameObjectWithTag("powerUpScreen").GetComponentInChildren<Canvas>().enabled == false)
                {
                    camerA.GetComponent<ScreenShake>().TriggerShake();
                }
                
                transform.position = new Vector2(100f, 100f);
                dead = true;
                audioSource.Play();
                // destroy the enemy
                Destroy(gameObject, 1f);
            }
            else
            {
                if (alienSoundEffect != null)
                {
                    audioSource.clip = alienSoundEffect;
                }
                audioSource.Play();
                // Red shows damage
                gameObject.GetComponent<SpriteRenderer>().sprite = redVersion;
                damageTimeCounter = 1;
            }
        }
    }
}


