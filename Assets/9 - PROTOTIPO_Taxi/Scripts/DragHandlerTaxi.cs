using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandlerTaxi : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging;

    public string direccion = default;
    Vector3 startPosition;
    Transform startParent;
    Transform dragParent;
    GameObject botonRespaldo;
    GameObject parentBoton;
    bool sentado;
    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
        botonRespaldo = gameObject;
        parentBoton = gameObject.transform.parent.gameObject;
        sentado = false;            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(sentado) return;
        itemDragging = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(sentado) return;
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 20.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        
        //transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if(sentado) return;
        itemDragging = null;

        if(transform.parent == dragParent){
            crearBoton();
            Destroy(gameObject);
            
        }else{            
            sentado = true;
            crearBoton();
        }


    }

    private void crearBoton(){
        GameObject botoncreado = Instantiate(botonRespaldo, Vector3.zero, Quaternion.identity);
        botoncreado.transform.SetParent(parentBoton.transform);
        botoncreado.transform.localPosition = new Vector3(0,0,0);
        botoncreado.transform.localScale = new Vector3(1,1,1);
    }

    
}
