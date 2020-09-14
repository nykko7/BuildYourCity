using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TaxiManager : MonoBehaviour
{
  /////////DISPLAY SCORE////////
  public EndActivityWindowTaxi endActivityWindow;
  public DisplayCorrects displayCorrects;
  public DisplayTimer displayTimer;

  //////DISPLAY INSTRUCTIONS////
  public TextMeshProUGUI direccionReferenciaTMProText;

  /////////COUNTERS/////////////
  public int correctsCount;
  public int timeLeft;

  ///////////VALUES/////////////
  public int correctValue;
  public int timeLeftValue;

  ////////BLOCKS_INFO///////////
  private GameObject[] blocks;
  private GameObject blockEnJuegoAnterior;
  private string referenciaFila;
  private int referenciaColumna;



  ////////DRAG_PARENT/////////
  Transform dragParent;


  // Start is called before the first frame update
  void Start()
  {
    correctValue = 20;
    timeLeftValue = 5;

    blocks = GameObject.FindGameObjectsWithTag("Block");
    blockEnJuegoAnterior = default;

    SetCounters();
    endActivityWindow.gameObject.SetActive(false);
    SetNewRound();
  }

  public void SetNewRound()
  {
    GameObject randomBlock = SelectRandomBlock();
    ShowReferenceBlock(randomBlock);
  }

  public GameObject SelectRandomBlock()
  {
    GameObject randomBlock;
    string referenciaFila;
    int referenciaColumna;

    do
    {
      randomBlock = this.RandomBlock();
      referenciaFila = randomBlock.GetComponent<SlotBlock>().ubicacionBlock.fila;
      referenciaColumna = int.Parse(randomBlock.GetComponent<SlotBlock>().ubicacionBlock.columna);
    } while (blockEnJuegoAnterior == randomBlock);

    blockEnJuegoAnterior = randomBlock;
    return randomBlock;
  }

  private void ShowReferenceBlock(GameObject blockReferencia)
  {
    referenciaFila = blockReferencia.GetComponent<SlotBlock>().ubicacionBlock.fila;
    referenciaColumna = int.Parse(blockReferencia.GetComponent<SlotBlock>().ubicacionBlock.columna);
    direccionReferenciaTMProText.text = GetDirectionFromUbication(referenciaFila, referenciaColumna);
    string direccion = GetDirectionFromUbication(referenciaFila, referenciaColumna);
    SetBlocks(blockReferencia, direccion);

  }

  public GameObject RandomBlock()
  {
    var randomIndex = UnityEngine.Random.Range(1, blocks.Length + 1) - 1;
    GameObject randomBlock = blocks[randomIndex];
    return randomBlock;
  }

  public void SetBlocks(GameObject blockReferencia, string direccion)
  {
    foreach (GameObject block in blocks)
    {
      SlotBlock slot = block.GetComponent<SlotBlock>();
      if (block == blockReferencia)
      {
        slot.state = 1;
      }
      else
      {
        slot.state = 0;
      }

      if (direccion == "Noroeste")
      {
        slot.posCorrecta = 0;
      }
      else if (direccion == "Norte")
      {
        slot.posCorrecta = 1;
      }
      else if (direccion == "Noreste")
      {
        slot.posCorrecta = 2;
      }
      else if (direccion == "Oeste")
      {
        slot.posCorrecta = 3;
      }
      else if (direccion == "Este")
      {
        slot.posCorrecta = 4;
      }
      else if (direccion == "Suroeste")
      {
        slot.posCorrecta = 5;
      }
      else if (direccion == "Sureste")
      {
        slot.posCorrecta = 7;
      }
      else
      {
        slot.posCorrecta = 6;
      }
    }
  }

  public string GetDirectionFromUbication(string fila, int columna)
  {
    if (fila == "A" && columna == 1)
      return "Noroeste";
    else if (fila == "A" && columna == 2)
      return "Norte";
    else if (fila == "A" && columna == 3)
      return "Noreste";
    else if (fila == "B" && columna == 1)
      return "Oeste";
    else if (fila == "B" && columna == 3)
      return "Este";
    else if (fila == "C" && columna == 1)
      return "Suroeste";
    else if (fila == "C" && columna == 2)
      return "Sur";
    else
      return "Sureste";
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
    correctsCount = displayCorrects.Getcorrects();
    timeLeft = displayTimer.GetTimer();
  }

  public void AddStudentCounter()
  {
    FindObjectOfType<AudioManager>().Play("GoodMove");
    displayCorrects.AddCorrect();
  }
  public void RemoveStudentCounter()
  {
    FindObjectOfType<AudioManager>().Play("BadMove");
    displayCorrects.RemoveCorrect();
  }

  public void SetPause()
  {
    displayTimer.setCanCount(false);
  }

  public void AddMoney()
  {
    int moneyObtained = correctsCount * correctValue;
    Debug.Log("Actual Money: $" + GameSingleton.Instance.money);
    GameSingleton.Instance.money += moneyObtained;
    Debug.Log("Money Obtained: $" + moneyObtained);
    Debug.Log("Total Money: $" + GameSingleton.Instance.money);
  }

  public void SendActivityComplete()
  {
    EnvioDatos envioDatos = GetComponent<EnvioDatos>();
    envioDatos.ButtonPressed(gameObject, 274, 27409, 1);
  }

  public void SendActivityInComplete()
  {
    EnvioDatos envioDatos = GetComponent<EnvioDatos>();
    envioDatos.ButtonPressed(gameObject, 274, 27409, 0);
  }







}
