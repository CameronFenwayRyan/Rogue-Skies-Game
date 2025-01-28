[System.Serializable]
public sealed class OrderScriptableObjectZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 order;
    public System.Int32 level;
    public System.Collections.Generic.List<UnityEngine.GameObject> PreserveLevel1Easy;
    public System.Collections.Generic.List<UnityEngine.GameObject> PreserveLevel1Medium;
    public System.Collections.Generic.List<UnityEngine.GameObject> PreserveLevel1Hard;
    public System.Collections.Generic.List<UnityEngine.GameObject> PrefabsUsed;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level1Easy;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level1Medium;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level1Hard;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level2Easy;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level2Medium;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level2Hard;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level3Easy;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level3Medium;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level3Hard;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level4Easy;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level4Medium;
    public System.Collections.Generic.List<UnityEngine.GameObject> Level4Hard;
    public System.Collections.Generic.List<UnityEngine.GameObject> Levels3and4Complete;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public OrderScriptableObjectZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         order = (System.Int32)typeof(OrderScriptableObject).GetField("order").GetValue(instance);
         level = (System.Int32)typeof(OrderScriptableObject).GetField("level").GetValue(instance);
         PreserveLevel1Easy = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("PreserveLevel1Easy").GetValue(instance);
         PreserveLevel1Medium = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("PreserveLevel1Medium").GetValue(instance);
         PreserveLevel1Hard = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("PreserveLevel1Hard").GetValue(instance);
         PrefabsUsed = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("PrefabsUsed").GetValue(instance);
         Level1Easy = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level1Easy").GetValue(instance);
         Level1Medium = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level1Medium").GetValue(instance);
         Level1Hard = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level1Hard").GetValue(instance);
         Level2Easy = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level2Easy").GetValue(instance);
         Level2Medium = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level2Medium").GetValue(instance);
         Level2Hard = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level2Hard").GetValue(instance);
         Level3Easy = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level3Easy").GetValue(instance);
         Level3Medium = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level3Medium").GetValue(instance);
         Level3Hard = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level3Hard").GetValue(instance);
         Level4Easy = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level4Easy").GetValue(instance);
         Level4Medium = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level4Medium").GetValue(instance);
         Level4Hard = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Level4Hard").GetValue(instance);
         Levels3and4Complete = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(OrderScriptableObject).GetField("Levels3and4Complete").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(OrderScriptableObject).GetField("order").SetValue(component, order);
         typeof(OrderScriptableObject).GetField("level").SetValue(component, level);
         typeof(OrderScriptableObject).GetField("PreserveLevel1Easy").SetValue(component, PreserveLevel1Easy);
         typeof(OrderScriptableObject).GetField("PreserveLevel1Medium").SetValue(component, PreserveLevel1Medium);
         typeof(OrderScriptableObject).GetField("PreserveLevel1Hard").SetValue(component, PreserveLevel1Hard);
         typeof(OrderScriptableObject).GetField("PrefabsUsed").SetValue(component, PrefabsUsed);
         typeof(OrderScriptableObject).GetField("Level1Easy").SetValue(component, Level1Easy);
         typeof(OrderScriptableObject).GetField("Level1Medium").SetValue(component, Level1Medium);
         typeof(OrderScriptableObject).GetField("Level1Hard").SetValue(component, Level1Hard);
         typeof(OrderScriptableObject).GetField("Level2Easy").SetValue(component, Level2Easy);
         typeof(OrderScriptableObject).GetField("Level2Medium").SetValue(component, Level2Medium);
         typeof(OrderScriptableObject).GetField("Level2Hard").SetValue(component, Level2Hard);
         typeof(OrderScriptableObject).GetField("Level3Easy").SetValue(component, Level3Easy);
         typeof(OrderScriptableObject).GetField("Level3Medium").SetValue(component, Level3Medium);
         typeof(OrderScriptableObject).GetField("Level3Hard").SetValue(component, Level3Hard);
         typeof(OrderScriptableObject).GetField("Level4Easy").SetValue(component, Level4Easy);
         typeof(OrderScriptableObject).GetField("Level4Medium").SetValue(component, Level4Medium);
         typeof(OrderScriptableObject).GetField("Level4Hard").SetValue(component, Level4Hard);
         typeof(OrderScriptableObject).GetField("Levels3and4Complete").SetValue(component, Levels3and4Complete);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}