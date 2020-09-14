using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SchoolManager : MonoBehaviour
{
  /////////DISPLAY SCORE////////
  public EndActivityWindowSchool endActivityWindow;
  public DisplayStudents displayStudents;
  public DisplayTimer displayTimer;

  //////DISPLAY INSTRUCTIONS////
  public TextMeshProUGUI instruccionesAsientoTMProText;
  public TextMeshProUGUI nombreAlumnoReferenciaTMProText;


  /////////COUNTERS/////////////
  public int totalStudents;
  public int studentsCount;
  public int timeLeft;

  ///////////VALUES/////////////
  public int assistantValue = 10;
  public int timeLeftValue = 5;

  ////////STUDENTS_INFO/////////
  List<int> nombresUsados;
  public GameObject EstudiantePrefab;
  public Sprite[] StudentsSprites;
  private GameObject[] asientos;
  private string[] nombresPosibles;
  private GameObject asientoReferencia;
  private GameObject asientoConsultado;
  private string referenciaFila;
  private int referenciaColumna;
  private string targetFila;
  private int targetColumna;


  ////////DRAG_PARENT/////////
  Transform dragParent;


  // Start is called before the first frame update
  void Start()
  {
    asientos = GameObject.FindGameObjectsWithTag("Asiento");
    totalStudents = 16;

    //AUXILIARES PARA NOMBRE DE ESTUDIANTES:
    nombresPosibles = new string[] { "Laura", "Juan", "Pedro", "Lucas", "Omar", "María", "Raúl", "Hugo", "Luis", "Jose", "Inés", "Sofía", "Gema", "Elsa", "Sara", "Paúl" };

    SetCounters();
    endActivityWindow.gameObject.SetActive(false);
    SetNewRound();

  }

  public void SetNewRound()
  {
    SetStudents();
    ChooseRandomStudent();
  }


  private void SetStudents()
  {
    nombresUsados = new List<int>(nombresPosibles.Length);
    string nombreEstudiante;

    if (GameObject.FindGameObjectsWithTag("Estudiante").Length > 0)
    {
      for (int i = 0; i < asientos.Length; i++)
      {
        Student estudiante = asientos[i].GetComponentInChildren<Student>();
        nombreEstudiante = nombresPosibles[EstudianteAlAzar()];
        estudiante.nombreEstudiante = nombreEstudiante;
      }
    }
    else
    {
      for (int i = 0; i < asientos.Length; i++)
      {
        GameObject estudiante = Instantiate(EstudiantePrefab, transform.position, Quaternion.identity);
        estudiante.GetComponentsInChildren<Image>()[1].sprite = StudentsSprites[i];
        estudiante.transform.SetParent(asientos[i].transform);
        estudiante.transform.localScale = new Vector3(1, 1, 1);
        estudiante.transform.localPosition = Vector3.zero;
        nombreEstudiante = nombresPosibles[EstudianteAlAzar()];
        estudiante.GetComponent<Student>().nombreEstudiante = nombreEstudiante;

      }
    }

  }

  private void ChooseRandomStudent()
  {
    asientoReferencia = SelectRandomStudent();
    Debug.Log(asientoReferencia.GetComponentInChildren<Student>().nombreEstudiante);
    ShowReferenceStundent(asientoReferencia);
    ShowTargetStudent(asientoReferencia);

    // Debug.Log(asientoReferencia.GetComponentInChildren<Student>().nombreEstudiante);
    // Debug.Log(asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.fila + asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.columna);
  }

  public GameObject SelectRandomStudent()
  {
    var random = UnityEngine.Random.Range(1, asientos.Length + 1) - 1;
    return asientos[random];
  }

  private void ShowTargetStudent(GameObject asientoReferencia)
  {

    SelectTargetStudent(asientoReferencia);
    if ((int)targetFila.ToCharArray()[0] < (int)referenciaFila.ToCharArray()[0])
    {
      instruccionesAsientoTMProText.text = "adelante de";
    }
    else if ((int)targetFila.ToCharArray()[0] > (int)referenciaFila.ToCharArray()[0])
    {
      instruccionesAsientoTMProText.text = "atras de";
    }
    else if (targetColumna < referenciaColumna)
    {
      instruccionesAsientoTMProText.text = "a la izquierda de";
    }
    else
    {
      instruccionesAsientoTMProText.text = "a la derecha de";
    }

    foreach (GameObject asiento in asientos)
    {
      SlotSeat slot = asiento.GetComponent<SlotSeat>();
      if (slot.ubicacionAsiento.fila == targetFila && slot.ubicacionAsiento.columna == targetColumna.ToString())
      {
        slot.state = 1;
      }
      else if (slot.ubicacionAsiento.fila == referenciaFila && slot.ubicacionAsiento.columna == referenciaColumna.ToString())
      {
        slot.state = 2;
      }
      else
      {
        slot.state = 0;
      }

      if ((int)targetFila.ToCharArray()[0] < (int)referenciaFila.ToCharArray()[0])
      {
        slot.posCorrecta = 0;
      }
      else if ((int)targetFila.ToCharArray()[0] > (int)referenciaFila.ToCharArray()[0])
      {
        slot.posCorrecta = 1;
      }
      else if (targetColumna < referenciaColumna)
      {
        slot.posCorrecta = 2;
      }
      else
      {
        slot.posCorrecta = 3;
      }
    }
  }

  private void ShowReferenceStundent(GameObject asientoReferencia)
  {
    Debug.Log(asientoReferencia.GetComponentInChildren<Student>().nombreEstudiante);
    Debug.Log(asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.fila + asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.columna);
    nombreAlumnoReferenciaTMProText.text = asientoReferencia.GetComponentInChildren<Student>().nombreEstudiante + "?";
    asientoReferencia.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
    referenciaFila = asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.fila;
    referenciaColumna = int.Parse(asientoReferencia.GetComponent<SlotSeat>().ubicacionAsiento.columna);
  }



  private void SelectTargetStudent(GameObject asientoReferencia)
  {

    string[] FilasPosibles = new string[] { "A", "B", "C", "D" };
    int[] ColumnasPosibles = new int[] { 1, 2, 3, 4 };

    switch (referenciaFila)
    {
      case "A":
        FilasPosibles = new string[] { "B" };
        break;
      case "B":
        FilasPosibles = new string[] { "A", "C" };
        break;
      case "C":
        FilasPosibles = new string[] { "B", "D" };
        break;
      case "D":
        FilasPosibles = new string[] { "C" };
        break;
    }

    switch (referenciaColumna)
    {
      case 1:
        ColumnasPosibles = new int[] { 1 };
        break;
      case 2:
        ColumnasPosibles = new int[] { -1, 1 };
        break;
      case 3:
        ColumnasPosibles = new int[] { -1, 1 };
        break;
      case 4:
        ColumnasPosibles = new int[] { -1 };
        break;
    }

    if (UnityEngine.Random.value < 0.5f)
    {
      if (FilasPosibles.Length == 1)
        targetFila = FilasPosibles[0];
      else
        targetFila = FilasPosibles[UnityEngine.Random.Range(0, 1)];
      targetColumna = referenciaColumna;
    }
    else
    {
      targetFila = referenciaFila;
      if (ColumnasPosibles.Length == 1)
        targetColumna = referenciaColumna + ColumnasPosibles[0];
      else
        targetColumna = referenciaColumna + ColumnasPosibles[UnityEngine.Random.Range(0, 1)];
    }

  }

  private int EstudianteAlAzar()
  {
    int nroEstudiante;
    //Se genera boleto random, que no haya sido creado antes:
    do
    {
      nroEstudiante = GenerarEstudianteRandom();
    } while (nombresUsados.Contains(nroEstudiante));

    nombresUsados.Add(nroEstudiante);
    return nroEstudiante;
  }

  private int GenerarEstudianteRandom()
  {
    var random = UnityEngine.Random.Range(1, nombresPosibles.Length + 1);
    return (random - 1);
  }


  // Update is called once per frame
  void Update()
  {
    SetCounters();
    if (timeLeft <= 0)
    {
      endActivityWindow.gameObject.SetActive(true);
    }
  }

  public void SetCounters()
  {
    studentsCount = displayStudents.GetStudents();
    timeLeft = displayTimer.GetTimer();
  }

  public void AddStudentCounter()
  {
    FindObjectOfType<AudioManager>().Play("GoodMove");
    displayStudents.AddStudent();
  }
  public void RemoveStudentCounter()
  {
    FindObjectOfType<AudioManager>().Play("BadMove");
    displayStudents.RemoveStudent();
  }

  public void SetPause()
  {
    displayTimer.setCanCount(false);
  }

  public void AddMoney()
  {
    int moneyObtained = studentsCount * assistantValue;
    Debug.Log("Actual Money: $" + GameSingleton.Instance.money);
    GameSingleton.Instance.money += moneyObtained;
    Debug.Log("Money Obtained: $" + moneyObtained);
    Debug.Log("Total Money: $" + GameSingleton.Instance.money);
  }

  public void SendActivityComplete()
  {
    EnvioDatos envioDatos = GetComponent<EnvioDatos>();
    envioDatos.ButtonPressed(gameObject, 273, 27305, 1);
  }

  public void SendActivityInComplete()
  {
    EnvioDatos envioDatos = GetComponent<EnvioDatos>();
    envioDatos.ButtonPressed(gameObject, 273, 27305, 0);
  }







}
