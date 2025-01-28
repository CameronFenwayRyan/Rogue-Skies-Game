using UnityEngine;
using ZSerializer;

[CreateAssetMenu(fileName = "healthScriptableObject", menuName = "ScriptableObjects/healthScriptableObject", order = 1)]
public class healthScriptableObject : PersistentMonoBehaviour
{
    public int health = 3;

    public void reset()
    {
        health = 3;
    }
}
