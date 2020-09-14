using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Nueva Ubicacion Cuadra", menuName = "UbicacionCuadra")]
public class BlockLocation : ScriptableObject
{
  public string fila;
  public string columna;
}
