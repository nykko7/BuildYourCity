using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SchoolManagerRespaldo : MonoBehaviour
{
    /////////DISPLAY SCORE////////
    public EndActivityWindow endActivityWindow;
    public DisplayAsistentes displayStudents;
    public DisplayTimer displayTimer;

    /////////COUNTERS/////////////
    public int totalStudents;
    public int studentsCount;
    public int timeLeft;

    ///////////VALUES/////////////
    public int assistantValue = 10;
    public int timeLeftValue = 5;

    ////////STUDENTS_INFO/////////
    public Student estudianteActual;
    public Student estudianteAnterior;

    ////////DRAG_PARENT/////////
    Transform dragParent;
    

    // Start is called before the first frame update
    void Start()
    {
        totalStudents = 21;
        SetCounters();
        endActivityWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetCounters();
        if (timeLeft <= 0 || studentsCount >= totalStudents){            
            endActivityWindow.gameObject.SetActive(true);                                  
        }
    }

    public void SetCounters(){
        studentsCount = displayStudents.GetStudents();
        timeLeft = displayTimer.GetTimer();
    }
   

    public void SetPause(){
        displayTimer.setCanCount(false);
    }   

    public void AddMoney(){
        int moneyObtained = studentsCount*assistantValue + timeLeft*timeLeftValue;
        Debug.Log("Actual Money: $"+GameSingleton.Instance.money);
        GameSingleton.Instance.money += moneyObtained;
        Debug.Log("Money Obtained: $" + moneyObtained);
        Debug.Log("Total Money: $"+ GameSingleton.Instance.money);
    }

    public void SendStudentsCounter(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, 2702, 270202, studentsCount);
    }

    public void SendActivityComplete(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, 2702, 270203, 1);
    }

    public void SendActivityInComplete(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, 2702, 270203, 0);
    }

    
}
