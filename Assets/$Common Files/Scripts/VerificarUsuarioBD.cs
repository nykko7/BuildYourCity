using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class VerificarUsuarioBD : MonoBehaviour
{
    /// PERIODO OBTENIDO EN BRUTO:
    string id_periodo;
    /// ID REIM EN BRUTO:
    string id_reim;
    /// 

    public TMP_InputField userInput;
    public TMP_InputField passwordInput;
    public TMP_Text usuarioPassFail;
    bool activador;

    public static int idUsuario;
    public static string usuario_nombre;
    public static int idSesion;
    public static string id_sesion;
    public static string sesion;
    private string usuario;
    private string password;
    private int id_session;
    public static string nombre_usuario;
    static string datosConexion = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password =KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pilotaje;";

    private void Start()
    {
       usuarioPassFail.gameObject.SetActive(false);
       id_periodo = "202001";
       id_reim = "27";
    }

    // Update is called once per frame
    void Update()
    {
        usuario = userInput.GetComponent<TMP_InputField>().text;
        password = passwordInput.GetComponent<TMP_InputField>().text;

    }

    public void inicioSesion()
    {
        MySqlConnection conectar = new MySqlConnection(datosConexion);
        conectar.Open();

        MySqlCommand codigo = new MySqlCommand();
        codigo.Connection = conectar;
        

        codigo.CommandText = ("SELECT * FROM ulearnet_reim_pilotaje.usuario WHERE username = '" + usuario + "' AND password = '" + password + "'");
        MySqlDataReader leer = codigo.ExecuteReader();
        if (leer.Read())
        {
            idUsuario = leer.GetInt32(0);
            //DateTime ahora = DateTime.Now;
            Debug.Log("Bienvenido a Ulearnet "+ usuario);
            Debug.Log("Periodo: " + id_periodo + "\nREIM: " + id_reim);


            //REGISTRA SESION:
            sesionBD();

            //MANTIENE ID DE USUARIO EN EL SINGLETON DE LA APP:
            id_obtenido();
            
            //codigo.CommandText = ("SELECT id_usuario FROM ulearnet_reim_pilotaje.usuario WHERE username = '" + usuario + "'");
            
            SceneManager.LoadScene("Building Map Screen");

        }
        else
        {            
            usuarioPassFail.gameObject.SetActive(true);
            Debug.Log("Usuario o contraseña incorrectos");
        }

        conectar.Close();
        
    }

    public void id_obtenido()
    {
        MySqlConnection conectar = new MySqlConnection(datosConexion);
        conectar.Open();

        MySqlCommand codigo = new MySqlCommand();
        codigo.Connection = conectar;


        codigo.CommandText = ("SELECT id FROM ulearnet_reim_pilotaje.usuario WHERE username = '" + usuario + "' AND password = '" + password + "'");

        MySqlDataReader lectura = codigo.ExecuteReader();

        if(lectura.Read()){
            int value = lectura.GetInt32(0);
            GameSingleton.Instance.id_usuario = value;
        }              
        
    }

    public static void sesionBD()
    {
        DateTime ahora = DateTime.Now;
        string fecha = ahora.ToString("yyyy-MM-dd HH:mm:ss");
        MySqlConnection connect = new MySqlConnection(datosConexion);
        connect.Open();
        id_sesion = idUsuario + "-" + fecha;
        MySqlCommand insert = new MySqlCommand();
        insert.Connection = connect;
        sesion = "INSERT INTO `ulearnet_reim_pilotaje`.`asigna_reim_alumno`(`sesion_id`,`usuario_id`,`periodo_id`,`reim_id`,`datetime_inicio`,`datetime_termino`)" +
        "VALUES('" + id_sesion + "','" + idUsuario + "','" + 202001 + "','" + 27 + "','" + fecha + "','" + fecha + "');";
        insert.CommandText = (sesion);
        insert.ExecuteNonQuery();
        GameSingleton.Instance.id_sesion = id_sesion;

        connect.Close();
    }

    public int getIdUsuario()
    {
        return idUsuario;
    }

    public string GetidSesion()
    {
        return id_sesion;
    }

    public string GetNombre()
    {
        return nombre_usuario;
    }
    

    public void DesactivarMensajeError()
    {
        usuarioPassFail.gameObject.SetActive(false);
    }

    
}