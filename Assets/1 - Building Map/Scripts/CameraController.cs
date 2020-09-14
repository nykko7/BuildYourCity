using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 70f;
    public int padding = 5;


    // Update is called once per frame
    void Update()
    {
        float mousePositionX = Input.mousePosition.x;
        float mousePositionY = Input.mousePosition.y;

        if(mousePositionX < padding){
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
        }

        if(mousePositionX >= Screen.width - padding){
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }

        if(mousePositionY > padding){
            transform.Translate(transform.forward * -scrollSpeed * Time.deltaTime);
        }

        if(mousePositionY <= Screen.height - padding){
            transform.Translate(transform.forward * scrollSpeed * Time.deltaTime);
        }
    }
}
