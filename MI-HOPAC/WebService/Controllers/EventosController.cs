using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class EventosController : DatabaseOperation<EventosModel>
    {
        public List<EventosModel> ConsultaEvento()
        {
            return Select("select * from eventos");
        }

        public List<EventosModel> ConsultaEvento(string name)
        {
            return Select("select * from eventos where Nombre = '" + name + "'");
        }

        public void EliminarEvento(int primaryKey)
        {
            Delete("delete from eventos where idEventos = " + primaryKey.ToString());
        }

        public void ActualizarEvento(int primaryKey, string nombre)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update eventos set Nombre = @nombre 
                                where idEventos = @primaryKey";

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@primaryKey", primaryKey));

            Update(cmd);
        }

        public void InsertarEvento(string nombre, DateTime fecha, string ubicacion, string guia, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into eventos(Nombre, Fecha, Ubicacion, Guia, fkDoctor) 
                                values(@nombre, @fecha, @ubicacion, @guia, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@ubicacion", ubicacion));
            cmd.Parameters.Add(new MySqlParameter("@guia", guia));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }
    }
}