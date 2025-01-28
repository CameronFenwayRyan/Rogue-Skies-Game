[System.Serializable]
public sealed class PowerUpScriptableObjectZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 largerProjectiles;
    public System.Int32 fasterProjectileFire;
    public System.Int32 fasterProjectileSpeed;
    public System.Int32 twoHearts;
    public System.Int32 maxHealth;
    public System.Int32 extraProjectiles;
    public System.Int32 criticalShot;
    public System.Int32 fasterFlying;
    public System.Int32 stretchyBullets;
    public System.Int32 doubleStream;
    public System.Int32 vStream;
    public System.Int32 crazyBullets;
    public System.Int32 followBullets;
    public System.Int32 semiAuto;
    public UnityEngine.GameObject FasterProjectileFire;
    public UnityEngine.GameObject FasterProjectiles;
    public UnityEngine.GameObject LargerProjectiles;
    public UnityEngine.GameObject TwoHearts;
    public UnityEngine.GameObject MaxHealth;
    public UnityEngine.GameObject ExtraShot;
    public UnityEngine.GameObject CriticalShot;
    public UnityEngine.GameObject DoubleStream;
    public UnityEngine.GameObject StretchyBullets;
    public UnityEngine.GameObject VStream;
    public UnityEngine.GameObject ZigZagBullets;
    public UnityEngine.GameObject FasterFlying;
    public UnityEngine.GameObject FollowBullets;
    public UnityEngine.GameObject SemiAuto;
    public UnityEngine.GameObject PowerUpUICanvas;
    public UnityEngine.GameObject healthScriptableObject;
    public System.Int32 impactExplosionDamage;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PowerUpScriptableObjectZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         largerProjectiles = (System.Int32)typeof(PowerUpScriptableObject).GetField("largerProjectiles").GetValue(instance);
         fasterProjectileFire = (System.Int32)typeof(PowerUpScriptableObject).GetField("fasterProjectileFire").GetValue(instance);
         fasterProjectileSpeed = (System.Int32)typeof(PowerUpScriptableObject).GetField("fasterProjectileSpeed").GetValue(instance);
         twoHearts = (System.Int32)typeof(PowerUpScriptableObject).GetField("twoHearts").GetValue(instance);
         maxHealth = (System.Int32)typeof(PowerUpScriptableObject).GetField("maxHealth").GetValue(instance);
         extraProjectiles = (System.Int32)typeof(PowerUpScriptableObject).GetField("extraProjectiles").GetValue(instance);
         criticalShot = (System.Int32)typeof(PowerUpScriptableObject).GetField("criticalShot").GetValue(instance);
         fasterFlying = (System.Int32)typeof(PowerUpScriptableObject).GetField("fasterFlying").GetValue(instance);
         stretchyBullets = (System.Int32)typeof(PowerUpScriptableObject).GetField("stretchyBullets").GetValue(instance);
         doubleStream = (System.Int32)typeof(PowerUpScriptableObject).GetField("doubleStream").GetValue(instance);
         vStream = (System.Int32)typeof(PowerUpScriptableObject).GetField("vStream").GetValue(instance);
         crazyBullets = (System.Int32)typeof(PowerUpScriptableObject).GetField("crazyBullets").GetValue(instance);
         followBullets = (System.Int32)typeof(PowerUpScriptableObject).GetField("followBullets").GetValue(instance);
         semiAuto = (System.Int32)typeof(PowerUpScriptableObject).GetField("semiAuto").GetValue(instance);
         FasterProjectileFire = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("FasterProjectileFire").GetValue(instance);
         FasterProjectiles = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("FasterProjectiles").GetValue(instance);
         LargerProjectiles = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("LargerProjectiles").GetValue(instance);
         TwoHearts = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("TwoHearts").GetValue(instance);
         MaxHealth = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("MaxHealth").GetValue(instance);
         ExtraShot = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("ExtraShot").GetValue(instance);
         CriticalShot = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("CriticalShot").GetValue(instance);
         DoubleStream = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("DoubleStream").GetValue(instance);
         StretchyBullets = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("StretchyBullets").GetValue(instance);
         VStream = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("VStream").GetValue(instance);
         ZigZagBullets = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("ZigZagBullets").GetValue(instance);
         FasterFlying = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("FasterFlying").GetValue(instance);
         FollowBullets = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("FollowBullets").GetValue(instance);
         SemiAuto = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("SemiAuto").GetValue(instance);
         PowerUpUICanvas = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("PowerUpUICanvas").GetValue(instance);
         healthScriptableObject = (UnityEngine.GameObject)typeof(PowerUpScriptableObject).GetField("healthScriptableObject").GetValue(instance);
         impactExplosionDamage = (System.Int32)typeof(PowerUpScriptableObject).GetField("impactExplosionDamage").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PowerUpScriptableObject).GetField("largerProjectiles").SetValue(component, largerProjectiles);
         typeof(PowerUpScriptableObject).GetField("fasterProjectileFire").SetValue(component, fasterProjectileFire);
         typeof(PowerUpScriptableObject).GetField("fasterProjectileSpeed").SetValue(component, fasterProjectileSpeed);
         typeof(PowerUpScriptableObject).GetField("twoHearts").SetValue(component, twoHearts);
         typeof(PowerUpScriptableObject).GetField("maxHealth").SetValue(component, maxHealth);
         typeof(PowerUpScriptableObject).GetField("extraProjectiles").SetValue(component, extraProjectiles);
         typeof(PowerUpScriptableObject).GetField("criticalShot").SetValue(component, criticalShot);
         typeof(PowerUpScriptableObject).GetField("fasterFlying").SetValue(component, fasterFlying);
         typeof(PowerUpScriptableObject).GetField("stretchyBullets").SetValue(component, stretchyBullets);
         typeof(PowerUpScriptableObject).GetField("doubleStream").SetValue(component, doubleStream);
         typeof(PowerUpScriptableObject).GetField("vStream").SetValue(component, vStream);
         typeof(PowerUpScriptableObject).GetField("crazyBullets").SetValue(component, crazyBullets);
         typeof(PowerUpScriptableObject).GetField("followBullets").SetValue(component, followBullets);
         typeof(PowerUpScriptableObject).GetField("semiAuto").SetValue(component, semiAuto);
         typeof(PowerUpScriptableObject).GetField("FasterProjectileFire").SetValue(component, FasterProjectileFire);
         typeof(PowerUpScriptableObject).GetField("FasterProjectiles").SetValue(component, FasterProjectiles);
         typeof(PowerUpScriptableObject).GetField("LargerProjectiles").SetValue(component, LargerProjectiles);
         typeof(PowerUpScriptableObject).GetField("TwoHearts").SetValue(component, TwoHearts);
         typeof(PowerUpScriptableObject).GetField("MaxHealth").SetValue(component, MaxHealth);
         typeof(PowerUpScriptableObject).GetField("ExtraShot").SetValue(component, ExtraShot);
         typeof(PowerUpScriptableObject).GetField("CriticalShot").SetValue(component, CriticalShot);
         typeof(PowerUpScriptableObject).GetField("DoubleStream").SetValue(component, DoubleStream);
         typeof(PowerUpScriptableObject).GetField("StretchyBullets").SetValue(component, StretchyBullets);
         typeof(PowerUpScriptableObject).GetField("VStream").SetValue(component, VStream);
         typeof(PowerUpScriptableObject).GetField("ZigZagBullets").SetValue(component, ZigZagBullets);
         typeof(PowerUpScriptableObject).GetField("FasterFlying").SetValue(component, FasterFlying);
         typeof(PowerUpScriptableObject).GetField("FollowBullets").SetValue(component, FollowBullets);
         typeof(PowerUpScriptableObject).GetField("SemiAuto").SetValue(component, SemiAuto);
         typeof(PowerUpScriptableObject).GetField("PowerUpUICanvas").SetValue(component, PowerUpUICanvas);
         typeof(PowerUpScriptableObject).GetField("healthScriptableObject").SetValue(component, healthScriptableObject);
         typeof(PowerUpScriptableObject).GetField("impactExplosionDamage").SetValue(component, impactExplosionDamage);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}