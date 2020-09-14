using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingButtonsController : MonoBehaviour
{
  public GameObject building;

  // Start is called before the first frame update
  void Start()
  {
    GetComponentInChildren<TextMeshProUGUI>().text = '$' + building.GetComponent<Building>().cost.ToString();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
