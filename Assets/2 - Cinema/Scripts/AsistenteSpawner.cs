using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AsistenteSpawner : MonoBehaviour
{
    public Boleto[] boletosDeAsientos;
    public Sprite[] AssistantsSprites;

    public GameObject AsistentePrefab;
    
    List<int> asistentesCreados;

    Transform dragParent;

    
    
    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
        asistentesCreados =  new List<int>(boletosDeAsientos.Length);    
        for (int i = 0; i < 7; i++)
        {
            NuevoAsistente();
        }
    }

    void Update(){
        if(dragParent.childCount == 0 && transform.childCount <= 6 && asistentesCreados.Count < boletosDeAsientos.Length){
            NuevoAsistente();
        }
    }

    private void NuevoAsistente(){
        GameObject asistenteNuevo = Instantiate(AsistentePrefab, transform.position, Quaternion.identity);
        
        asistenteNuevo.GetComponent<Asistente>().boleto = boletosDeAsientos[NuevoBoleto()];
        int indexRandomAssistant = UnityEngine.Random.Range(0, AssistantsSprites.Length);
        asistenteNuevo.GetComponentsInChildren<Image>()[1].sprite = AssistantsSprites[indexRandomAssistant];
        asistenteNuevo.transform.SetParent(transform);
        asistenteNuevo.transform.localScale = new Vector3(1,1,1);
        
    }
    private int NuevoBoleto()
    {        
        int nroBoleto;
        //Se genera boleto random, que no haya sido creado antes:
        do{
            nroBoleto = GenerarBoletoRandom();
        }while(asistentesCreados.Contains(nroBoleto));

        asistentesCreados.Add(nroBoleto);     
        return nroBoleto;  
    }

    private int GenerarBoletoRandom(){
        var random = UnityEngine.Random.Range(1,boletosDeAsientos.Length+1);
        return (random - 1);        
    }

}
