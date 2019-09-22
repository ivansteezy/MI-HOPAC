using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.ComponentModel;

namespace WebService.Configurations
{
    /// <summary>
    /// Clase template con la cual se pueden realziar las operaciones tipicas a una base de datos (Create, Read, Update, Delete).
    /// </summary>
    public class DatabaseOperation<T> : Conexion where T : new()
    {
        public List<T> Select(string query)
        {
            //creamos una lista de Modelos genericos
            List<T> listaModeloGenerico = new List<T>();
            
            using (MySqlConnection con = objConexion)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    con.Open();

                    cmd.Connection = con;
                    cmd.CommandText = query;

                    //para cada propiedad del modelo genero asignarle lo que esta en la columna numero i
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        //Mientras haya datos en la tabla
                        while (lector.Read())
                        {
                            //Instanciamos un objecto de tipo T
                            T modeloGenerico = getObject();

                            //Si hay datos, para cada una de las propiedades del modelo
                            foreach (PropertyInfo prop in modeloGenerico.GetType().GetProperties())
                            {
                                //Agregamos el los datos que se leeyeron de la base de datos
                                //Casteado al tipo correspondiente de la propiedad de la clase generica
                            }
                        }
                    }
                }
            }
          return listaModeloGenerico;
        }

        protected T getObject()
        {
            return new T();
        }
    }
}