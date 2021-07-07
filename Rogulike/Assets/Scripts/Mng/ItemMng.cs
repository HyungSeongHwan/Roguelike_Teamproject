using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMng
{
    static ItemMng ins = null;
    public static ItemMng Ins
    {
        get
        {
            if (ins == null) ins = new ItemMng();
            return ins;
        }
    }

    public enum Enum_ItemType { sworld };

    public List<ItemObj> HaveItemlist = new List<ItemObj>();
    public bool isGainNewItem = false;

    public void GainNewItem(ItemObj item)
    {
        HaveItemlist.Add(item);
        isGainNewItem = true;
    }
}
