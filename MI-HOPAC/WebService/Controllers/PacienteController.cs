using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class PacienteController : DatabaseOperation<PacienteModel>
    {

        public PacienteModel ConsultaCuentaPacientes(int primaryKey)
        {
            var res = Select("select * from paciente where idPaciente = " + primaryKey.ToString());
            return res.First();
        }


    }

}