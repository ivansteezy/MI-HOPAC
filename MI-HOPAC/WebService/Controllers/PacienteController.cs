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
        public List<PacienteModel> ConsultaPacientes(int fk)
        {
            return Select("select * from paciente where fkDoctorH = " + fk.ToString() + " or fkDoctorA = " + fk.ToString()); 
        }

        public PacienteModel ConsultaCuentaPacientes(int primaryKey)
        {
            var res = Select("select * from paciente where idPaciente = " + primaryKey.ToString());
            return res.First();
        }


    }

}