using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CuentaDoctoresController
    {
        public List<CuentaDoctoresModel> ConsultaCuentaDoctores(int primaryKey)
        {
            DatabaseOperation<CuentaDoctoresModel> db = new DatabaseOperation<CuentaDoctoresModel>();
            var result = new List<CuentaDoctoresModel>();
            result = db.Select("select * from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
            return result;
        }

        public void EliminarCuentadoctores(int primaryKey)
        {
            DatabaseOperation<CuentaDoctoresModel> db = new DatabaseOperation<CuentaDoctoresModel>();
            db.Delete("delete from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
        }
    }
}