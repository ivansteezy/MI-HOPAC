using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CitasHomeopaticoController : DatabaseOperation<CitasHomeopaticoModel>
    {

        public void InsertCitaHomeopactica(string sintomas, string reper, string fecha, int fkPaciente)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citashomeopatia()  
                                values(Null, @Sintomas, @Repertorizacion, @Fecha, @FkPaciente)";

            cmd.Parameters.Add(new MySqlParameter("@Sintomas", sintomas));
            cmd.Parameters.Add(new MySqlParameter("@Repertorizacion", reper));
            cmd.Parameters.Add(new MySqlParameter("@Fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@FkPaciente", fkPaciente));

            Insert(cmd);
        }

        public List<CitasHomeopaticoModel> ConsultaCitasHomeopatica(int pk)
        {
            return Select("select * from citashomeopatia where FkPaciente = " + pk.ToString());
        }

        public List<CitasHomeopaticoModel> ConsultaCitasHomeopaticaID(int pk)
        {
            return Select("select * from citashomeopatia where idcitasahomeopatia = " + pk.ToString());
        }

    }
}