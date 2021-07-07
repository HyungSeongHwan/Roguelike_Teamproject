using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenDlg : MonoBehaviour
{
    [SerializeField] List<Slot> Slotlist = new List<Slot>();
    [SerializeField] GameObject PrefabItemUI;

    private void Update()
    {
        SlotUpdate();
    }

    public void Initialize()
    {

    }

    private void SlotUpdate()
    {
        ItemMng itemMng = ItemMng.Ins;
        if (!itemMng.isGainNewItem) return;

        for (int i = 0; i < Slotlist.Count; ++i)
        {
            if (itemMng.HaveItemlist[i] != null)
            {
                GameObject goItem;
                
                if (Slotlist[i].isHaveItem) goItem = Instantiate(PrefabItemUI, Slotlist[i + 1].transform);
                else goItem = Instantiate(PrefabItemUI, Slotlist[i].transform);

                ItemUI itemUI = goItem.GetComponent<ItemUI>();
                itemUI.Initialize(itemMng.HaveItemlist[i].ID);
            }

            if (i == (itemMng.HaveItemlist.Count - 1))
            {
                itemMng.isGainNewItem = false;
                break;
            }
        }
    }
}
