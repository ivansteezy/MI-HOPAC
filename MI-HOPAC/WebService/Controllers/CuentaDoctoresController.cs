using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CuentaDoctoresController : DatabaseOperation<CuentaDoctoresModel>
    {
        public List<CuentaDoctoresModel> ConsultaCuentaDoctores(int primaryKey)
        {
            return Select("select * from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
        }

        public void EliminarCuentadoctores(int primaryKey)
        {
            Delete("delete from cuenta_doctores where idCuenta_Doctores = " + primaryKey.ToString());
        }
    }
}