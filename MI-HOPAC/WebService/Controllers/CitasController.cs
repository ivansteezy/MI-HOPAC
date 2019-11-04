using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;
using WebService.Configurations;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class CitasController : DatabaseOperation<CitasModel>
    {
        public List<CitasModel> ConsultaCitas(int fkDoctor)
        {
            return Select("select * from Citas where fkDoctor = " + fkDoctor.ToString());
        }

        //TODO
        public void EliminarCitas(int primaryKey)
        {
            Delete("delete from Citas where idCitas = " + primaryKey.ToString());
        }

        public void InsertarCita(DateTime fecha, int fkPaciente, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citas(Fecha, fkPaciente, fkDoctor) values (@fecha, @fkPaciente, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));
            
            Insert(cmd);
        }
    }
}