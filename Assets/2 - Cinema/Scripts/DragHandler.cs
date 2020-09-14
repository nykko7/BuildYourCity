using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
  public static GameObject itemDragging;
  Vector3 startPosition;
  Transform startParent;
  Transform dragParent;
  DisplayAsistentes displayAsistentes;

  GameObject FilaAsistentes;

  public bool sentado;
  void Start()
  {
    FilaAsistentes = GameObject.FindGameObjectWithTag("FilaAsistentes");

    dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    displayAsistentes = GameObject.FindObjectOfType<DisplayAsistentes>();
    sentado = false;

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void OnBeginDrag(PointerEventData eventData)
  {
    if (sentado) return;

    itemDragging = gameObject;
    startPosition = transform.position;
    startParent = transform.parent;
    transform.SetParent(dragParent);
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (sentado) return;
    Vector3 screenPoint = Input.mousePosition;
    screenPoint.z = 20.0f; //distance of the plane from the camera
    transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

    //transform.position = Input.mousePosition;

  }

  public void OnEndDrag(PointerEventData eventData)
  {

    if (sentado) return;

    itemDragging = null;
    int arrastre;

    if (transform.parent == dragParent)
    {
      FindObjectOfType<AudioManager>().Play("BadMove");
      transform.position = startPosition;
      transform.SetParent(startParent);
      transform.SetSiblingIndex(0);
      arrastre = 0;

    }
    else if (transform.parent != FilaAsistentes.transform)
    {
      FindObjectOfType<AudioManager>().Play("GoodMove");
      displayAsistentes.AgregarAsistente();
      sentado = true;
      arrastre = 1;
    }
    else
    {
      FindObjectOfType<AudioManager>().Play("BadMove");
      arrastre = 0;
    }

    RegistrarArrastreAsistente(arrastre);
    //StartCoroutine(RegistrarArrastreAsistente(arrastre));    


  }

  //private IEnumerator RegistrarArrastreAsistente(int arrastre)
  private void RegistrarArrastreAsistente(int arrastre)
  {
    string posicion = GetComponent<Asistente>().boleto.fila + GetComponent<Asistente>().boleto.columna;
    int elemento = 666;
    if (posicion == "A1")
      elemento = 27201;
    if (posicion == "A2")
      elemento = 27202;
    if (posicion == "A3")
      elemento = 27203;
    if (posicion == "A4")
      elemento = 27204;
    if (posicion == "A5")
      elemento = 27205;
    if (posicion == "A6")
      elemento = 27206;
    if (posicion == "A7")
      elemento = 27207;
    if (posicion == "B1")
      elemento = 27208;
    if (posicion == "B2")
      elemento = 27209;
    if (posicion == "B3")
      elemento = 27210;
    if (posicion == "B4")
      elemento = 27211;
    if (posicion == "B5")
      elemento = 27212;
    if (posicion == "B6")
      elemento = 27213;
    if (posicion == "B7")
      elemento = 27214;
    if (posicion == "C1")
      elemento = 27215;
    if (posicion == "C2")
      elemento = 27216;
    if (posicion == "C3")
      elemento = 27217;
    if (posicion == "C4")
      elemento = 27218;
    if (posicion == "C5")
      elemento = 27219;
    if (posicion == "C6")
      elemento = 27220;
    if (posicion == "C7")
      elemento = 27221;
    if (posicion == "D1")
      elemento = 27222;
    if (posicion == "D2")
      elemento = 27223;
    if (posicion == "D3")
      elemento = 27224;
    if (posicion == "D4")
      elemento = 27225;
    if (posicion == "D5")
      elemento = 27226;
    if (posicion == "D6")
      elemento = 27227;
    if (posicion == "D7")
      elemento = 27228;
    if (posicion == "E1")
      elemento = 27229;
    if (posicion == "E2")
      elemento = 27230;
    if (posicion == "E3")
      elemento = 27231;
    if (posicion == "E4")
      elemento = 27232;
    if (posicion == "E5")
      elemento = 27233;
    if (posicion == "E6")
      elemento = 27234;
    if (posicion == "E7")
      elemento = 27235;
    if (posicion == "F1")
      elemento = 27236;
    if (posicion == "F2")
      elemento = 27237;
    if (posicion == "F3")
      elemento = 27238;
    if (posicion == "F4")
      elemento = 27239;
    if (posicion == "F5")
      elemento = 27240;
    if (posicion == "F6")
      elemento = 27241;
    if (posicion == "F7")
      elemento = 27242;


    GetComponent<EnvioDatos>().ButtonPressed(gameObject, 272, elemento, arrastre);
    //yield return null; 
  }
}
