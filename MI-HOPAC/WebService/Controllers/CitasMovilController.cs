using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;

namespace WebService.Controllers
{
    public class CitasMovilController : DatabaseOperation<CitasMovilModel>
    {
        public List<CitasMovilModel> ConsultaCitasPaciente(int fkPaciente)
        {
            string query = @"SELECT Citas.IDCitas, Citas.Fecha, Doctores2.Nombre, Doctores2.Apellidos, Doctores2.idCuenta_Doctores
                            FROM Citas, (select cuenta_doctores.idCuenta_Doctores, Doctores.Nombre, Doctores.Apellidos from Doctores, cuenta_doctores where cuenta_doctores.fkDoctor = Doctores.idDoctores) as Doctores2
                            WHERE Citas.fkPaciente = " + fkPaciente.ToString() + @" AND Citas.fkDoctor = Doctores2.idCuenta_Doctores
                            ORDER BY Citas.Fecha DESC";

            return Select(query);
        }


        public void EliminarCitaPaciente(int primaryKey)
        {
            Delete("delete from citas where idCitas = " + primaryKey.ToString());
        }

    }
}