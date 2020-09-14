using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IDropHandler
{
    public Boleto asiento;
    public GameObject asistenteSentado;
    public bool asientoDisponible;

    public Sprite sentadoSprite;
    // Start is called before the first frame update
    void Start()
    {
        asientoDisponible = true;
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject asistenteArrastrado = DragHandler.itemDragging;    
        
        if (!asistenteArrastrado) return;
        
        Boleto asientoAsistente = asistenteArrastrado.GetComponent<Asistente>().boleto;
        string asientoAsistenteText = asientoAsistente.fila+asientoAsistente.columna;    
        

        if(asientoDisponible && VerificarAsiento(asiento.fila+asiento.columna, asientoAsistenteText)){
            asientoDisponible = false;
            asistenteSentado = asistenteArrastrado;
            asistenteSentado.transform.SetParent(transform);
            asistenteSentado.transform.position = transform.position;
            asistenteSentado.GetComponentsInChildren<Image>()[2].color = new Color32(0,0,0,0);
            asistenteSentado.GetComponentsInChildren<Image>()[1].transform.Rotate(new Vector3(0,0,90));
            
           
            
            asistenteSentado.GetComponentInChildren<Text>().color = new Color32(0,0,0,0);
            gameObject.GetComponent<Image>().sprite = sentadoSprite;          
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);                 
        }else{
            StartCoroutine(CambioColor());            
        }

    }

   
    // Update is called once per frame
    void Update()
    {
        if(asistenteSentado != null && asistenteSentado.transform.parent != transform){
            asistenteSentado = null;
            asientoDisponible = true;
        }
    }

    public bool VerificarAsiento(string asiento1, string asiento2){
        if(string.Compare(asiento1,asiento2)==0){
            return true;
        }else{
            return false;
        }
    }

    IEnumerator CambioColor(){
        gameObject.GetComponent<Image>().color =  new Color32(28, 28, 28, 255);
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<Image>().color =  new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<Image>().color =  new Color32(28, 28, 28, 255);
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<Image>().color =  new Color32(255, 255, 255, 255);
    }
}
