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

        public void ActualizarDocHom(int fkPaciente, int fkDoctor, int fkReceta)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"UPDATE Paciente
                                SET fkDoctorH = @fkDoctor, fkReceta = @fkReceta 
                                WHERE idPaciente = @fkPaciente;";

            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));
            cmd.Parameters.Add(new MySqlParameter("@fkReceta", fkReceta));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));

            Update(cmd);
        }

        public void ActualizarDocAcu(int fkPaciente, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"UPDATE Paciente
                                SET fkDoctorA = @fkDoctor 
                                WHERE idPaciente = @fkPaciente;";

            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));

            Update(cmd);
        }



    }

}