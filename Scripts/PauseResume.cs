using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject pauseScreen;
    public AudioSource musicAudio;

    public void Unpause()
    {
        pauseScreen.GetComponent<Canvas>().enabled = false;
        musicAudio.volume = 0.4f;
        Time.timeScale = 1f;
    }
}
