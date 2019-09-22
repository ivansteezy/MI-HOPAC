using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class DoctoresControllers : Conexion
    {
        public List<DoctoresModel> QueryDoctores(int id)
        {
            var result = new List<DoctoresModel>();
            using (MySqlConnection con = objConexion)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = @"select * from doctores where idDoctores = @pk";
                    cmd.Parameters.AddWithValue("@pk", id);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            DoctoresModel modeloDoctores = new DoctoresModel();
                            modeloDoctores.m_Pk = lector.GetInt32(0);
                            modeloDoctores.m_Nombre = lector.GetString(1);
                            modeloDoctores.m_Cedula = lector.GetInt32(2);
                            modeloDoctores.m_Ubicacion = lector.GetString(3);
                            modeloDoctores.m_TipoDeMedicina = lector.GetString(4);
                            result.Add(modeloDoctores);
                        }
                    }
                }
            }
            return result;
        }
    }
}