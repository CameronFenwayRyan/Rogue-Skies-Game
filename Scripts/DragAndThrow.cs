using UnityEngine;
using TMPro;

public class DragAndThrow : MonoBehaviour
{
    // The force that will be applied to the object when it is thrown
    public float throwForce;

    // The Rigidbody component of the object that will be thrown
    private Rigidbody2D rb;

    public Sprite JetDown;
    public Sprite JetUp;
    public Sprite JetNormal;

    private int winAnimationTimer = 0;
    public bool winAnimation = false;
    private int planeStartAnimation = 0;
    public bool planeStart = false;
    public bool deathAnimation = false;
    private int deathAnimationTimer = 0;


    public TextMeshProUGUI LevelCompleteText1;
    public TextMeshProUGUI LevelCompleteText2;
    public TextMeshProUGUI StartText1;
    public TextMeshProUGUI StartText2;

    public GameObject orderScriptableObject;

    private bool animationTimerReset = false;
    public GameObject pauseScreen;
    public GameObject powerUpWinScreen;
    public GameObject powerUpScriptableObject;

    public ParticleSystem playerExplosion;
    public Canvas deathScreen;

    void Start()
    {
        // Get the Rigidbody component of the object
        rb = GetComponent<Rigidbody2D>();
        orderScriptableObject = GameObject.FindGameObjectWithTag("Order");
    }

    void Update()
    {
        // If the plane isn't flying forward in victory or forward onto the screen to start the level
        if (winAnimation == false && planeStart == false && pauseScreen.GetComponent<Canvas>().enabled == false && powerUpWinScreen.GetComponent<Canvas>().enabled == false && deathAnimation == false)
        {
            // POWERUP
            
            if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying == 0)
            {
                throwForce = 1.0f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying == 1)
            {
                throwForce = 1.2f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying == 2)
            {
                throwForce = 1.4f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying == 3)
            {
                throwForce = 1.6f;
            }
            else if (powerUpScriptableObject.GetComponent<PowerUpScriptableObject>().fasterFlying == 4)
            {
                throwForce = 1.7f;
            }
            else
            {
                throwForce = 1.8f;
            }


            transform.position = new Vector2(-9.050028f, transform.position.y);
            transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
            // Check if the screen is touched
            if (Input.touchCount > 0)
            {
                // Get the touch position
                Vector2 touchPos = Input.GetTouch(0).position;
                Vector2 touchPosVectorY = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (transform.position.y > touchPosVectorY.y)
                {
                    GetComponent<SpriteRenderer>().sprite = JetDown;
                }
                else if (transform.position.y < touchPosVectorY.y)
                {
                    GetComponent<SpriteRenderer>().sprite = JetUp;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = JetNormal;
                }

                // Calculate the direction in which the object should be thrown
                Vector3 throwDirection = Camera.main.ScreenToWorldPoint(new Vector2(0, touchPos.y));
                throwDirection = throwDirection - transform.position;

                // Apply the force to the object in the calculated direction
                rb.AddForce(throwDirection * throwForce);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = JetNormal;
            }
        }

