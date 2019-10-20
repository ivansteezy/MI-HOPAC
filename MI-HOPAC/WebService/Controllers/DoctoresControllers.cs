using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class DoctoresControllers : DatabaseOperation<DoctoresModel>
    {
        public List<DoctoresModel> ConsultaDoctores(int primaryKey)
        {
            return Select("select * from doctores where idDoctores = " + primaryKey.ToString());
        }

        public void EliminarDoctores(int primaryKey)
        {
            Delete("delete from doctores where idDoctores = " + primaryKey.ToString());
        }

        public void ActualizarDoctores(int primaryKey, string ubicacion = "", long cedula = 0)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"update doctores set Cedula = @cedula,
                                       Ubicacion = @ubicacion
                                       where idDoctores = @primaryKey";

            cmd.Parameters.Add(new MySqlParameter("@cedula", cedula));
            cmd.Parameters.Add(new MySqlParameter("@ubicacion", ubicacion));
            cmd.Parameters.Add(new MySqlParameter("@primaryKey", primaryKey));

            Update(cmd);
        }
    }
}