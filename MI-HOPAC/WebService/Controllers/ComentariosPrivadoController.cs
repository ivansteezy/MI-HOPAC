using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class ComentariosPrivadoController : DatabaseOperation<ComentariosPrivadoModel>
    {
        public void InsertarComentario(string texto, string fecha, int tipodeCuenta, int fkForo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into comentariosprivado(Texto, Fecha, TipodeCuenta, fkForo) 
                                values(@texto, @fecha, @TipodeCuenta, @fkForo)";

            cmd.Parameters.Add(new MySqlParameter("@texto", texto));
            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@TipodeCuenta", tipodeCuenta));
            cmd.Parameters.Add(new MySqlParameter("@fkForo", fkForo));

            Insert(cmd);
        }


        public List<ComentariosPrivadoModel> ConsltaComentariosPrivado(int fkForo)
        {
            return Select("SELECT * from comentariosprivado WHERE fkForo = " + fkForo.ToString() + " ORDER BY idComentariosPrivado DESC");
        }


    }
}