        if (animationTimerReset == true)
        {
            planeStartAnimation = 0;
            winAnimationTimer = 0;
            animationTimerReset = false;
        }
    }
    // The speed at which the object should move

    void FixedUpdate()
    {
        // Animation that makes the plane fly forward off screen if you win
        if (winAnimation == true && deathAnimation == false)
        {   
            if (winAnimationTimer < 200)
            {
                int numberForCompleteText = orderScriptableObject.GetComponent<OrderScriptableObject>().level - 1;
                LevelCompleteText1.text = new string("LEVEL " + numberForCompleteText + "\nCOMPLETE");
                LevelCompleteText2.text = new string("LEVEL " + numberForCompleteText + "\nCOMPLETE");

                gameObject.GetComponent<UIController>().WinScreenCanvas.GetComponent<Canvas>().enabled = true;
                gameObject.transform.position = new Vector2 (transform.position.x + 0.25f, transform.position.y);
                if (winAnimationTimer % 10 == 0)
                {
                    LevelCompleteText2.enabled = !LevelCompleteText2.enabled;
                }
            }
            else
            {
                animationTimerReset = true;
                gameObject.GetComponent<UIController>().WinScreenCanvas.GetComponent<Canvas>().enabled = false;
                winAnimation = false;
            }
            winAnimationTimer++;
        }

        // Animation that makes the plane fly forward onto screen at the start of the level
        if (planeStart == true)
        {   
            if (planeStartAnimation == 0)
            {
                gameObject.transform.position = new Vector2 (-20f, -0.7f);
            }
            else if (transform.position.x < -9.050028)
            {
                gameObject.transform.position = new Vector2 (transform.position.x + 0.15f, transform.position.y);
                planeStartAnimation++;
            }
            else if (planeStartAnimation < 200f)
            {
                // Wait
            }   
            else
            {
                gameObject.GetComponent<UIController>().StartScreen.GetComponent<Canvas>().enabled = false;

                if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 1 || orderScriptableObject.GetComponent<OrderScriptableObject>().level == 2)
                {
                    int i = Random.Range(0, 5);
                    GameObject FirstPrefab = orderScriptableObject.GetComponent<OrderScriptableObject>().Level1Easy[i];
                    Instantiate(FirstPrefab.GetComponent<Object>(), FirstPrefab.GetComponent<PickNextPrefab>().spawnLocation, transform.rotation);
                    orderScriptableObject.GetComponent<OrderScriptableObject>().addToPrefabsUsed(FirstPrefab);
                }
                else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 3)
                {
                    int i = Random.Range(0, 5);
                    GameObject FirstPrefab = orderScriptableObject.GetComponent<OrderScriptableObject>().Level3Easy[i];
                    Instantiate(FirstPrefab.GetComponent<Object>(), FirstPrefab.GetComponent<PickNextPrefab>().spawnLocation, transform.rotation);
                    orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed.Clear();
                    orderScriptableObject.GetComponent<OrderScriptableObject>().addToPrefabsUsed(FirstPrefab);
                }
                else if (orderScriptableObject.GetComponent<OrderScriptableObject>().level == 4)
                {
                    int i = Random.Range(0, 5);
                    GameObject FirstPrefab = orderScriptableObject.GetComponent<OrderScriptableObject>().Level4Easy[i];
                    Instantiate(FirstPrefab.GetComponent<Object>(), FirstPrefab.GetComponent<PickNextPrefab>().spawnLocation, transform.rotation);
                    orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed.Clear();
                    orderScriptableObject.GetComponent<OrderScriptableObject>().addToPrefabsUsed(FirstPrefab);
                }
                else
                {
                    int i = Random.Range(0, 5);
                    GameObject FirstPrefab = orderScriptableObject.GetComponent<OrderScriptableObject>().Levels3and4Complete[i];
                    Instantiate(FirstPrefab.GetComponent<Object>(), FirstPrefab.GetComponent<PickNextPrefab>().spawnLocation, transform.rotation);
                    orderScriptableObject.GetComponent<OrderScriptableObject>().PrefabsUsed.Clear();
                }
                animationTimerReset = true;
                planeStart = false;
            }
            if (planeStartAnimation < 200)
            {
                StartText1.text = new string("LEVEL " + orderScriptableObject.GetComponent<OrderScriptableObject>().level + "\nSTART");
                StartText2.text = new string("LEVEL " + orderScriptableObject.GetComponent<OrderScriptableObject>().level + "\nSTART");

                gameObject.GetComponent<UIController>().StartScreen.GetComponent<Canvas>().enabled = true;
                if (planeStartAnimation % 10 == 0)
                {
                    StartText2.enabled = !StartText2.enabled;
                }
            }     
            planeStartAnimation++;
        }

        if (deathAnimation == true)
        {
            if (deathAnimationTimer == 0)
            {
                playerExplosion = Instantiate(playerExplosion, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
            else if (deathAnimationTimer < 20)
            {
                if (playerExplosion != null)
                {
                    playerExplosion.transform.position = gameObject.transform.position;
                }
                gameObject.transform.localPosition = new Vector3 (gameObject.transform.localPosition.x + 0.2f, gameObject.transform.localPosition.y - 0.05f, gameObject.transform.localPosition.y);
            }
            else if (deathAnimationTimer < 40)
            {
                if (playerExplosion != null)
                {
                    playerExplosion.transform.position = gameObject.transform.position;
                }
                gameObject.transform.localPosition = new Vector3 (gameObject.transform.localPosition.x + 0.15f, gameObject.transform.localPosition.y - 0.1f, gameObject.transform.localPosition.y);
            }
            else if (deathAnimationTimer < 110)
            {
                if (playerExplosion != null)
                {
                    playerExplosion.transform.position = gameObject.transform.position;
                }
                gameObject.transform.localPosition = new Vector3 (gameObject.transform.localPosition.x + 0.1f, gameObject.transform.localPosition.y - 0.15f, gameObject.transform.localPosition.y);
            }
            else
            {
                deathScreen.enabled = true;
                deathAnimationTimer = 0;
                Time.timeScale = 0;
            }
            deathAnimationTimer++;
            
        }
    }
}
