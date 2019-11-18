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

        public void InsertarTratamiento(DateTime fecha, int Calificacion, int FkPregunta, int fkDoctor, int FkPaciente, int fkReceta)
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


    }
}