using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public AudioSource audioSourceButtonPress;
    public AudioSource audioSourceMusic;
    public Image imageToFade;
    public void Newgame()
    {
        audioSourceButtonPress.Play();
        audioSourceMusic.Stop();
        SceneManager.LoadScene("MobileGame67");
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);   
    }
}
