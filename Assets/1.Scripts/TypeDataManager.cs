using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum InvenItemType
{
    Equipments,
    Materials,
    Foods,
    Plants
}
public enum ObjectType
{
    BuySlot,
    SellSlot
}
public enum ItemName
{
    #region Equipment
    Ammo,
    AmmoPouch,
    FullAutoPistol,
    SemiAutoPistol,
    MoertnBurstRifle,
    ModernRifle,
    Rifle,
    SemiRifle,
    Shotgun,
    SMG,
    Chainsaw,
    FishingRod,
    GPS,
    Hat,
    Gatchet,
    GatCombat,
    GatFarming,
    KeycardStandart,
    Map,
    TelescopicReel,


    #endregion
    #region Metarial

    Blackberry,
    Cloudberry,
    Raspberry,
    SugarBeet,
    Salt,
    Pepper,
    Perch,
    SalmonShark,
    Tuna,
    ArcticChar,
    Wood,
    Planks,
    Fuel,
    Peacock,
    HazelHenNormal,
    Matches,
    WaterCanister,


    #endregion
    #region Food

    Bread,
    Cake,
    Croissant,
    EnergyDrink,
    HeatPack,
    SnackBar,
    Chanterelle,
    BlackberryJam,
    CloudberryJam,
    RaspberryJam,
    CookedPerch,
    CookedSalmonShark,
    CookedTuna,


    #endregion
    #region Plant
    FenceGate,
    Bench,
    Container,
    Firepit,
    Turret,
    VillageLampPost,
    WoodStool,
    Kamiina,
    Sauna,
    Tent,
    TrimmedBush,
    Vendor,
    LightBulb,
    Placeholder,


    #endregion
}
public enum MonsterType
{
    Rat,
    Test2,
    Test3
}
public enum HouseType
{
    Test1,
    Test2,
    Test3,
    Test4
}
public static class EnumUtil<T>
{
    public static T Parse(string s)
    {
        return (T)Enum.Parse(typeof(T), s);
    }
}
