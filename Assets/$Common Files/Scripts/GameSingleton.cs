using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance { get; private set; }    
       
    public int id_usuario;
    public string id_sesion;

    public int money = 1200;
    public string time;
    
    internal static object instance = default;   

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
