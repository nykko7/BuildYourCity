using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Student : MonoBehaviour
{
    public StudentLocation studentLocation;
    public string nombreEstudiante;
    public TextMeshProUGUI nombreEstudianteText;   

    

    void Update()
    {
        nombreEstudianteText.text = nombreEstudiante;
    }

    
    
}
