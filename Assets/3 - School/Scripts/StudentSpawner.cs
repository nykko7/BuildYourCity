using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StudentSpawner : MonoBehaviour
{
  public StudentLocation[] estudiantesPosibles;
  public Sprite[] StudentsSprites;

  public GameObject EstudiantePrefab;

  List<int> asistentesCreados;

  Transform dragParent;

  public TextMeshProUGUI instruccionesAsientoTMProText;
  public TextMeshProUGUI nombreAlumnoActualTMProText;
  public TextMeshProUGUI nombreAlumnoAnteriorTMProText;


  public SchoolManager schoolManager;

  private string nombreAlumnoActual;
  private string nombreAlumnoAnterior;

  void Start()
  {
    dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    asistentesCreados = new List<int>(estudiantesPosibles.Length);
    nombreAlumnoAnterior = "Pedro";
    NuevoEstudiante();
  }

  void Update()
  {

    if (dragParent.childCount == 0 && transform.childCount <= 0 && asistentesCreados.Count < estudiantesPosibles.Length)
    {
      NuevoEstudiante();
    }

    nombreAlumnoActualTMProText.text = nombreAlumnoActual;
    instruccionesAsientoTMProText.text = "a la derecha de";
    nombreAlumnoAnteriorTMProText.text = nombreAlumnoAnterior;
  }

  private void NuevoEstudiante()
  {
    GameObject estudianteNuevo = Instantiate(EstudiantePrefab, transform.position, Quaternion.identity);

    estudianteNuevo.GetComponent<Student>().studentLocation = estudiantesPosibles[EstudianteAlAzar()];
    int indexRandomAssistant = UnityEngine.Random.Range(0, StudentsSprites.Length);
    estudianteNuevo.GetComponentsInChildren<Image>()[1].sprite = StudentsSprites[indexRandomAssistant];

    //estudianteNuevo.GetComponentsInChildren<Text>()[0].color = new Color(255,100,0,255);
    estudianteNuevo.GetComponent<Student>().nombreEstudianteText.color = nombreAlumnoActualTMProText.color;

    estudianteNuevo.transform.SetParent(transform);
    estudianteNuevo.transform.localScale = new Vector3(1, 1, 1);
    estudianteNuevo.GetComponent<Student>().nombreEstudiante = "Lorena";

    //schoolManager.estudianteActual = estudianteNuevo.GetComponent<Student>();
    nombreAlumnoActual = estudianteNuevo.GetComponent<Student>().nombreEstudiante;
  }

  private int EstudianteAlAzar()
  {
    int nroEstudiante;
    //Se genera boleto random, que no haya sido creado antes:
    do
    {
      nroEstudiante = GenerarEstudianteRandom();
    } while (asistentesCreados.Contains(nroEstudiante));

    asistentesCreados.Add(nroEstudiante);
    return nroEstudiante;
  }

  private int GenerarEstudianteRandom()
  {
    var random = UnityEngine.Random.Range(1, estudiantesPosibles.Length + 1);
    return (random - 1);
  }

}
