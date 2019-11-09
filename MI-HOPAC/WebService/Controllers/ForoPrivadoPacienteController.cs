using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;


namespace WebService.Controllers
{
    public class ForoPrivadoPacienteController : DatabaseOperation<ForoPrivadoPacienteModel>
    {

        public List<ForoPrivadoPacienteModel> ConsultaForoPaciente(int pkPac, int pkDoc)
        {
            return Select(@"select * from foroprivado where fkPaciente = " + pkPac.ToString() +
                            " and fkDoctor = " + pkDoc.ToString());

        }

    }
}