using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName="Nueva Ubicacion Estudiante", menuName="UbicacionEstudiante")]
public class StudentLocation : ScriptableObject
{
   public string fila;
   public string columna;
}
