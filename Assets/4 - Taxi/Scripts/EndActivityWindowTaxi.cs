using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class EndActivityWindowTaxi : MonoBehaviour
{
  public TextMeshProUGUI correctsCountDisplay;

  public TextMeshProUGUI correctsValueDisplay;

  public TextMeshProUGUI correctsMoneyDisplay;

  public TextMeshProUGUI totalMoneyDisplay;

  private GameObject endActivityMessage;

  public TaxiManager taxiManager = default;




  private void Awake()
  {
    taxiManager = GameObject.FindGameObjectWithTag("TaxiManager").GetComponent<TaxiManager>();
    endActivityMessage = GameObject.FindGameObjectWithTag("EndActivityMessage");

  }

  // Start is called before the first frame update
  private void OnEnable()
  {
    taxiManager.SetPause();

    Sequence sequenceEndMessage = DOTween.Sequence();


    endActivityMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Actividad Finalizada";
    sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.one, 1f));
    sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.zero, .5f).SetDelay(1f));


    transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetDelay(2f);

  }



  private void Update()
  {
    correctsCountDisplay.text = taxiManager.correctsCount.ToString("D2");
    correctsValueDisplay.text = taxiManager.correctValue.ToString("D2");
    correctsMoneyDisplay.text = (taxiManager.correctsCount * taxiManager.correctValue).ToString("D2");
    totalMoneyDisplay.text = (taxiManager.correctsCount * taxiManager.correctValue).ToString("D2");

  }

}
