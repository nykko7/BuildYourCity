using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
  public int cost;
  public bool enTerreno = false;

  public void discountCost()
  {
    GameSingleton.Instance.money -= cost;
    Debug.Log("Cost: $" + cost + " - Total Money: $" + GameSingleton.Instance.money + ".");
  }

  private void OnMouseDown()
  {

    if (enTerreno)
    {
      FindObjectOfType<AudioManager>().Play("Building");
      transform.Rotate(new Vector3(0, 90, 0));
    }


  }



}
