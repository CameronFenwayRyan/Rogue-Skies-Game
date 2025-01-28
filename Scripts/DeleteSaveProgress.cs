using UnityEngine;
using ZSerializer;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteSaveProgress : PersistentMonoBehaviour
{
    public void Deletesave()
    {
        ZSerialize.DeleteAllSaveFiles();
    }
}
