using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class PacienteEventosController : DatabaseOperation<PacienteEventosModel>
    {
        public void InsertarPacienteEvento(int fkPaciente, int fkEvento)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into pacienteeventos(fkPaciente, fkEvento, Asistencia) 
                                values(@fkPaciente, @fkEvento, @asistencia)";
            int asistencia = 0;

            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkEvento", fkEvento));
            cmd.Parameters.Add(new MySqlParameter("@asistencia", asistencia));

            Insert(cmd);
        }

        public void ActualizarAsistencia(int fkPaciente, int fkEvento, int Asistencia)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update pacienteeventos set Asistencia = @asistencia 
                                where FkPaciente = @fkPaciente AND FkEvento = @fkEvento";

            cmd.Parameters.Add(new MySqlParameter("@asistencia", Asistencia));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkEvento", fkEvento));

            Update(cmd);
        }

    }
}