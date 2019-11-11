using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class ExpedienteAcupunturaController : DatabaseOperation<ExpedienteAcupunturaModel>
    {
        public int CrearExpedientesAcu(string nombre, int fkDoctor)
        {
            try
            {
                objConexion.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = objConexion;

                cmd.CommandText = "CrearExpedienteAcu";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom", nombre);
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


        public List<ExpedienteAcupunturaModel> ConsultaExpedienteAcupuntura(int pk)
        {
            return Select("select * from Expacupuntura where fkDoctor = " + pk.ToString());
        }


    }
}