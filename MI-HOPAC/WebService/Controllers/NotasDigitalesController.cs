using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class NotasDigitalesController : DatabaseOperation<NotasDigitalesModel>
    {

        public List<NotasDigitalesModel> ConsultaNotasDig(int foreingKey)
        {
            return Select("select * from notasdig where fkDoctor = " + foreingKey.ToString());
        }

        public void EliminarNotaDig(int primaryKey)
        {
            Delete("delete from notasdig where idNota = " + primaryKey.ToString());
        }

        public void ActualizarEvento(int primaryKey, string color)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update notasdig set Color = @color 
                                where idNota = @primaryKey";

            cmd.Parameters.Add(new MySqlParameter("@color", color));
            cmd.Parameters.Add(new MySqlParameter("@primaryKey", primaryKey));

            Update(cmd);
        }

        public void InsertarNotaDig(string texto, string color, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into notasdig(Texto, Color, fkDoctor) 
                                values(@texto, @color, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@color", color));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }


    }
}