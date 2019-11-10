using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class NotasInformativasController : DatabaseOperation<NotasInformativasModel>
    {

        public List<NotasInformativasModel> ConsultaNotasInfo(int foreingKey)
        {
            return Select("select * from notasinfo where fkDoctor = " + foreingKey.ToString());
        }

        public void EliminarNotaInfo(int primaryKey)
        {
            Delete("delete from notasinfo where idNotas = " + primaryKey.ToString());
        }

        public void ActualizarNotaInfo(int primaryKey, string titulo, string texto, string link)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update notasinfo set Titulo = @titulo, Texto = @texto, Link = @link
                                where idNotas = @primaryKey";

            cmd.Parameters.Add(new MySqlParameter("@titulo", titulo));
            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@link", link));
            cmd.Parameters.Add(new MySqlParameter("@primaryKey", primaryKey));

            Update(cmd);
        }

        public void InsertarNotaInfo(string titulo, string texto, string link, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into notasinfo(Titulo, Texto, Link, fkDoctor) 
                                values(@titulo, @texto, @link, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@titulo", titulo));
            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@link", link));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }


    }




}
