using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CitasPacientesController : DatabaseOperation<CitasPacientesModel>
    {
        public List<CitasPacientesModel> ConsultaCitas(int fkDoctor)
        {
            string query = "SELECT Citas.Fecha, Paciente.Nombre " +
                           "FROM Citas " +
                           "LEFT JOIN Paciente " +
                           "ON Paciente.idPaciente = Citas.Fkpaciente " +
                           "WHERE Citas.FkDoctor = " + fkDoctor.ToString() +
                           " ORDER BY Citas.Fecha DESC";

            return Select(query);
        }
    }
}