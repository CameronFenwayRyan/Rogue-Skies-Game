using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Cont : MonoBehaviour
{
    public static bool CarryOn = false;
    public AudioSource audioSourceButtonPress;
    public AudioSource audioSourceMusic;
    public void Con()
    {
        audioSourceButtonPress.Play();
        audioSourceMusic.Stop();
        CarryOn = true;
        SceneManager.LoadScene("MobileGame67");
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}