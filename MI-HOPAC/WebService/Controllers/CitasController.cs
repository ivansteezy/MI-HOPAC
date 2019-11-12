using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;
using WebService.Configurations;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace WebService.Controllers
{
    public class CitasController : DatabaseOperation<CitasModel>
    {
        public List<CitasModel> CitasDisponibles(DateTime fechaCita, int fkDoctor)
        {
            return Select("select * from citas where (fecha between DATE_SUB('" + fechaCita.ToString("yyyy-MM-dd HH:mm:ss") + 
                          @"', INTERVAL 60 MINUTE) and '"+fechaCita.ToString("yyyy-MM-dd HH:mm:ss") + @"') or (fecha between '" + 
                          fechaCita.ToString("yyyy-MM-dd HH:mm:ss") + @"' and DATE_ADD('"+ fechaCita.ToString("yyyy-MM-dd HH:mm:ss") + 
                          "', INTERVAL 60 MINUTE)) and fkDoctor = " + fkDoctor.ToString());
        }

        public List<CitasModel> CitasDisponiblesMovil(string fechaCita, int fkDoctor)
        {
            //DateTime dateTime = DateTime.Parse(fechaCita);

            //CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime dateTime = DateTime.ParseExact(fechaCita, "dd/MM/yyyy mm:hh:ss tt", provider);

            return Select("select * from citas where (fecha between DATE_SUB('" + fechaCita +
                          @"', INTERVAL 60 MINUTE) and '" + fechaCita + @"') or (fecha between '" +
                          fechaCita + @"' and DATE_ADD('" + fechaCita +
                          "', INTERVAL 60 MINUTE)) and fkDoctor = " + fkDoctor.ToString());
        }

        //TODO
        public void EliminarCitas(int primaryKey)
        {
            Delete("delete from Citas where idCitas = " + primaryKey.ToString());
        }

        public void InsertarCita(DateTime fecha, int fkPaciente, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citas(Fecha, fkPaciente, fkDoctor) values (@fecha, @fkPaciente, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));
            
            Insert(cmd);
        }

        public void InsertarCitaMovil(string fecha, int fkPaciente, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citas(Fecha, fkPaciente, fkDoctor) values (@fecha, @fkPaciente, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", fkPaciente));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }
    }
}