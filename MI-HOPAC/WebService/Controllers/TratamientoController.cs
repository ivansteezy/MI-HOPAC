using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class TratamientoController : DatabaseOperation<TratamientoModel>
    {

        public void InsertarTratamiento(string fecha, int Calificacion, int FkPregunta, int fkDoctor, int FkPaciente, int fkReceta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into tratamiento()  
                                values(Null, @Fecha, @Calificacion, @FkPregunta, @FkDoctor, @FkPaciente, @FkReceta)";

            cmd.Parameters.Add(new MySqlParameter("@Fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@Calificacion", Calificacion));
            cmd.Parameters.Add(new MySqlParameter("@FkPregunta", FkPregunta));
            cmd.Parameters.Add(new MySqlParameter("@FkDoctor", fkDoctor));
            cmd.Parameters.Add(new MySqlParameter("@FkPaciente", FkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@FkReceta", fkReceta));
            


            Insert(cmd);
        }


        public List<TratamientoModel> ConsultaByPregunta(int pk)
        {
            return Select("select * from tratamiento where FkPregunta = " + pk.ToString());
        }

        public List<TratamientoModel> ConsultaByDoctor(int pk)
        {
            return Select("select * from tratamiento where FkDoctor = " + pk.ToString());
        }

        public List<TratamientoModel> ConsultaByPaciente(int pk)
        {
            return Select("select * from tratamiento where FkPaciente = " + pk.ToString());
        }

        public List<TratamientoModel> ConsultaByReceta(int pk)
        {
            return Select("select * from tratamiento where FkReceta = " + pk.ToString());
        }


        public GraficaModel GetPreguntaUnoAcu(int FkPaciente, int FkDoctor)
        {

            var dia = new DateTime();
            dia = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            dia = dia.Date + ts;

            var oftheweek = (int)(dia.DayOfWeek);

            oftheweek = (oftheweek - 1) * -1;
            var inicio = dia.AddDays(oftheweek);

            var fin = inicio.AddDays(7);

            var Res = Select(@"Select * from tratamiento where fkPregunta = 1 AND fkReceta = -1 
                            AND fkPaciente = " + FkPaciente.ToString() + " AND FkDoctor = " + FkDoctor.ToString() +
                            " AND ( Fecha between '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
                                  " '" + fin.ToString("yyyy-MM-dd HH:mm:ss") + "')");


            var Salida = new GraficaModel();
            Salida.Promedio = 0;
            Salida.FechaF = (fin.AddDays(-1)).Date.ToLongDateString();
            Salida.FechaI = inicio.Date.ToLongDateString();


            if (Res.Count > 0)
            {
                foreach(var i in Res)
                {
                    Salida.Promedio = Salida.Promedio + i.m_Calificaion;
                }

                Salida.Promedio = Salida.Promedio / Res.Count();

                return Salida;
            }
            else
            {
                return Salida;
            }


        }

        public GraficaModel GetPreguntaUnoHom(int FkPaciente, int FkDoctor)
        {

            var dia = new DateTime();
            dia = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            dia = dia.Date + ts;

            var oftheweek = (int)(dia.DayOfWeek);

            oftheweek = (oftheweek - 1) * -1;
            var inicio = dia.AddDays(oftheweek);

            var fin = inicio.AddDays(7);

            var Res = Select(@"Select * from tratamiento where fkPregunta = 1 AND fkReceta > 0 
                            AND fkPaciente = " + FkPaciente.ToString() + " AND FkDoctor = " + FkDoctor.ToString() +
                            " AND ( Fecha between '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
                                  " '" + fin.ToString("yyyy-MM-dd HH:mm:ss") + "')");


            var Salida = new GraficaModel();
            Salida.Promedio = 0;
            Salida.FechaF = (fin.AddDays(-1)).Date.ToLongDateString();
            Salida.FechaI = inicio.Date.ToLongDateString();


            if (Res.Count > 0)
            {
                foreach (var i in Res)
                {
                    Salida.Promedio = Salida.Promedio + i.m_Calificaion;
                }

                Salida.Promedio = Salida.Promedio / Res.Count();

                return Salida;
            }
            else
            {
                return Salida;
            }


        }

        public GraficaModel GetPreguntaDos(int FkPaciente, int FkDoctor)
        {

            var dia = new DateTime();
            dia = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            dia = dia.Date + ts;

            var oftheweek = (int)(dia.DayOfWeek);

            oftheweek = (oftheweek - 1) * -1;
            var inicio = dia.AddDays(oftheweek);

            var fin = inicio.AddDays(7);

            var Res = Select(@"Select * from tratamiento where fkPregunta = 2 
                            AND fkPaciente = " + FkPaciente.ToString() + " AND FkDoctor = " + FkDoctor.ToString() +
                            " AND ( Fecha between '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
                                  " '" + fin.ToString("yyyy-MM-dd HH:mm:ss") + "')");


            var Salida = new GraficaModel();
            Salida.Promedio = 0;
            Salida.FechaF = (fin.AddDays(-1)).Date.ToLongDateString();
            Salida.FechaI = inicio.Date.ToLongDateString();


            if (Res.Count > 0)
            {
                foreach (var i in Res)
                {
                    Salida.Promedio = Salida.Promedio + i.m_Calificaion;
                }

                Salida.Promedio = Salida.Promedio / Res.Count();

                return Salida;
            }
            else
            {
                return Salida;
            }


        }

        public GraficaModel GetPreguntaTres(int FkPaciente, int FkDoctor)
        {

            var dia = new DateTime();
            dia = DateTime.Now;

            TimeSpan ts = new TimeSpan(00, 00, 0);
            dia = dia.Date + ts;

            var oftheweek = (int)(dia.DayOfWeek);

            oftheweek = (oftheweek - 1) * -1;
            var inicio = dia.AddDays(oftheweek);

            var fin = inicio.AddDays(7);

            var Res = Select(@"Select * from tratamiento where fkPregunta = 3 
                            AND fkPaciente = " + FkPaciente.ToString() + " AND FkDoctor = " + FkDoctor.ToString() +
                            " AND ( Fecha between '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
                                  " '" + fin.ToString("yyyy-MM-dd HH:mm:ss") + "')");


            var Salida = new GraficaModel();
            Salida.Promedio = 0;
            Salida.FechaF = (fin.AddDays(-1)).Date.ToLongDateString();
            Salida.FechaI = inicio.Date.ToLongDateString();


            if (Res.Count > 0)
            {
                foreach (var i in Res)
                {
                    Salida.Promedio = Salida.Promedio + i.m_Calificaion;
                }

                Salida.Promedio = Salida.Promedio / Res.Count();

                return Salida;
            }
            else
            {
                return Salida;
            }


        }



    }
}