using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebService.Configurations
{
    public class Conexion
    {
        /// <summary>
        /// Cadena que represte la conexion a la base de datos.
        /// </summary>
        protected string connectionString;
        public MySqlConnection objConexion;

        public Conexion()
        {
            try
            {
                connectionString = "datasource=den1.mysql4.gear.host;port=3306;username=homeacup;pwd=Proyecto1.;database=homeacup;";
                objConexion = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}