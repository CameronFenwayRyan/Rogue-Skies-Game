using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas WinScreenCanvas;
    public Canvas LevelMenu;
    public Canvas PowerUpScreen;
    public Canvas StartScreen;

    // All of our UI canvases are gonna be stored in here to make everything far more organized

    void OnEnable()
    {
        WinScreenCanvas.GetComponent<Canvas>().enabled = false;
        LevelMenu.GetComponent<Canvas>().enabled = false;
        PowerUpScreen.GetComponent<Canvas>().enabled = false;
        StartScreen.GetComponent<Canvas>().enabled = false;
    }
}
