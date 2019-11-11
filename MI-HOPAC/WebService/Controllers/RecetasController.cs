using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class RecetasController : DatabaseOperation<RecetasModel>
    {


        public List<RecetasModel> ConsultaReceta(int fkDoctor)
        {
            return Select("select * from recetas where fkDoctor = " + fkDoctor.ToString());
        }

        public void InsertarRecetas(string Nombre, string FechaCreacion, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into recetas(Nombre, FechaCreacion, fkDoctor) 
                                values(@Nombre, @FechaCreacion, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@Nombre", Nombre));
            cmd.Parameters.Add(new MySqlParameter("@FechaCreacion", FechaCreacion));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }

    }
}