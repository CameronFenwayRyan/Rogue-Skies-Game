[System.Serializable]
public sealed class PlayerDamageTakeZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.SpriteRenderer brenderer;
    public UnityEngine.GameObject healthScriptableObject;
    public UnityEngine.GameObject camerA;
    public UnityEngine.GameObject Plane;
    public UnityEngine.AudioSource audioSource;
    public UnityEngine.AudioClip PlayerTakeDamage;
    public UnityEngine.AudioSource deathSongAudioSource;
    public UnityEngine.AudioSource musicAudioSource;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerDamageTakeZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         brenderer = (UnityEngine.SpriteRenderer)typeof(PlayerDamageTake).GetField("brenderer").GetValue(instance);
         healthScriptableObject = (UnityEngine.GameObject)typeof(PlayerDamageTake).GetField("healthScriptableObject").GetValue(instance);
         camerA = (UnityEngine.GameObject)typeof(PlayerDamageTake).GetField("camerA").GetValue(instance);
         Plane = (UnityEngine.GameObject)typeof(PlayerDamageTake).GetField("Plane").GetValue(instance);
         audioSource = (UnityEngine.AudioSource)typeof(PlayerDamageTake).GetField("audioSource").GetValue(instance);
         PlayerTakeDamage = (UnityEngine.AudioClip)typeof(PlayerDamageTake).GetField("PlayerTakeDamage").GetValue(instance);
         deathSongAudioSource = (UnityEngine.AudioSource)typeof(PlayerDamageTake).GetField("deathSongAudioSource").GetValue(instance);
         musicAudioSource = (UnityEngine.AudioSource)typeof(PlayerDamageTake).GetField("musicAudioSource").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PlayerDamageTake).GetField("brenderer").SetValue(component, brenderer);
         typeof(PlayerDamageTake).GetField("healthScriptableObject").SetValue(component, healthScriptableObject);
         typeof(PlayerDamageTake).GetField("camerA").SetValue(component, camerA);
         typeof(PlayerDamageTake).GetField("Plane").SetValue(component, Plane);
         typeof(PlayerDamageTake).GetField("audioSource").SetValue(component, audioSource);
         typeof(PlayerDamageTake).GetField("PlayerTakeDamage").SetValue(component, PlayerTakeDamage);
         typeof(PlayerDamageTake).GetField("deathSongAudioSource").SetValue(component, deathSongAudioSource);
         typeof(PlayerDamageTake).GetField("musicAudioSource").SetValue(component, musicAudioSource);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}