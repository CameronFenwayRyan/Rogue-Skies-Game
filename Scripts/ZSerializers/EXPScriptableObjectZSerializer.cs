[System.Serializable]
public sealed class EXPScriptableObjectZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Single EXP;
    public System.Int32 sliderIteration;
    public UnityEngine.GameObject health;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public EXPScriptableObjectZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         EXP = (System.Single)typeof(EXPScriptableObject).GetField("EXP").GetValue(instance);
         sliderIteration = (System.Int32)typeof(EXPScriptableObject).GetField("sliderIteration").GetValue(instance);
         health = (UnityEngine.GameObject)typeof(EXPScriptableObject).GetField("health").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(EXPScriptableObject).GetField("EXP").SetValue(component, EXP);
         typeof(EXPScriptableObject).GetField("sliderIteration").SetValue(component, sliderIteration);
         typeof(EXPScriptableObject).GetField("health").SetValue(component, health);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}