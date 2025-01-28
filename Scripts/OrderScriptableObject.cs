using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using ZSerializer;

[CreateAssetMenu(fileName = "OrderScriptableObject", menuName = "ScriptableObjects/OrderScriptableObject", order = 1)]
public class OrderScriptableObject : PersistentMonoBehaviour
{
    public int order;
    public int level;

    public List<GameObject> PreserveLevel1Easy;
    public List<GameObject> PreserveLevel1Medium;
    public List<GameObject> PreserveLevel1Hard;

    public List<GameObject> PrefabsUsed;
    public List<GameObject> Level1Easy;
    public List<GameObject> Level1Medium;
    public List<GameObject> Level1Hard;
    public List<GameObject> Level2Easy;
    public List<GameObject> Level2Medium;
    public List<GameObject> Level2Hard;
    public List<GameObject> Level3Easy;
    public List<GameObject> Level3Medium;
    public List<GameObject> Level3Hard;
    public List<GameObject> Level4Easy;
    public List<GameObject> Level4Medium;
    public List<GameObject> Level4Hard;

    public List<GameObject> Levels3and4Complete;

    // HERE FOR TESTING PURPOSES
    [NonZSerialized] public bool spawnEnemies = true;

    public void ChangeLevelEnemies()
    {
        // For level 2, we're going to keep the same Prefabs used so you're getting all of the new prefabs
        // Plus the 2 that we didn't use before so the player will be seeing 4 prefabs for the first time
        if (level == 2)
        {
            Level1Easy.AddRange(Level2Easy);
            Level1Medium.AddRange(Level2Medium);
            Level1Hard.AddRange(Level2Hard);
        }
    }

    public void reset()
    {
        order = 0;
        level = 1;
        PrefabsUsed = new List<GameObject>();

        // Reset Lists
        Level1Easy.Clear();
        Level1Medium.Clear();
        Level1Hard.Clear();
        
        foreach (GameObject b in PreserveLevel1Easy)
        {
            Level1Easy.Add(b);
        }
        foreach (GameObject b in PreserveLevel1Medium)
        {
            Level1Medium.Add(b);
        }
        foreach (GameObject b in PreserveLevel1Hard)
        {
            Level1Hard.Add(b);
        }
    }
    public void IterateVariable()
    {
        order++;
    }
    public void addToPrefabsUsed(GameObject prefab)
    {
        PrefabsUsed.Add(prefab);
    }
}
