using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class SlotBlock : MonoBehaviour
{
  public BlockLocation ubicacionBlock;
  public int state;
  public int posCorrecta;
  public GameObject taxi;

  private TaxiManager taxiManager;

  private int CambioDeColorEjecutando = 0;

  //COLORES:
  private Image imagenBloque;
  private Color colorRojo = Color.red;
  private Color colorVerde = Color.green;
  private Color colorAmarillo = Color.yellow;
  private Color colorBlanco = Color.white;


  private void Start()
  {
    taxiManager = GameObject.Find("TaxiManager").GetComponent<TaxiManager>();
    GetComponent<Button>().onClick.AddListener(ShowState);
    imagenBloque = GetComponent<Image>();

  }

  private void Update()
  {
    if (state != 2 && CambioDeColorEjecutando == 0)
    {
      Color tempColor = imagenBloque.color;
      tempColor.a = 0;
      imagenBloque.color = tempColor;
    }

  }


  public void ShowState()
  {
    EnvioDatos envioDatos = taxiManager.GetComponent<EnvioDatos>();

    switch (this.state)
    {
      case 0:
        StartCoroutine(CambioColor(imagenBloque, colorRojo));
        break;
      case 1:
        StartCoroutine(CambioColor(imagenBloque, colorVerde));
        break;
      case 2:
        StartCoroutine(CambioColor(imagenBloque, colorAmarillo));
        break;
      default:
        StartCoroutine(CambioColor(imagenBloque, colorBlanco));
        break;
    }

    switch (this.posCorrecta)
    {
      case 0:
        envioDatos.ButtonPressed(gameObject, 274, 27401, this.state);
        break;
      case 1:
        envioDatos.ButtonPressed(gameObject, 274, 27402, this.state);
        break;
      case 2:
        envioDatos.ButtonPressed(gameObject, 274, 27403, this.state);
        break;
      case 3:
        envioDatos.ButtonPressed(gameObject, 274, 27404, this.state);
        break;
      case 4:
        envioDatos.ButtonPressed(gameObject, 274, 27405, this.state);
        break;
      case 5:
        envioDatos.ButtonPressed(gameObject, 274, 27406, this.state);
        break;
      case 6:
        envioDatos.ButtonPressed(gameObject, 274, 27407, this.state);
        break;
      case 7:
        envioDatos.ButtonPressed(gameObject, 274, 27408, this.state);
        break;
      case 8:
        envioDatos.ButtonPressed(gameObject, 274, 27409, this.state);
        break;
    }
  }

  IEnumerator CambioColor(Image image, Color color)
  {
    Color tempColor = color;
    Color tempTransparent = color;
    tempColor.a = 0.588235294f;
    tempTransparent.a = 0;

    CambioDeColorEjecutando = 1;

    if (state == 0)
      taxiManager.RemoveStudentCounter();
    else if (state == 1)
    {
      taxi.SetActive(true);
      taxiManager.AddStudentCounter();
    }


    image.color = tempColor;
    yield return new WaitForSeconds(0.25f);
    image.color = tempTransparent;
    yield return new WaitForSeconds(0.15f);
    image.color = tempColor;
    yield return new WaitForSeconds(0.15f);
    image.color = tempTransparent;
    yield return new WaitForSeconds(0.15f);
    image.color = tempColor;

    yield return new WaitForSeconds(0.15f);
    if (state == 1)
    {
      taxi.SetActive(false);
      taxiManager.SetNewRound();
    }

    CambioDeColorEjecutando = 0;
  }

}
