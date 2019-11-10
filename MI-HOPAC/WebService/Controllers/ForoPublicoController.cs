using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;


namespace WebService.Controllers
{
    public class ForoPublicoController : DatabaseOperation<ForoPublicoModel>
    {

        public List<ForoPublicoModel> ConsultaForoPublico()
        {
            return Select(@"SELECT foropublico.idforopublico, foropublico.Texto, foropublico.Fecha, paciente.Nombre, paciente.Apellidos
                            FROM foropublico
                            LEFT JOIN Paciente  
                            ON foropublico.FkPaciente = paciente.Idpaciente");

        }


        public List<ForoPublicoModel> ConsltaComentariosPublico(int fkForo)
        {
            return Select(@"SELECT comentariospublico.idComentariosPublico, comentariospublico.Texto, comentariospublico.Fecha, paciente.Nombre, paciente.Apellidos
                            FROM comentariospublico
                            LEFT JOIN Paciente
                            ON comentariospublico.FkPaciente = paciente.Idpaciente  WHERE comentariospublico.fkForo = " + fkForo.ToString());
        }


        public void InsertaForoPublico(string texto, string fecha, int fkPaciente)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into ForoPublico(Texto, Fecha, fkPaciente) 
                                values(@texto, @fecha, @fkPaciente)";

            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));

            Insert(cmd);

        }



    }
}