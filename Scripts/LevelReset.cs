using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;
using System.Threading.Tasks;

public class LevelReset : MonoBehaviour
{
    public GameObject healthScriptableObject;
    public GameObject PowerUpScriptableObject; 
    public GameObject orderScriptableObject;
    public GameObject Spinner;
    public AudioSource audioSource;
    public AudioClip Lvl1Song;
    private GameObject saveManager;
    // Called only when the game first starts
    // Resets health, total EXP and PowerUps
    async void Start()
    {
        PowerUpScriptableObject = GameObject.FindGameObjectWithTag("PowerUp");
        healthScriptableObject = GameObject.FindGameObjectWithTag("Health");
        orderScriptableObject = GameObject.FindGameObjectWithTag("Order");
        saveManager = GameObject.FindGameObjectWithTag("saveManager");
        audioSource.clip = Lvl1Song;
        audioSource.Play();
        healthScriptableObject.GetComponent<healthScriptableObject>().reset();
        PowerUpScriptableObject.GetComponent<PowerUpScriptableObject>().reset();
        orderScriptableObject.GetComponent<OrderScriptableObject>().reset();

        if (Cont.CarryOn == true)
        {
            await ZSerialize.LoadScene();
        }

        Reset();
    }
    public async void Reset()
    {
        Spinner.GetComponent<SpinWheel>().resetSpinWheel();
        orderScriptableObject.GetComponent<OrderScriptableObject>().ChangeLevelEnemies();
        orderScriptableObject.GetComponent<OrderScriptableObject>().order = 0;
        GameObject.FindGameObjectWithTag("Plane").GetComponent<DragAndThrow>().planeStart = true;
        ZSerialize.DeleteAllSaveFiles();
        await ZSerialize.SaveScene();
    }
}
