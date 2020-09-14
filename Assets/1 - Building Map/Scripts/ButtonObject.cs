using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ButtonObject : MonoBehaviour
{
    public int idActividad;
    public int idElemento;
    public int esCorrecta;

    private void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(enviarDatos);
    }
    

    public void enviarDatos(){
        EnvioDatos envioDatos = GetComponent<EnvioDatos>();
        envioDatos.ButtonPressed(gameObject, this.idActividad, this.idElemento, this.esCorrecta);
    }



}
