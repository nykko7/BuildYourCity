using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjecucionBotones : MonoBehaviour
{
    GameObject buttonSlots;
    GameObject taxiObject;
    

    //TAXI:
    public Vector3 distanceRight = new Vector3(0.65f, 0f, 0f);
    public Vector3 distanceDown = new Vector3(0f, -0.65f, 0f);
    public Vector3 distanceUp = new Vector3(0f, 0.65f, 0f);
    public Vector3 distanceLeft = new Vector3(-0.65f, 0f, 0f);
    public float speed = 1f;
    //


    void Start()
    {
        buttonSlots = GameObject.FindGameObjectWithTag("ButtonSlots");
        taxiObject = GameObject.FindGameObjectWithTag("Taxi");
    }

    public void clickPlayButton(){
        StartCoroutine(EjecutarBotones());
    }

    public IEnumerator EjecutarBotones(){
        for (int i = 0; i < buttonSlots.transform.childCount; i++)
        {           
            if(buttonSlots.transform.GetChild(i).transform.childCount > 0){
                EjecutarBoton(buttonSlots.transform.GetChild(i).transform.GetChild(0).gameObject);
                yield return new WaitForSeconds(1.5f);
                Destroy(buttonSlots.transform.GetChild(i).transform.GetChild(0).gameObject);               
            }
        }
    }

    public void LimpiarBotones(){
        for (int i = 0; i < buttonSlots.transform.childCount; i++)
        {
            if(buttonSlots.transform.GetChild(i).transform.childCount > 0){
                Destroy(buttonSlots.transform.GetChild(i).transform.GetChild(0).gameObject);
            }
        }
    }

    

    private void EjecutarBoton(GameObject gameObj){
        string direccion = gameObj.GetComponent<DragHandlerTaxi>().direccion;
        switch (direccion)
        {
            case "up": 
                taxiObject.transform.GetChild(0).transform.Rotate(new Vector3 (0f,0f,1f), 90f);
                MoveToUp();
                break;
            case "down": 
                taxiObject.transform.GetChild(0).transform.Rotate(new Vector3 (0f,0f,1f), -90f);
                MoveToDown();
                break;
            case "left": 
                taxiObject.transform.GetChild(0).transform.Rotate(new Vector3 (0f,0f,1f), 180f);
                MoveToLeft();
                break;
            case "right": 
                taxiObject.transform.GetChild(0).transform.Rotate(new Vector3 (0f,0f,1f), 0f);
                MoveToRight();              
                break;
        }
        

    }

    public void MoveToRight(){
        StartCoroutine(taxiObject.GetComponent<Taxi>().MoveTo(taxiObject.transform, taxiObject.transform.position + distanceRight, speed));
    }   

    public void MoveToLeft(){
        StartCoroutine(taxiObject.GetComponent<Taxi>().MoveTo(taxiObject.transform, taxiObject.transform.position + distanceLeft, speed));
    }

    public void MoveToDown(){
        StartCoroutine(taxiObject.GetComponent<Taxi>().MoveTo(taxiObject.transform, taxiObject.transform.position + distanceDown, speed));
    }

    public void MoveToUp(){
        StartCoroutine(taxiObject.GetComponent<Taxi>().MoveTo(taxiObject.transform, taxiObject.transform.position + distanceUp, speed));
    }

    
}
