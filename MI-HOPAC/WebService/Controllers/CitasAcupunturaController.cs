using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebService.Controllers
{
    public class CitasAcupunturaController : DatabaseOperation<CitasAcupunturaModel>
    {

        public void InsertarExpedientesAcu(CitasAcupunturaModel cita)
        {
            var res = EncriptarDatos(cita);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into citasacupuntura()  
                                values(Null, @Nombre, @Fecha, @Shen, @Color, @Tonicidad, @Longitud, @Grietas, @Saburra, 
                                        @Humectacion, @PulsoD, @PulsoI, @Sintomas, @fkPaciente)";

            cmd.Parameters.Add(new MySqlParameter("@Nombre", res.m_Nombre));
            cmd.Parameters.Add(new MySqlParameter("@Fecha", res.m_Fecha));
            cmd.Parameters.Add(new MySqlParameter("@Shen", res.m_Shen));
            cmd.Parameters.Add(new MySqlParameter("@Color", res.m_Color));
            cmd.Parameters.Add(new MySqlParameter("@Tonicidad", res.m_Tonicidad));
            cmd.Parameters.Add(new MySqlParameter("@Longitud", res.m_Longitud));
            cmd.Parameters.Add(new MySqlParameter("@Grietas", res.m_Grietas));
            cmd.Parameters.Add(new MySqlParameter("@Saburra", res.m_Saburra));
            cmd.Parameters.Add(new MySqlParameter("@Humectacion", res.m_Humectacion));
            cmd.Parameters.Add(new MySqlParameter("@PulsoD", res.m_PulsoD));
            cmd.Parameters.Add(new MySqlParameter("@PulsoI", res.m_PulsoI));
            cmd.Parameters.Add(new MySqlParameter("@Sintomas", res.m_Sintomas));
            cmd.Parameters.Add(new MySqlParameter("@fkPaciente", res.m_fkPaciente));


            Insert(cmd);
        }

        public CitasAcupunturaModel EncriptarDatos(CitasAcupunturaModel cita)
        {
            CitasAcupunturaModel result = new CitasAcupunturaModel();
            result.m_Nombre      = DataEncryptor.Encrypt(cita.m_Nombre);
            result.m_Shen        = DataEncryptor.Encrypt(cita.m_Shen);
            result.m_Color       = DataEncryptor.Encrypt(cita.m_Color);
            result.m_Tonicidad   = DataEncryptor.Encrypt(cita.m_Tonicidad);
            result.m_Longitud    = DataEncryptor.Encrypt(cita.m_Longitud);
            result.m_Grietas     = DataEncryptor.Encrypt(cita.m_Grietas);
            result.m_Saburra     = DataEncryptor.Encrypt(cita.m_Saburra);
            result.m_Humectacion = DataEncryptor.Encrypt(cita.m_Humectacion);
            result.m_PulsoD      = DataEncryptor.Encrypt(cita.m_PulsoD);
            result.m_PulsoI      = DataEncryptor.Encrypt(cita.m_PulsoI);
            result.m_Sintomas    = DataEncryptor.Encrypt(cita.m_Sintomas);
            result.m_Fecha       = cita.m_Fecha;
            result.m_fkPaciente  = cita.m_fkPaciente;
            return result;
        }

        public List<CitasAcupunturaModel> ConsultaDecrypt(int pk)
        {
            List<CitasAcupunturaModel> resultLista = new List<CitasAcupunturaModel>();
            var lista = ConsultaCitasAcupuntura(pk);

            foreach(var item in lista)
            {
                var result = new CitasAcupunturaModel();
                result.m_Nombre = DataEncryptor.Decrypt(item.m_Nombre);
                result.m_Shen = DataEncryptor.Decrypt(item.m_Shen);
                result.m_Color = DataEncryptor.Decrypt(item.m_Color);
                result.m_Tonicidad = DataEncryptor.Decrypt(item.m_Tonicidad);
                result.m_Longitud = DataEncryptor.Decrypt(item.m_Longitud);
                result.m_Grietas = DataEncryptor.Decrypt(item.m_Grietas);
                result.m_Saburra = DataEncryptor.Decrypt(item.m_Saburra);
                result.m_Humectacion = DataEncryptor.Decrypt(item.m_Humectacion);
                result.m_PulsoD = DataEncryptor.Decrypt(item.m_PulsoD);
                result.m_PulsoI = DataEncryptor.Decrypt(item.m_PulsoI);
                result.m_Sintomas = DataEncryptor.Decrypt(item.m_Sintomas);
                result.m_Fecha = item.m_Fecha;
                result.m_fkPaciente = item.m_fkPaciente;
                resultLista.Add(result);
            }
            return resultLista;
        }

        public List<CitasAcupunturaModel> ConsultaCitasAcupuntura(int pk)
        {
            return Select("select * from citasacupuntura where fkPaciente = " + pk.ToString());
        }

        public List<CitasAcupunturaModel> ConsultaCitasAcupunturabyId(int pk)
        {
            return Select("select * from citasacupuntura where idcitasacupuntura = " + pk.ToString());
        }


    }
}