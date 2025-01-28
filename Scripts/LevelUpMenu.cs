using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelreset;
    public void ContinueToNextLevel()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        levelreset.GetComponent<LevelReset>().Reset();
    }
}
