using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FilaAsistentes : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragHandler.itemDragging.transform.SetParent(transform);
        DragHandler.itemDragging.transform.SetSiblingIndex(0);
    }
}
