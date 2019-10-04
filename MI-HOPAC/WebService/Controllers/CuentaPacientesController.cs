using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class CuentaPacientesController : DatabaseOperation<CuentaPacientesModel>
    {
        public List<CuentaPacientesModel> ConsultaCuentaPacientes(int primaryKey)
        {
            return Select("select * from cuenta_paciente where idCuenta = " + primaryKey.ToString());
        }

        public void EliminarCuentaPacientes(int primaryKey)
        {
            Delete("delete from cuenta_paciente where idCuenta = " + primaryKey.ToString());
        }
    }
}