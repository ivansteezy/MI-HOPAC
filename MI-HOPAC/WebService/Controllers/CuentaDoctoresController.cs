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
    public class CuentaDoctoresController : DatabaseOperation<CuentaDoctoresModel>
    {
        public List<CuentaDoctoresModel> ConsultaCuentaDoctores(string correo, string contrasena)
        {
            return Select("select * from cuenta_doctores where correo = '" + correo + "' AND contrasena = '" + contrasena + "'");
        }

        public List<CuentaDoctoresModel> ConsultaCuentaDoctoresById(int primaryKey)
        {
            return Select("select * from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
        }

        public void EliminarCuentadoctores(int primaryKey)
        {
            Delete("delete from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
        }


        public int InsertaCuentaDoctor(string nombre, string appellidos, string Correo, string Contrasena, int Medicina)
        {
            try
            {
                objConexion.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = objConexion;

                cmd.CommandText = "InsertarCuentaDoc";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@appe", appellidos);
                cmd.Parameters["@appe"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Cor", Correo);
                cmd.Parameters["@Cor"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Contra", Contrasena);
                cmd.Parameters["@Contra"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Medi", Medicina);
                cmd.Parameters["@Medi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LastID", MySqlDbType.Int32);
                cmd.Parameters["@LastID"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                objConexion.Close();

                return int.Parse(cmd.Parameters["@LastID"].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 69;
            }
        } 

    }
}