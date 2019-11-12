using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class HorariosController : DatabaseOperation<HorariosModel>
    {
        public void InsertarHorarios(string horaInicio, string horaFinal, int fkDia, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into horario(HoraI, HoraF, fkDia, fkDoctor) values (@horaInicio, @horaFinal, @fkDia, @fkDoctor)";
            cmd.Parameters.Add(new MySqlParameter("@horaInicio", horaInicio));
            cmd.Parameters.Add(new MySqlParameter("@horaFinal", horaFinal));
            cmd.Parameters.Add(new MySqlParameter("@fkDia", fkDia));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }

        public List<HorariosModel> HorarioDisponible(int fkDoctor, DateTime fecha)
        {
            return Select("select * from horario where  fkDoctor = " + fkDoctor.ToString() +
                   " and ('" + fecha.ToString("HH:mm:ss") + "' between horai and SUBTIME(horaf, '1:00')) and (fkDia = "+ (int)fecha.DayOfWeek +")");
        }

        public List<HorariosModel> HorarioDisponibleMovil (int fkDoctor, string fecha, int dia)
        {

            return Select("select * from horario where  fkDoctor = " + fkDoctor.ToString() +
                   " and ('" + fecha + "' between horai and SUBTIME(horaf, '1:00')) and (fkDia = " + dia.ToString() + ")");
        }


        public void EliminarHorarios(int fkDoctor)
        {
            Delete("delete from Horario where fkDoctor = " + fkDoctor.ToString());
        }
    }
}