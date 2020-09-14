using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAsistentes : MonoBehaviour
{
    int asistentes = 0;
    TextMeshProUGUI AsistentesText;
    void Start()
    {
        AsistentesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay(){
        AsistentesText.text = asistentes.ToString("00");
    }

    public void AgregarAsistente(){
        asistentes += 1;
        UpdateDisplay();
    }

    public int GetAsistentes(){
        return asistentes;
    }

    public void AgregarEstudiante(){
        asistentes += 1;
        UpdateDisplay();
    }

    public int GetStudents(){
        return asistentes;
    }

}
