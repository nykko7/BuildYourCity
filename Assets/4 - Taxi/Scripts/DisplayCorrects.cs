using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCorrects : MonoBehaviour
{
  int corrects = 0;
  TextMeshProUGUI BlockCorrectsCounterText;
  void Start()
  {
    BlockCorrectsCounterText = GetComponent<TextMeshProUGUI>();
    UpdateDisplay();
  }

  private void UpdateDisplay()
  {
    BlockCorrectsCounterText.text = corrects.ToString("00");
  }

  public void AddCorrect()
  {
    corrects += 1;
    UpdateDisplay();
  }

  public void RemoveCorrect()
  {
    if (corrects >= 1)
    {
      corrects -= 1;
    }

    UpdateDisplay();
  }

  public int Getcorrects()
  {
    return corrects;
  }

}
