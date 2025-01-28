using UnityEngine;

public class FireCircles : MonoBehaviour
{
    // The prefab for the mini circle that will be fired
    public GameObject circlePrefab;

    // The force with which the mini circle will be fired
    public float fireForce = 8.0f;

    // The rate at which the mini circle will be fired (in seconds)
    public float fireRate = 1.15f;

    // The time at which the last mini circle was fired
    private float lastFireTime = 0.0f;

    public ParticleSystem particleExplosion;
    private float newDimensions;
    private Vector2 circleDimensions = new Vector2 (0.1972608f, 0.1972608f);
    private Vector2 initialCircleDimensions;

    public AudioSource audioSource;
    public AudioClip shootSoundEffect;

    public GameObject LevelChangeScreen;

    // Extra Bullet Calculate
    private bool extraShotActive = false;
    private int RandomNum;
    private int randomLastNum;
    private bool endExtraShot = true;

    // Crit Chance Calculate
    private bool critChanceActive = false;
    private int RandomNum2;
    private int randomLastNum2;
    private bool endCritChance = true;

    public GameObject powerUpScriptableObject;
    private float largerProjectileIterator;
    private float initialFireRate;
    private float initialFireForce;
    private float projectileXoffset = 1.2f;
    private bool doubleStreamDone = false;
    private int vStreamDone = 0;

