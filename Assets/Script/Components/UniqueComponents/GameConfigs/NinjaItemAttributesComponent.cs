using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NinjaItemAttributesComponent : IComponent
{
    public Dictionary<string, NinjaItem> dic;
}

[DataContract]
public class NinjaItemAttributes
{
    [DataMember]
    public Dictionary<string, NinjaItem> dic;
}

[DataContract]
public class NinjaItem
{
    [DataMember]
    public string ninjaItemName;
    [DataMember]
    public string ninjaItemDescribe;
    [DataMember]
    public string ninjaItemEffect;

    //-type
    [DataMember]
    public NinjaItemType ninjaItemType;

    //---functional
    [DataMember]
    public List<NinjaItemFunction> ninjaItemFunctions;
    [DataMember]
    public List<float> ninjaItemFunctionValues;

    //---weapon
    [DataMember]
    public List<NinjaItemWeaponType> ninjaItemWeaponTypes;
    [DataMember]
    public float weaponMass;
    [DataMember]
    public float weaponMaxDamage;
    [DataMember]
    public float weaponMinDamage;
    [DataMember]
    public bool disposableWeapon;
    [DataMember]
    public List<NinjaItemSpecialEffect> ninjaItemSpecialEffects;

    //-----throwing weapon
    [DataMember]
    public Vector3 throwingWeaponBoundingBoxSize;
    [DataMember]
    public float throwingWeaponFlaySpeed;
    [DataMember]
    public float throwingWeaponMaxFlyTime;

    //-----hand held weapon
    [DataMember]
    public float handHeldWeaponAttackPlusRadius;
    [DataMember]
    public float handHeldWeaponHurt;
    [DataMember]
    public float handHeldWeaponAttackTime;

    //-----explode weapon
    [DataMember]
    public bool autoTrigger;
    [DataMember]
    public float autoTriggerRadius;
    [DataMember]
    public float triggerTimeDelay;
    [DataMember]
    public bool manualTrigger;
    [DataMember]
    public float manualTriggerMaxDistance;

}

public enum NinjaItemType
{
    Functional,
    Weapon
}

public enum NinjaItemFunction
{
    Health,
    ChaKuRa,
    TaiRyuKu
}

public enum NinjaItemWeaponType
{
    Throwing,
    HandHeld,
    Placing,
    Explode
}

public enum NinjaItemSpecialEffect
{
    MinatoHiRaiShinMaKinGu,

}