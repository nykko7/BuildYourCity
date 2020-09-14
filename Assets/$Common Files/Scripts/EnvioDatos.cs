using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnvioDatos : MonoBehaviour //, IPointerDownHandler
{
            


    //**************** Coordenadas ********************

    public static float x = 0;
    public static float y = 0;

    int idUsuario;
    string idSesion;
    string datosConexion;

    
    //**************** Datos alumnos ********************



    //**************** Datos BD ********************
    public void conexion(int id_per, int id_user, int id_reim, int id_actividad, int id_elemento, float fila, float columna, int correcta)
    //public IEnumerator conexion(int id_per, int id_user, int id_reim, int id_actividad, int id_elemento, float fila, float columna, int correcta)
    {   
        
        MySqlConnection conectar = new MySqlConnection(datosConexion);
        //DateTime ahora = DateTime.Now;

        try
        {
            
            conectar.Open();
            MySqlCommand query = conectar.CreateCommand();
            DateTime ahora = DateTime.Now;
            query.CommandText = "INSERT INTO `ulearnet_reim_pilotaje`.`alumno_respuesta_actividad` (`id_per`,`id_user`,`id_reim`,`id_actividad`,`id_elemento`,`datetime_touch`,`fila`,`columna`,`correcta`)VALUES('" + id_per + "','" + idUsuario + "','" + id_reim + "','" + id_actividad + "','" + id_elemento + "','" + ahora.ToString("yyyyMMddHHmmssffff") + "','" + fila + "','" + columna + "','" + correcta + "');";
            query.ExecuteNonQuery();
            query.CommandText = "UPDATE `ulearnet_reim_pilotaje`.`asigna_reim_alumno` SET `datetime_termino` = '" + ahora.ToString("yyyyMMddHHmmssffff") + "' WHERE(`sesion_id` = '" + idSesion + "');";
            query.ExecuteNonQuery();
            Debug.Log("Envío de registro a Alumno_Respuesta_Actividad: "+ ahora.ToString("yyyyMMddHHmmssffff"));
            conectar.Close();
        }
        catch (MySqlException error)
        {
            Debug.Log("Error NO se envio datos: " + error);
        }


        //yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        datosConexion = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pilotaje;";
    }

    void Update()
    {
        idUsuario = GameSingleton.Instance.id_usuario;
        idSesion = GameSingleton.Instance.id_sesion;        
    }


    // ------------------------------- Funcion de toque de botones ----------------- //
    public void ButtonPressed(GameObject ButtonPressed, int idActividad, int idElemento, int esCorrecta)
    {
        
        x = ButtonPressed.transform.position.x;
        y = ButtonPressed.transform.position.y;
        //StartCoroutine(conexion(202001,idUsuario, 27, idActividad, idElemento, x, y, esCorrecta));
        conexion(202001,idUsuario, 27, idActividad, idElemento, x, y, esCorrecta);
        x = 0;
        y = 0;      
        
    }

    
   

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     ConexionBD cnx = new ConexionBD();
    //     int idusuario = cnx.getId();
    //     contadorPantalla++;
    //     contadorPantallaAux++;
    //     Debug.Log("SE HA TOCADO LA PANTALLA");
    //     StartCoroutine(conexion(202002, idusuario, 14, 1400, 1407, x, y, 2));
    //     x = 0;
    //     y = 0;
    // }
    
}
