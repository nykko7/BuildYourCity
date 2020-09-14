using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CinemaManager : MonoBehaviour
{

    /////////DISPLAY SCORE////////
    public EndActivityWindow endActivityWindow;
    public DisplayAsistentes displayAsistentes;
    public DisplayTimer displayTimer;

    /////////COUNTERS/////////////
    public int totalAssistants;
    public int assistantsCount;
    public int timeLeft;

    ///////////VALUES/////////////
    public int assistantValue = 10;
    public int timeLeftValue = 5;

    

    // Start is called before the first frame update
    void Start()
    {
        totalAssistants = 42;
        SetCounters();
        endActivityWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetCounters();
        if (timeLeft <= 0 || assistantsCount >= totalAssistants){            
            endActivityWindow.gameObject.SetActive(true);                                  
        }
    }

    public void SetCounters(){
        assistantsCount = displayAsistentes.GetAsistentes();
        timeLeft = displayTimer.GetTimer();
    }
   

    public void SetPause(){
        displayTimer.setCanCount(false);
    }   

    public void AddMoney(){
        int moneyObtained = assistantsCount*assistantValue + timeLeft*timeLeftValue;
        Debug.Log("Actual Money: $"+GameSingleton.Instance.money);
        GameSingleton.Instance.money += moneyObtained;
        Debug.Log("Money Obtained: $" + moneyObtained);
        Debug.Log("Total Money: $"+ GameSingleton.Instance.money);
    }

    

    public void SendActivityComplete(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, 272, 27243, 1);
    }

    public void SendActivityInComplete(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, 272, 27243, 0);
    }

    
}
