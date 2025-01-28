using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthSaveData
{
    public int health;

    public HealthSaveData (healthScriptableObject healthScriptableObject)
    {
        health = healthScriptableObject.health;
    }
}
