using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CodigosController : DatabaseOperation<CodigosModel>
    {

        public void InsertarCodigo(double Codigo, int fkDoctor, int fkReceta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into codigos() 
                            values(Null, @Codigo, @fkDoctor, @fkReceta)";

            cmd.Parameters.Add(new MySqlParameter("@Codigo", Codigo));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));
            cmd.Parameters.Add(new MySqlParameter("@fkReceta", fkReceta));

            Insert(cmd);

        }


        public List<CodigosModel> ConsultaCodigos(double Codigo)
        {
            return Select("select * from codigos where Codigo = " + Codigo.ToString());
        }

    }
}