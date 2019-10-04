using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;
using WebService.Configurations;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class CitasController : DatabaseOperation<CitasModel>
    {
        public List<CitasModel> ConsultaCitas(int primaryKey)
        {
            return Select("select * from Citas where idCitas = " + primaryKey.ToString());
        }

        public void EliminarCitas(int primaryKey)
        {
            Delete("delete from Citas where idCitas = " + primaryKey.ToString());
        }
    }
}