    void Start()
    {
        powerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
        initialCircleDimensions = circleDimensions;
        initialFireRate = fireRate;
        initialFireForce = fireForce;
        audioSource.clip = shootSoundEffect;
    }
    void Update()
    {
        // Check if it's time to fire a new mini circle
        if (Time.time >= lastFireTime + fireRate && gameObject.GetComponent<DragAndThrow>().winAnimation != true && LevelChangeScreen.GetComponent<Canvas>().enabled == false && gameObject.GetComponent<DragAndThrow>().planeStart == false && gameObject.GetComponent<DragAndThrow>().winAnimation == false && gameObject.GetComponent<DragAndThrow>().deathAnimation == false)
        {
            // Instantiate the mini circle at the object's position and rotation
            GameObject circle = Instantiate(circlePrefab, new Vector2(transform.position.x + projectileXoffset, transform.position.y), transform.rotation);
            ParticleSystem particleSystem = Instantiate(particleExplosion, new Vector2(transform.position.x + 1.2f, transform.position.y), transform.rotation);

            // Sets size of circles
            circle.transform.localScale = circleDimensions;

            //POWER UP
            
            //Stacks 5x. first time bullet grows by 25%, everytime after that increases by 15%.

            circle.transform.localScale = circleDimensions;

            largerProjectileIterator = powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles;

            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles == 0)
            {
                
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles == 1)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 0.4f;
                circle.transform.localScale = new Vector2 (newDimensions, newDimensions);
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles == 2)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 0.7f;
                circle.transform.localScale = new Vector2 (newDimensions, newDimensions);
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().largerProjectiles == 3)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 0.9f;
                circle.transform.localScale = new Vector2 (newDimensions, newDimensions);
            }
            else
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 1.3f;
                circle.transform.localScale = new Vector2 (newDimensions, newDimensions);
            }

            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets == 0)
            {
                projectileXoffset = 1.2f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets == 1)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 3.5f;
                circle.transform.localScale = new Vector2 (newDimensions, circle.transform.localScale.y);
                projectileXoffset = 1.2f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets == 2)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 4.5f;
                circle.transform.localScale = new Vector2 (newDimensions, circle.transform.localScale.y);
                projectileXoffset = 1.4f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().stretchyBullets == 3)
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 6.5f;
                circle.transform.localScale = new Vector2 (newDimensions, circle.transform.localScale.y);  
                projectileXoffset = 1.6f;
            }
            else
            {
                newDimensions = initialCircleDimensions.x;
                newDimensions += initialCircleDimensions.x * 8.5f;
                circle.transform.localScale = new Vector2 (newDimensions, circle.transform.localScale.y);  
                projectileXoffset = 1.85f;
            }

            //POWER UP

            // Get the Rigidbody component of the mini circle
            Rigidbody2D circleRb = circle.GetComponent<Rigidbody2D>();

            // Apply the fire force to the mini circle
            circleRb.AddForce(transform.right * fireForce, ForceMode2D.Impulse);

            // Update the last fire time
            lastFireTime = Time.time;          
            
            //POWER UP
            
            //Stacks 5x. everytime time between firing decreases by 5%
            
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire == 0)
            {
                fireRate = initialFireRate;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire == 1)
            {
                fireRate = initialFireRate - 0.1f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire == 2)
            {
                fireRate = initialFireRate - 0.2f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileFire == 3)
            {
                fireRate = initialFireRate - 0.3f;
            }
            else
            {
                fireRate = initialFireRate - 0.4f;
            }

            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles % 1.0f == 0 && powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles > 0)
            {
                extraShotActive = true;
            }

            if (extraShotActive == true)
            {
                // 1/5 chance goes to 1/4 to 1/3 etc. 
                randomLastNum = 7 - powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().extraProjectiles;
                RandomNum = Random.Range(1, randomLastNum);
                if (RandomNum == 1)
                {
                    fireRate /= 2;
                    endExtraShot = false;
                    extraShotActive = false;
                }
                // I don't think the else should execute cause the if already did lol
            }
            else if (extraShotActive == false && endExtraShot == false)
            {
                endExtraShot = true;
                extraShotActive = true;
            }


            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot % 1.0f == 0 && powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot > 0)
            {
                critChanceActive = true;
            }
            if (critChanceActive == true)
            {
                // 1/5 chance goes to 1/4 to 1/3 etc. 
                randomLastNum2 = 7 - powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().criticalShot;
                RandomNum2 = Random.Range(1, randomLastNum2);
                if (RandomNum2 == 1)
                {
                    circle.GetComponent<damageGive>().damage *= 2;
                    circle.GetComponent<SpriteRenderer>().color = Color.black;
                    endCritChance = false;
                    critChanceActive = false;
                }
                // I don't think the else should execute cause the if already did lol
            }
            else if (critChanceActive == false && endCritChance == false)
            {
                endCritChance = true;
                critChanceActive = true;
            }
            
            //Additional POWER UP

            //Stacks 5x. everytime time bullet speed increases by 8%
            
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed == 0)
            {
                fireForce = initialFireForce;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed == 1)
            {
                fireForce = initialFireForce + initialFireForce * 0.15f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed == 2)
            {
                fireForce = initialFireForce + initialFireForce * 0.3f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterProjectileSpeed == 3)
            {
                fireForce = initialFireForce + initialFireForce * 0.45f;
            }
            else
            {
                fireForce = initialFireForce + initialFireForce * 0.60f;
            }

            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().doubleStream != 0)
            {
                if (doubleStreamDone == false)
                {
                    fireRate = 0f;
                    circle.transform.localPosition = new Vector2 (circle.transform.localPosition.x, circle.transform.localPosition.y + 0.5f);
                    doubleStreamDone = true;
                }
                else if (doubleStreamDone == true)
                {
                    circle.transform.localPosition = new Vector2 (circle.transform.localPosition.x, circle.transform.localPosition.y - 0.5f);
                    // firerate should go back to normal because of the firerate upgrade
                    doubleStreamDone = false;
                }
            }

            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().vStream != 0)
            {
                if (vStreamDone == 0)
                {
                    circle.transform.localPosition = new Vector2 (circle.transform.localPosition.x + 0.2f, circle.transform.localPosition.y);
                    fireRate = 0f;
                    vStreamDone = 1;
                }
                else if (vStreamDone == 1)
                {
                    circleRb.velocity = Vector2.zero;
                    circleRb.AddForce(new Vector2(1f, 1f) * fireForce, ForceMode2D.Impulse);
                    fireRate = 0;
                    vStreamDone = 2;
                }
                else
                {
                    circleRb.velocity = Vector2.zero;
                    circleRb.AddForce(new Vector2(1f, -1f) * fireForce, ForceMode2D.Impulse);
                    // firerate should go back to normal
                    vStreamDone = 0;
                }
            }


            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().semiAuto == 0)
            {
                
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().semiAuto == 1)
            {
                fireRate /= 2f;
                circle.GetComponent<damageGive>().damage /= 1.4f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().semiAuto == 2)
            {
                fireRate /= 4f;
                circle.GetComponent<damageGive>().damage /= 2.5f;
            }

            audioSource.Play();
        }
    }
}