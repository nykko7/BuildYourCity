using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class EndActivityWindowSchool : MonoBehaviour
{
  public TextMeshProUGUI studentCountDisplay;

  public TextMeshProUGUI studentValueDisplay;

  public TextMeshProUGUI studentMoneyDisplay;

  public TextMeshProUGUI totalMoneyDisplay;

  private GameObject endActivityMessage;

  public SchoolManager schoolManager = default;
  public int totalStudents;



  private void Awake()
  {
    schoolManager = GameObject.FindGameObjectWithTag("SchoolManager").GetComponent<SchoolManager>();
    endActivityMessage = GameObject.FindGameObjectWithTag("EndActivityMessage");

    totalStudents = schoolManager.totalStudents;
  }

  // Start is called before the first frame update
  private void OnEnable()
  {
    schoolManager.SetPause();

    Sequence sequenceEndMessage = DOTween.Sequence();


    endActivityMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Actividad Finalizada";
    sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.one, 1f));
    sequenceEndMessage.Append(endActivityMessage.transform.DOScale(Vector3.zero, .5f).SetDelay(1f));


    transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetDelay(2f);

  }



  private void Update()
  {
    studentCountDisplay.text = schoolManager.studentsCount.ToString("D2");
    studentValueDisplay.text = schoolManager.assistantValue.ToString("D2");
    studentMoneyDisplay.text = (schoolManager.studentsCount * schoolManager.assistantValue).ToString("D2");
    totalMoneyDisplay.text = (schoolManager.studentsCount * schoolManager.assistantValue).ToString("D2");

  }

}
