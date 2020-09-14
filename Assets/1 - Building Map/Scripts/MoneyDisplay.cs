using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class MoneyDisplay : MonoBehaviour
{
  public TextMeshProUGUI tmText;
  CultureInfo ci;
  // Start is called before the first frame update
  void Start()
  {
    tmText = GetComponent<TextMeshProUGUI>();
    ci = new CultureInfo("de-DE");
    tmText.text = GameSingleton.Instance.money.ToString("N0", ci);
  }

  // Update is called once per frame
  void Update()
  {

    tmText.text = GameSingleton.Instance.money.ToString("N0", ci);
  }
}
