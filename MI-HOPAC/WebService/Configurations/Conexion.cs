using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebService.Configurations
{
    public class Conexion
    {
        protected string connectionString;
        public MySqlConnection objConexion;

        public Conexion()
        {
            try
            {
                connectionString = "datasource=den1.mysql1.gear.host;port=3306;username=natibase;pwd=natibase619!;database=natibase;";
                objConexion = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}