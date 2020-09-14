using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

  public Vector3 nearestGridPoint(Vector3 point)
  {
    int xPoint = (int)Mathf.Floor(point.x);
    int zPoint = (int)Mathf.Floor(point.z);
    return new Vector3(xPoint, 1, zPoint);
  }



}
