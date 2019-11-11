using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebService.Controllers
{
    public class RecetasController : DatabaseOperation<RecetasModel>
    {


        public List<RecetasModel> ConsultaReceta(int fkDoctor)
        {
            return Select("select * from recetas where fkDoctor = " + fkDoctor.ToString());
        }

        public int InsertarRecetas(string Nombre, DateTime FechaCreacion, int fkDoctor)
        {
            try
            {
                objConexion.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = objConexion;

                cmd.CommandText = "CrearReceta";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom", Nombre);
                cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Fecha", FechaCreacion.Date);
                cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@fkDoc", fkDoctor);
                cmd.Parameters["@fkDoc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LastID", MySqlDbType.Int32);
                cmd.Parameters["@LastID"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                objConexion.Close();

                return int.Parse(cmd.Parameters["@LastID"].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }




        }

    }
}