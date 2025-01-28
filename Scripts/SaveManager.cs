using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveHealth (healthScriptableObject healthScriptableObject)
    {
        BinaryFormatter foramtter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/health.wow";
        FileStream stream = new FileStream(path, FileMode.Create);

        HealthSaveData data = new HealthSaveData(healthScriptableObject);

        foramtter.Serialize(stream, data);
        stream.Close();
    }

    public static HealthSaveData LoadHealth()
    {
        string path = Application.persistentDataPath + "/health.wow";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HealthSaveData data = formatter.Deserialize(stream) as HealthSaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}