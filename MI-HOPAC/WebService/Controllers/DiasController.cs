using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class DiasController : DatabaseOperation<DiasModel>
    {
        public List<DiasModel> ConsultaDias(int primaryKey)
        {
            return Select("select * from Citas where idDia = " + primaryKey.ToString());
        }
    }
}