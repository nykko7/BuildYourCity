using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class EndActivityWindow : MonoBehaviour
{
  public TextMeshProUGUI assistantCountDisplay;
  public TextMeshProUGUI timerLeftDisplay;

  public TextMeshProUGUI assistantValueDisplay;
  public TextMeshProUGUI timerLeftValueDisplay;

  public TextMeshProUGUI assistantMoneyDisplay;
  public TextMeshProUGUI timerLeftMoneyDisplay;

  public TextMeshProUGUI totalMoneyDisplay;

  private GameObject endActivityMessage;

  public CinemaManager cinemaManager = default;
  public int totalAssistants;



  private void Awake()
  {
    cinemaManager = GameObject.FindGameObjectWithTag("CinemaManager").GetComponent<CinemaManager>();
    endActivityMessage = GameObject.FindGameObjectWithTag("EndActivityMessage");

    totalAssistants = GameObject.FindGameObjectWithTag("CinemaManager").GetComponent<CinemaManager>().totalAssistants;
  }

  // Start is called before the first frame update
  private void OnEnable()
  {
    cinemaManager.SetPause();

    Sequence sequenceEndMessage = DOTween.Sequence();

    if (cinemaManager.assistantsCount >= totalAssistants)
    {
      endActivityMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Excelente! Haz llenado la sala.";
      sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.one, 1f));
      sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.zero, .5f).SetDelay(1f));

    }
    else
    {
      endActivityMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Actividad Finalizada";
      sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.one, 1f));
      sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.zero, .5f).SetDelay(1f));
    }

    transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetDelay(2f);

  }



  private void Update()
  {
    assistantCountDisplay.text = cinemaManager.assistantsCount.ToString("D2");
    timerLeftDisplay.text = cinemaManager.timeLeft.ToString("D2");
    assistantValueDisplay.text = cinemaManager.assistantValue.ToString("D2");
    timerLeftValueDisplay.text = cinemaManager.timeLeftValue.ToString("D2");
    assistantMoneyDisplay.text = (cinemaManager.assistantsCount * cinemaManager.assistantValue).ToString("D2");
    timerLeftMoneyDisplay.text = (cinemaManager.timeLeft * cinemaManager.timeLeftValue).ToString("D2");
    totalMoneyDisplay.text = (cinemaManager.assistantsCount * cinemaManager.assistantValue + cinemaManager.timeLeft * cinemaManager.timeLeftValue).ToString("D2");

  }

}
