using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class ComentariosPublicoController : DatabaseOperation<ComentariosPublicoModel>
    {
        public void InsertarComentarioPublico(string texto, string fecha, int fkPaciente, int fkForo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into comentariospublico(Texto, Fecha, fkPaciente, fkForo) 
                                values(@texto, @fecha, @fkPaciente, @fkForo)";

            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkForo", fkForo));

            Insert(cmd);
        }


    }
}