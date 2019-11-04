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
    public class CuentaPacientesController : DatabaseOperation<CuentaPacientesModel>
    {
        public List<CuentaPacientesModel> ConsultaCuentaPacientes(int primaryKey)
        {
            return Select("select * from cuenta_paciente where idCuenta = " + primaryKey.ToString());
        }

        public CuentaPacientesModel ConsultaCuentaPaciente(string correo, string contrasena)
        {
            var res = Select("select * from cuenta_paciente where correo = '" + correo + "' AND contrasena = '" + contrasena + "'");

            CuentaPacientesModel final = new CuentaPacientesModel();
            string estado;

            if (res.Count == 0)
            {
                estado = "ERROR";
                final.m_IdCuenta = -1;
                final.m_Correo = "0";
                final.m_Password = "0";
                final.m_FkPaciente = 0;
            }
            else
            {
                estado = "OK";
                final.m_IdCuenta = res[0].m_IdCuenta;
                final.m_Correo = res[0].m_Correo;
                final.m_Password = res[0].m_Password;
                final.m_FkPaciente = res[0].m_FkPaciente;
            }

            return final;
        }

        public void EliminarCuentaPacientes(int primaryKey)
        {
            Delete("delete from cuenta_paciente where idCuenta = " + primaryKey.ToString());
        }


        public int InsertaCuentaPaciente(string nombre, string appellidos, string Correo, string Contrasena)
        {
            try
            {
                objConexion.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = objConexion;

                cmd.CommandText = "InsertarCuentaPac";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@appe", appellidos);
                cmd.Parameters["@appe"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Cor", Correo);
                cmd.Parameters["@Cor"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Contra", Contrasena);
                cmd.Parameters["@Contra"].Direction = ParameterDirection.Input;

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