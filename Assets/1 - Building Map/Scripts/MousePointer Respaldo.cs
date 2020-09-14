using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class MousePointerRespaldo : MonoBehaviour
{
  public Camera mainCam;

  RaycastHit hit;
  Ray ray;

  public GameObject selectedBuilding;
  GameObject tmpObj;

  public GameObject currentSpawnObject;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    ray = mainCam.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit))
    {
      Debug.DrawRay(ray.origin, ray.direction * 2000, Color.green, 3000, false);
    }

    if (Input.GetMouseButtonDown(0))
    {

      if (selectedBuilding != null && GameSingleton.Instance.money >= selectedBuilding.GetComponent<Building>().cost)
      {
        FindObjectOfType<AudioManager>().Play("Building");
        tmpObj = Instantiate(selectedBuilding);
        tmpObj.transform.position = hit.point;
        Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGenerator>().nearestGridPoint(hit.point);

        tmpObj.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 3, nearestPoint.z), tmpObj.transform.rotation);
        tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
        Debug.Log("Left button clicked");
        tmpObj.GetComponent<Building>().discountCost();
        Destroy(selectedBuilding);
        currentSpawnObject = null;

      }
      else if (selectedBuilding != null && GameSingleton.Instance.money < selectedBuilding.GetComponent<Building>().cost)
      {
        Destroy(selectedBuilding);
        currentSpawnObject = null;
        ShowLowMoneyError();
      }

    }
    else
    {
      if (selectedBuilding != null)
      {
        Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGenerator>().nearestGridPoint(hit.point);
        selectedBuilding.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 3, nearestPoint.z), selectedBuilding.transform.rotation);
        selectedBuilding.GetComponent<MeshRenderer>().material.color = Color.green;
      }
    }
  }

  public void SelectBuilding(GameObject buildingObject)
  {
    if (currentSpawnObject == null || currentSpawnObject.name != buildingObject.name)
    {
      if (selectedBuilding != null)
      {
        Destroy(selectedBuilding);
      }
      currentSpawnObject = buildingObject;
      selectedBuilding = Instantiate(currentSpawnObject);

    }
  }

  public void ShowLowMoneyError()
  {
    GameObject.Find("PanelLowMoneyError").transform.DOScale(new Vector3(1, 1, 1), 0.5f);
  }







}



/*
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePointer : MonoBehaviour
{
  public Camera mainCam;

  RaycastHit hit;
  Ray ray;

  public GameObject selectedBuilding;
  GameObject tmpObj;

  public GameObject currentSpawnObject;

  // Update is called once per frame
  void Update()
  {
    Touch touch = Input.touches[0];

    if (touch.phase == TouchPhase.Began)
    {

      ray = mainCam.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out hit))
      {
        Debug.DrawRay(ray.origin, ray.direction * 2000, Color.green, 3000, false);
      }
    }


    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
    {

      if (selectedBuilding != null && GameSingleton.Instance.money >= selectedBuilding.GetComponent<Building>().cost)
      {
        FindObjectOfType<AudioManager>().Play("Building");
        tmpObj = Instantiate(selectedBuilding);
        tmpObj.transform.position = hit.point;
        Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGenerator>().nearestGridPoint(hit.point);

        tmpObj.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 3, nearestPoint.z), tmpObj.transform.rotation);
        tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
        Debug.Log("Left button clicked");
        tmpObj.GetComponent<Building>().discountCost();
        Destroy(selectedBuilding);
        currentSpawnObject = null;

      }
      else if (selectedBuilding != null && GameSingleton.Instance.money < selectedBuilding.GetComponent<Building>().cost)
      {
        Destroy(selectedBuilding);
        currentSpawnObject = null;
        ShowLowMoneyError();
      }

    }
    else
    {
      if (selectedBuilding != null)
      {
        Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGenerator>().nearestGridPoint(hit.point);
        selectedBuilding.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 3, nearestPoint.z), selectedBuilding.transform.rotation);
        selectedBuilding.GetComponent<MeshRenderer>().material.color = Color.green;
      }
    }
  }

  public void SelectBuilding(GameObject buildingObject)
  {
    if (currentSpawnObject == null || currentSpawnObject.name != buildingObject.name)
    {
      if (selectedBuilding != null)
      {
        Destroy(selectedBuilding);
      }
      currentSpawnObject = buildingObject;
      selectedBuilding = Instantiate(currentSpawnObject);

    }
  }

  public void ShowLowMoneyError()
  {
    GameObject.Find("PanelLowMoneyError").transform.DOScale(new Vector3(1, 1, 1), 0.5f);
  }







}

*/
