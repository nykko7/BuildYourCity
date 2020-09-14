using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAyuda : MonoBehaviour
{
  public GameObject rosaDeLosVientos;

  public void activarRosa()
  {
    StartCoroutine(delay());
  }


  public IEnumerator delay()
  {
    rosaDeLosVientos.SetActive(true);
    yield return new WaitForSeconds(2);
    rosaDeLosVientos.SetActive(false);
  }
}
