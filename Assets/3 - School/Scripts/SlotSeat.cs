using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class SlotSeat : MonoBehaviour
{
  public StudentLocation ubicacionAsiento;
  public int state;
  public int posCorrecta;

  private SchoolManager schoolManager;

  private int CambioDeColorEjecutando = 0;

  private void Start()
  {
    schoolManager = GameObject.Find("SchoolManager").GetComponent<SchoolManager>();
    GetComponent<Button>().onClick.AddListener(ShowState);
  }

  private void Update()
  {
    if (state != 2 && CambioDeColorEjecutando == 0)
    {
      GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

  }


  public void ShowState()
  {
    EnvioDatos envioDatos = schoolManager.GetComponent<EnvioDatos>();

    switch (this.state)
    {
      case 0:
        StartCoroutine(CambioColor(GetComponentInChildren<TextMeshProUGUI>(), Color.red));
        break;
      case 1:
        StartCoroutine(CambioColor(GetComponentInChildren<TextMeshProUGUI>(), Color.green));
        break;
      case 2:
        StartCoroutine(CambioColor(GetComponentInChildren<TextMeshProUGUI>(), Color.yellow));
        break;
      default:
        StartCoroutine(CambioColor(GetComponentInChildren<TextMeshProUGUI>(), Color.white));
        break;
    }

    switch (this.posCorrecta)
    {
      case 0:
        envioDatos.ButtonPressed(gameObject, 273, 27301, this.state);
        break;
      case 1:
        envioDatos.ButtonPressed(gameObject, 273, 27302, this.state);
        break;
      case 2:
        envioDatos.ButtonPressed(gameObject, 273, 27303, this.state);
        break;
      case 3:
        envioDatos.ButtonPressed(gameObject, 273, 27304, this.state);
        break;
    }
  }

  IEnumerator CambioColor(TextMeshProUGUI tmNombre, Color color)
  {
    CambioDeColorEjecutando = 1;
    if (state == 0)
      schoolManager.RemoveStudentCounter();
    else if (state == 1)
      schoolManager.AddStudentCounter();

    tmNombre.color = color;
    yield return new WaitForSeconds(0.25f);
    tmNombre.color = Color.white;
    yield return new WaitForSeconds(0.15f);
    tmNombre.color = color;
    yield return new WaitForSeconds(0.15f);
    tmNombre.color = Color.white;
    yield return new WaitForSeconds(0.15f);
    tmNombre.color = color;

    if (state == 1)
      schoolManager.SetNewRound();
    CambioDeColorEjecutando = 0;
  }

}
