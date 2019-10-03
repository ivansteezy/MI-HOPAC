using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;
using WebService.Configurations;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class CitasController
    {
        public List<CitasModel> ConsultaCitas(int primaryKey)
        {
            DatabaseOperation<CitasModel> db = new DatabaseOperation<CitasModel>();
            var result = new List<CitasModel>();
            result = db.Select("select * from Citas where idCitas = " + primaryKey.ToString());
            return result;
        }
    }
}