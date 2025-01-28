using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEXPTest : MonoBehaviour
{
    public EXPScriptableObject eXPScriptableObject;
    void AddExp()
    {
        eXPScriptableObject.EXP += 1000;
    }
    
}
