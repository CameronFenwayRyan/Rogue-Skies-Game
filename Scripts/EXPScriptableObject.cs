using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using ZSerializer;

//[CreateAssetMenu(fileName = "EXPScriptableObject", menuName = "ScriptableObjects/EXPScriptableObject")]
public class EXPScriptableObject : PersistentMonoBehaviour
{
    public float EXP = 0;
    public int sliderIteration;
    [NonZSerialized] public GameObject powerUpScreen;
    [NonZSerialized] private Slider slider;
    public GameObject health;

    private void Start()
    {
        EXP = 0;
        health = GameObject.FindGameObjectWithTag("Health");
        powerUpScreen = GameObject.FindGameObjectWithTag("powerUpScreen");
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        sliderIteration = 1;
    }
    private void FixedUpdate()
    {
        slider.value = EXP;

        if (sliderIteration == 1)
        {
            slider.maxValue = 10;
        }
        else if (sliderIteration == 2)
        {
            slider.maxValue = 15;
        }
        else if (sliderIteration == 3)
        {
            slider.maxValue = 20;
        }
        else if (sliderIteration == 4)
        {
            slider.maxValue = 25;
        }
        else if (sliderIteration == 5)
        {
            slider.maxValue = 30;
        }
        else if (sliderIteration == 6)
        {
            slider.maxValue = 35;
        }
        else if (sliderIteration == 7)
        {
            slider.maxValue = 40;
        }
        else if (sliderIteration == 8)
        {
            slider.maxValue = 45;
        }
        else
        {
            slider.maxValue = 50;
        }
    }
    public void IncreaseEXP(float amount)
    {
        FixedUpdate();
        EXP += amount;
        if (EXP >= slider.maxValue && health.GetComponent<healthScriptableObject>().health != 0)
        {
            GameObject.FindGameObjectWithTag("Plane").GetComponentInChildren<UIController>().PowerUpScreen.GetComponent<Canvas>().enabled = true;
            powerUpScreen.GetComponent<RandomCards>().RandomCardsActive();
            Time.timeScale = 0f;

            EXP = 0;
            slider.value = 0;
            sliderIteration++;
        }
    }
}
