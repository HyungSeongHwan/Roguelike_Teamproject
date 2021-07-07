using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public bool isHaveItem = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Transform kItem = eventData.pointerDrag.transform;
            kItem.SetParent(transform);
            kItem.localPosition = new Vector3(0, 0, 0);

            SetIsHaveItem(true);
        }
    }

    public void SetIsHaveItem(bool bHaveItem)
    { isHaveItem = bHaveItem; }
}
