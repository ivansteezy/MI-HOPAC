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
    /// Clase generica con la cual se pueden realziar las operaciones tipicas a una base de datos (Create, Read, Update, Delete).
    /// </summary>
    /// Nota mental: En el dado caso de que en el desarrollo se necesiten hacer queries mas custom, en lugar de enviar un simple string
    /// podemos enviar un MySqlCommand y asi poder hacer Params.AddWithValue() y posteriormente setteando el CommandText desde el controlador.
    public class DatabaseOperation<T> : Conexion where T : new()
    {
        /// <summary>
        /// Metodo para realizar una consulta de tipo SELECT a la base de datos.
        /// </summary>
        /// <param name="query">Consulta a realizar, representada como un string.</param>
        /// <returns>Un modelo de tipo T.</returns>
        public List<T> Select(string query)
        {
            //creamos una lista de Modelos genericos
            List<T> listaModeloGenerico = new List<T>();
            try
            {
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
                                int x = 0;

                                foreach (PropertyInfo prop in modeloGenerico.GetType().GetProperties())
                                {
                                    //Agregamos el los datos que se leeyeron de la base de datos
                                    object value = lector.GetValue(x++);
                                    string typeName = prop.PropertyType.FullName;
                                    dynamic property = Convert.ChangeType(value, Type.GetType(typeName));

                                    modeloGenerico.GetType().GetProperty(prop.ToString().
                                            Substring(prop.ToString().IndexOf(' ') + 1)).
                                            SetValue(modeloGenerico, property, null);
                                }
                                listaModeloGenerico.Add(modeloGenerico);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listaModeloGenerico;
        }

        public void Delete(string cmd)
        {
            try
            {
                using (MySqlConnection con = objConexion)
                {
                    using (MySqlCommand comando = new MySqlCommand())
                    {
                        con.Open();
                        comando.Connection = con;
                        comando.CommandText = cmd;
                        comando.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Update(MySqlCommand cmd)
        {
            try
            {
                using (MySqlConnection con = objConexion)
                {
                    using (MySqlCommand comando = cmd)
                    {
                        con.Open();
                        comando.Connection = con;
                        comando.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool Insert(MySqlCommand comando)
        {
            try
            {
                using (MySqlConnection con = objConexion)
                {
                    using (MySqlCommand cmd = comando)
                    {
                        cmd.Connection = con;
                        con.Open();
                        if(cmd.ExecuteNonQuery() != 1)
                        {
                            Console.WriteLine("No se inserto fila correctamente.");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        protected T getObject()
        {
            return new T();
        }
    }
}