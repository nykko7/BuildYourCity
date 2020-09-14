using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI uiText = default;
    [SerializeField] private float mainTimer = default;

    [SerializeField] private GameObject imagenReloj = default;

    private float timer;
    private bool canCount;
    private bool doOnce;

    void Start()
    {
        IniciarContador();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0.5f && canCount){
            timer -= Time.deltaTime;
            int seconds = Mathf.FloorToInt(timer);
            uiText.text = seconds.ToString("00");
        }

        else if(timer <= 0.0f && !doOnce){
            canCount = false;
            doOnce = true;
            timer = 0.0f;
            uiText.text = "00";            
            imagenReloj.GetComponent<Animator>().enabled = false;
        }
    }

    public void IniciarContador(){
        timer = mainTimer + 1;
        canCount = true;
        doOnce = false;
    }

    public int GetTimer(){
        return Mathf.FloorToInt(timer);
    }

    public void setCanCount(bool canCount){
        this.canCount = canCount;
    }
    
}
