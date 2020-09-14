using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SlotTaxi : MonoBehaviour, IDropHandler
{
    public GameObject botonDropped;
    public bool slotDisponible;

    void Start()
    {
        slotDisponible = true;
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject botonArrastrado = DragHandlerTaxi.itemDragging;    
        Debug.Log(botonArrastrado);
        if (!botonArrastrado) return;
        
        if(slotDisponible){
            slotDisponible = false;
            botonDropped = botonArrastrado;
            botonDropped.transform.SetParent(transform);
            botonDropped.transform.position = transform.position;
            // botonDropped.GetComponentInChildren<Image>().color = new Color32(0,0,0,0);                            
        }

    }

   
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0){
            botonDropped = null;
            slotDisponible = true;
        }
    }
}
