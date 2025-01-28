using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitAreYouSure : MonoBehaviour
{
    public Canvas AreYouSure;

    public void areYouSure()
    {
        AreYouSure.enabled = true;
    }
    public void noImNot()
    {
        AreYouSure.enabled = false;
    }
}
