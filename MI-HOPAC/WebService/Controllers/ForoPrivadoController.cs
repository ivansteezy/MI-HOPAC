using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class ForoPrivadoController : DatabaseOperation<ForoPrivadoModel>
    {

        public List<ForoPrivadoModel> ConsultaForo(int pk)
        {
            return Select(@"SELECT ForoPrivado.idForoPrivado, ForoPrivado.Texto, ForoPrivado.Fecha, paciente.Nombre, paciente.Apellidos 
                            FROM ForoPrivado 
                            LEFT JOIN Paciente 
                            ON ForoPrivado.FkPaciente = paciente.Idpaciente 
                            WHERE ForoPrivado.FkDoctor = " + pk.ToString() + 
                            " ORDER BY ForoPrivado.idForoPrivado DESC");
        }


        public void EliminarForo(int primaryKey)
        {
            Delete("delete from eventos where idEventos = " + primaryKey.ToString());
        }

        /*public void ActualizarForo(int primaryKey, string nombre)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update eventos set Nombre = @nombre 
                                where idEventos = @primaryKey";

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@primaryKey", primaryKey));

            Update(cmd);
        }*/


        //------------- Movil ------------------

        public void InsertarForo(string texto, string fecha, int fkPaciente, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into ForoPrivado(Texto, Fecha, fkPaciente, fkDoctor) 
                                values(@texto, @fecha, @fkPaciente, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }


    }
}