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
    public class CitasAcupunturaController : DatabaseOperation<CitasAcupunturaModel>
    {

        public void InsertarExpedientesAcu(CitasAcupunturaModel cita)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citasacupuntura()  
                                values(Null, @Nombre, @Fecha, @Shen, @Color, @Tonicidad, @Longitud, @Grietas, @Saburra, 
                                        @Humectacion, @PulsoD, @PulsoI, @Sintomas, @fkPaciente)";

            cmd.Parameters.Add(new MySqlParameter("@Nombre", cita.m_Nombre));
            cmd.Parameters.Add(new MySqlParameter("@Fecha", cita.m_Fecha));
            cmd.Parameters.Add(new MySqlParameter("@Shen", cita.m_Shen));
            cmd.Parameters.Add(new MySqlParameter("@Color", cita.m_Color));
            cmd.Parameters.Add(new MySqlParameter("@Tonicidad", cita.m_Tonicidad));
            cmd.Parameters.Add(new MySqlParameter("@Longitud", cita.m_Longitud));
            cmd.Parameters.Add(new MySqlParameter("@Grietas", cita.m_Grietas));
            cmd.Parameters.Add(new MySqlParameter("@Saburra", cita.m_Saburra));
            cmd.Parameters.Add(new MySqlParameter("@Humectacion", cita.m_Humectacion));
            cmd.Parameters.Add(new MySqlParameter("@PulsoD", cita.m_PulsoD));
            cmd.Parameters.Add(new MySqlParameter("@PulsoI", cita.m_PulsoI));
            cmd.Parameters.Add(new MySqlParameter("@Sintomas", cita.m_Sintomas));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", cita.m_fkPaciente));


            Insert(cmd);
        }


        public List<CitasAcupunturaModel> ConsultaCitasAcupuntura(int pk)
        {
            return Select("select * from citasacupuntura where fkPaciente = " + pk.ToString());
        }

        public List<CitasAcupunturaModel> ConsultaCitasAcupunturabyId(int pk)
        {
            return Select("select * from citasacupuntura where idcitasacupuntura = " + pk.ToString());
        }


    }
}