using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName="Nuevo Boleto", menuName="Boleto")]
public class Boleto : ScriptableObject
{
   public string fila;
   public string columna;
}
