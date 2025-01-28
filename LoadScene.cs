using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class LoadScene : PersistentMonoBehaviour
{
    public async void HailMary()
    {
        await ZSerialize.LoadScene();
    }
}
