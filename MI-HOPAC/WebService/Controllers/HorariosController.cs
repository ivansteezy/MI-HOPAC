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
                   " and ('" + fecha.ToString("HH:mm:ss") + "' between horai and SUBTIME(horaf, '1:00')) and (fkDia = " + (int)fecha.DayOfWeek + ")");
        }

        public List<HorariosModel> HorarioDisponibleMovil(int fkDoctor, string fecha, int dia)
        {

            return Select("select * from horario where  fkDoctor = " + fkDoctor.ToString() +
                   " and ('" + fecha + "' between horai and SUBTIME(horaf, '1:00')) and (fkDia = " + dia.ToString() + ")");
        }


        public void EliminarHorarios(int fkDoctor)
        {
            Delete("delete from Horario where fkDoctor = " + fkDoctor.ToString());
        }

        public List<HorariosModel> GetHorario(int fkDoctor)
        {

            return Select("select * from horario where fkDoctor = " + fkDoctor.ToString());

        }


        public List<string> GetColores(int fkDoctor)
        {
            var LosDias = Select("select * from horario where fkDoctor = " + fkDoctor.ToString());

            var Numeros = new List<int>();

            foreach (HorariosModel dato in LosDias)
            {
                if (dato.m_FkDia == 7)
                    dato.m_FkDia = 0;

                Numeros.Add(dato.m_FkDia);
            }

            var Hoy = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            Hoy = Hoy.Date + ts;

            var oftheweek = (int)(Hoy.DayOfWeek);

            oftheweek = (oftheweek - 1) * -1;
            Hoy = Hoy.AddDays(oftheweek);

            if (Hoy.Day < 8)
                Hoy = Hoy.AddDays(7);
            else if (Hoy.Day > 23)
                Hoy = Hoy.AddDays(-7);

            var Guardar = Hoy;

            var Final = new List<string>();

            foreach (int Selec in Numeros)
            {
                Hoy = Guardar;

                int NumASum = 0;

                if (Selec == 0)
                    NumASum = 7;
                else
                    NumASum = Selec;

                Hoy = Hoy.AddDays(NumASum - 1);


                for (int Comp = 0; Comp < 7; Comp++)
                {
                    var Dia1 = Hoy;

                    if (Comp == Selec)
                    {
                        while (!(Dia1.Day < 8))
                        {
                            Final.Add(Dia1.Date.ToString());
                            Dia1 = Dia1.AddDays(7);
                        }

                        Dia1 = Hoy;

                        while (!(Dia1.Day > 24))
                        {
                            Final.Add(Dia1.Date.ToString());
                            Dia1 = Dia1.AddDays(-7);
                        }

                    }
                }

            }

            return Final;

        }


        public List<string> GetDiasDelMes(int fkDoctor)
        {
            var Hoy = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            Hoy = Hoy.Date + ts;

            var oftheweek = (int)(Hoy.Day);

            oftheweek = (oftheweek - 1) * -1;

            Hoy = Hoy.AddDays(oftheweek);

            var Guardar = Hoy;

            var Final = new List<string>();

            var DiasSi = GetColores(fkDoctor);

            bool Checar = false;

            for (int sum = 0; sum < 32; sum++)
            {
                Hoy = Guardar;

                Hoy = Hoy.AddDays(sum);

                foreach (string Dia in DiasSi)
                {
                    if (Hoy.ToString() == Dia)
                        Checar = true;

                }

                if(!Checar)
                    Final.Add(Hoy.Date.ToString());

                Checar = false;

            }

            return Final;

        }


    }
}