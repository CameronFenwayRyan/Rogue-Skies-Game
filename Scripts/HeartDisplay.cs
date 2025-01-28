using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeartDisplay : MonoBehaviour
{
    public Sprite redSprite;
    public Sprite goldSprite;
    public GameObject healthScriptableObject;
    public Canvas LevelChangeScreen;
    public Image heartDisplay;
    public TextMeshProUGUI HeartAmount;

    void Update()
    {
        if (LevelChangeScreen.enabled == true)
        {
            if (healthScriptableObject.GetComponent<healthScriptableObject>().health <= 3)
            {
                heartDisplay.sprite = redSprite;
            }
            else
            {
                heartDisplay.sprite = goldSprite;
            }
        }

        HeartAmount.text = "x" + healthScriptableObject.GetComponent<healthScriptableObject>().health;
    }
}
