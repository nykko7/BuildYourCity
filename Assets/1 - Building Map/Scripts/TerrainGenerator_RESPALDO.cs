using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator_RESPALDO : MonoBehaviour
{
  Mesh mesh;
  Vector3[] points;
  int[] triangles;
  public int xBlocks = 30;
  public int zBlocks = 30;

  public float y;

  [Range(0.1f, 10.0f)]
  public float xOffset = 0.5f;
  [Range(0.1f, 10.0f)]
  public float zOffset = 0.5f;
  [Range(0.1f, 10.0f)]
  public float yOffset = 1.5f;

  public int numberOfTrees;
  public GameObject tree;

  // Start is called before the first frame update
  void Start()
  {
    mesh = new Mesh();
    GetComponent<MeshFilter>().mesh = mesh;
    CreateTerrainGeometry();
    UpdateMesh();
    GenerateTrees();
  }

  void FixedUpdate()
  {
    CreateTerrainGeometry();
    UpdateMesh();
  }

  void CreateTerrainGeometry()
  {
    points = new Vector3[(xBlocks + 1) * (zBlocks + 1)];
    int i = 0;
    for (int z = 0; z <= zBlocks; z++)
    {
      for (int x = 0; x <= xBlocks; x++)
      {
        y = Mathf.PerlinNoise(x * xOffset, z * zOffset) * yOffset;
        points[i] = new Vector3(x * 2, y, z * 2);
        i++;
      }
    }

    triangles = new int[xBlocks * zBlocks * 6];

    int vertex = 0;
    int triangleCount = 0;

    for (int z = 0; z < zBlocks; z++)
    {
      for (int x = 0; x < xBlocks; x++)
      {
        triangles[0 + triangleCount] = vertex;
        triangles[1 + triangleCount] = vertex + xBlocks + 1;
        triangles[2 + triangleCount] = vertex + 1;
        triangles[3 + triangleCount] = vertex + 1;
        triangles[4 + triangleCount] = vertex + xBlocks + 1;
        triangles[5 + triangleCount] = vertex + xBlocks + 2;

        vertex++;
        triangleCount += 6;
      }
      vertex++;
    }
  }

  void UpdateMesh()
  {
    mesh.Clear();
    mesh.vertices = points;
    mesh.triangles = triangles;
    GetComponent<MeshCollider>().sharedMesh = mesh;
    mesh.RecalculateNormals();
  }

  void OnDrawGizmos()
  {
    if (points == null) return;

    for (int i = 0; i < points.Length; i++)
    {
      Gizmos.DrawSphere(points[i], 0.5f);
    }
  }

  public Vector3 GetRandomPoint()
  {
    return points[Random.Range(0, xBlocks * zBlocks)];
  }

  public Vector3 nearestGridPoint(Vector3 point)
  {
    int xPoint = (int)Mathf.Floor(point.x);
    int zPoint = (int)Mathf.Floor(point.z);
    return new Vector3(xPoint, 1, zPoint);
  }

  public void GenerateTrees()
  {
    if (tree == null)
    {
      return;
    }
    else
    {
      GameObject tmpGameobject;
      Vector3 spawnPoint;

      for (int i = 0; i < numberOfTrees; i++)
      {
        tmpGameobject = Instantiate(tree);

        spawnPoint = nearestGridPoint(GetRandomPoint());
        spawnPoint.y = 1.23f;

        tmpGameobject.transform.position = spawnPoint;
      }
    }
  }

}
