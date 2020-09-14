using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GuardarTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator conexion(int id_user, int periodo_id, int reim_id)
    {
        string datosConexion = "host=ulearnet.org; Port =3306; UserName=reim_ulearnet; Password=KsclS$AcSx.20Cv83xT; Database=ulearnet_reim_pruebas;";
        MySqlConnection conectar = new MySqlConnection(datosConexion);
        //DateTime ahora = DateTime.Now;

        try
        {
            conectar.Open();
            MySqlCommand query = conectar.CreateCommand();
            DateTime ahora = DateTime.Now;
            //query.CommandText = "INSERT INTO `ulearnet_reim_pruebas`.`asigna_reim_alumno` (`sesion_id`,`usuario_id`,`periodo_id`,`reim_id`,`datetime_inicio`,`datetime_termino`)VALUES('" + id_user + "-" + ahora.ToString("yyyyMMddHHmmssffff") + "','" + id_user + "','" + periodo_id + "','" + reim_id + "','" + ahora.ToString("yyyyMMddHHmmssffff") + "','" + ahora.ToString("yyyyMMddHHmmssffff") + "');";

            query.CommandText = "UPDATE `ulearnet_reim_pruebas`.`asigna_reim_alumno` SET `datetime_termino` = '"+ ahora.ToString("yyyyMMddHHmmssffff")+"' WHERE(`sesion_id` = '"+GameSingleton.Instance.time+"');";
            
            query.ExecuteNonQuery();
            Debug.Log("Envio los datos");
            conectar.Close();
        }
        catch (MySqlException error)
        {
            Debug.Log("Error NO se envio datos: " + error);
        }


        yield return null;
    }

    public void inicio()
    {
        StartCoroutine(conexion(GameSingleton.Instance.id_usuario, 201902, 14));
    }

}

