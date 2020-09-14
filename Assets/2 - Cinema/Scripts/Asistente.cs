using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asistente : MonoBehaviour
{
    public Boleto boleto;
    public Text entrada;

    void Start()
    {
        entrada.text = boleto.fila + boleto.columna;
    }

    
}
