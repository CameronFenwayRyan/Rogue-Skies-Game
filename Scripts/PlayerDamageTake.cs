using UnityEngine;
using ZSerializer;

public class PlayerDamageTake : PersistentMonoBehaviour
{
    private bool damageTakeProcess;
    private int damageTimer;
    public SpriteRenderer brenderer;
    public GameObject healthScriptableObject;
    public GameObject camerA;
    public GameObject Plane;

    public AudioSource audioSource;
    public AudioClip PlayerTakeDamage;

    public AudioSource deathSongAudioSource;

    public AudioSource musicAudioSource;

    void Start()
    {
        Plane = GameObject.FindGameObjectWithTag("Plane");
        healthScriptableObject = GameObject.FindGameObjectWithTag("Health");
        if (audioSource != null)
        {
            audioSource.clip = PlayerTakeDamage;
        }
        brenderer = GetComponent<SpriteRenderer>();
        damageTakeProcess = false;
    }
    void FixedUpdate()
    {
        if (damageTakeProcess)
        {
            damageTimer++;
            if (damageTimer < 120f)
            {
                if (damageTimer % 4 == 0)
                {
                    if (brenderer.enabled == true)
                    {
                        brenderer.enabled = false;
                    }
                    else
                    {
                        brenderer.enabled = true;
                    }
                }
            }
            else
            {
                if (brenderer.enabled == false)
                {
                        brenderer.enabled = true;
                }
                damageTimer = 0;
                damageTakeProcess = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (damageTakeProcess == false)
        {
            audioSource.Play();
        }*/
        if (collision.gameObject.tag == "Enemy")
        {
            if (damageTakeProcess == false)
            {
                TakeDamage(1);
            }
        }
    }

    void TakeDamage(int damage)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        healthScriptableObject.GetComponent<healthScriptableObject>().health -= damage;
        damageTakeProcess = true;

        if (GameObject.FindGameObjectWithTag("powerUpScreen").GetComponentInChildren<Canvas>().enabled == false)
        {
            if (camerA != null)
            {
                camerA.GetComponent<ScreenShake>().TriggerShake();
            }
        }
        if (healthScriptableObject.GetComponent<healthScriptableObject>().health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ZSerialize.DeleteAllSaveFiles();
        musicAudioSource.Stop();
        deathSongAudioSource.Play();
        Plane.GetComponent<DragAndThrow>().deathAnimation = true;
    }
}
