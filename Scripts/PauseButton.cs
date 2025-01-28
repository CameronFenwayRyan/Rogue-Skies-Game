using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseScreen;
    public AudioSource musicAudio;

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.GetComponent<Canvas>().enabled = true;
        musicAudio.volume = 0.05f;
    }
}
