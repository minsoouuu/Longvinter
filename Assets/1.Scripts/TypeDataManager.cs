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
    Pocket,
    #region Equipment

    Gun,
    Ammo,
    Rifle,

    #endregion
    #region Metarial

    Blackberry,
    Wood,

    #endregion
    #region Food

    Bread,
    Blackberryjam,
    Cake,

    #endregion
    #region Plant

    Fence,
    Bench,

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
