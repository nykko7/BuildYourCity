using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandlerTaxi2 : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
  public static GameObject itemDragging;
  Vector3 startPosition;
  Transform startParent;
  Transform dragParent;
  DisplayStudents displayStudents;

  GameObject FilaEstudiantes;

  public bool sentado;
  void Start()
  {
    FilaEstudiantes = GameObject.FindGameObjectWithTag("FilaEstudiantes");

    dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    displayStudents = GameObject.FindObjectOfType<DisplayStudents>();
    if (!sentado)
    {
      sentado = false;
    }

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
      transform.position = startPosition;
      transform.SetParent(startParent);
      transform.SetSiblingIndex(0);
      arrastre = 0;

    }
    else if (transform.parent != FilaEstudiantes.transform)
    {
      displayStudents.AddStudent();
      sentado = true;
      arrastre = 1;
    }
    else
    {
      arrastre = 0;
    }

    RegistrarArrastreAsistente(arrastre);
    //StartCoroutine(RegistrarArrastreAsistente(arrastre));    


  }

  //private IEnumerator RegistrarArrastreAsistente(int arrastre)
  private void RegistrarArrastreAsistente(int arrastre)
  {
    GetComponent<EnvioDatos>().ButtonPressed(gameObject, 2702, 270201, arrastre);
    //yield return null; 
  }
}
