using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class LoadingText : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public string[] loadingTexts;
    public float period = 0.0f;
    public int contador = 0;

    void Start()
    {
        loadingText = GetComponent<TextMeshProUGUI>();
        loadingTexts = new string[] {"Cargando", "Cargando.", "Cargando..", "Cargando..."};
    }

    void Update()
    {
        if (period > 0.3f)
        {            
            loadingText.text = loadingTexts[contador];
            period = 0;
            contador++;
        }
        period += Time.deltaTime;
        if(contador > 3){
            contador = 0;
        }
    }
    
}



 