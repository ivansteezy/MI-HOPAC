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

        public DoctoresModel ConsultaDoctoresMovil(int primaryKey)
        {
            var res = Select(@"SELECT doctores.idDoctores, doctores.Nombre, doctores.Apellidos, doctores.Cedula, doctores.Ubicacion
                                FROM doctores
                                LEFT JOIN cuenta_doctores
                                ON cuenta_doctores.fkDoctor = doctores.idDoctores
                                WHERE cuenta_doctores.idCuenta_Doctores = " + primaryKey.ToString());
            return res.First();
        }


        public void EliminarDoctores(int primaryKey)
        {
            Delete("delete from doctores where idDoctores = " + primaryKey.ToString());
        }

        public void ActualizarDoctores(int primaryKey, string ubicacion, long cedula)
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