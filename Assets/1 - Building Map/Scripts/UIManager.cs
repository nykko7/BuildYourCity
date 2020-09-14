using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{


  public void MenuMoveToScreen(GameObject menu)
  {
    menu.transform.DOLocalMoveY(0, 0.5f, false);
  }

  public void MenuExitOfScreen(GameObject menu)
  {
    menu.transform.DOLocalMoveY(-500, 1f, false);
  }

  public void MenuScaleOffScreen(GameObject menu)
  {
    menu.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
  }





  //PANEL DE CONSTRUIR Y ACTIVIDADES:
  public void MenuMoveToScreenX(GameObject menu)
  {
    menu.transform.DOLocalMoveX(260, 0.5f, false);
  }

  public void MenuExitOfScreenX(GameObject menu)
  {
    menu.transform.DOLocalMoveX(-255, 0.5f, false);
  }



  //Instrucciones de Construcción:  
  public void MenuScaleInAndOffScreen(GameObject menu)
  {
    StartCoroutine(ScaleInAndOff(menu));
  }
  IEnumerator ScaleInAndOff(GameObject menu)
  {
    menu.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    yield return new WaitForSeconds(2f);
    menu.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
  }



}
