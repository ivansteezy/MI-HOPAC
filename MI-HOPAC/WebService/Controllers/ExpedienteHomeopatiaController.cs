using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class ExpedienteHomeopatiaController : DatabaseOperation<ExpedienteHomeopatiaModel>
    {
        public ExpedienteHomeopatiaModel EncriptarDatos(ExpedienteHomeopatiaModel cita)
        {
            ExpedienteHomeopatiaModel result = new ExpedienteHomeopatiaModel();

            result.m_IdExpHom = cita.m_IdExpHom;
            result.m_Nombre = DataEncryptor.Encrypt(cita.m_Nombre);
            result.m_Edad = cita.m_Edad;
            result.m_Sexo = cita.m_Sexo;
            result.m_EstadoCivil = cita.m_EstadoCivil;  
            result.m_Ocupacion = DataEncryptor.Encrypt(cita.m_Ocupacion);
            result.m_Domicilio = DataEncryptor.Encrypt(cita.m_Domicilio);
            result.m_Correo = DataEncryptor.Encrypt(cita.m_Correo);
            result.m_Telefono = DataEncryptor.Encrypt(cita.m_Telefono);
            result.m_Movil = DataEncryptor.Encrypt(cita.m_Movil);
            result.m_CiudadOrigen = DataEncryptor.Encrypt(cita.m_CiudadOrigen);
            result.m_CiudadReside = DataEncryptor.Encrypt(cita.m_CiudadReside);
            result.m_Religion = DataEncryptor.Encrypt(cita.m_Religion);
            result.m_Escolaridad = DataEncryptor.Encrypt(cita.m_Escolaridad);
            result.m_AntHeredo = DataEncryptor.Encrypt(cita.m_AntHeredo);
            result.m_AntPersonales = DataEncryptor.Encrypt(cita.m_AntPersonales);
            result.m_TA = DataEncryptor.Encrypt(cita.m_TA);
            result.m_FC = DataEncryptor.Encrypt(cita.m_FC);
            result.m_FR = DataEncryptor.Encrypt(cita.m_FR);
            result.m_Temp = DataEncryptor.Encrypt(cita.m_Temp);
            result.m_Peso = DataEncryptor.Encrypt(cita.m_Peso);
            result.m_Talla = DataEncryptor.Encrypt(cita.m_Talla);
            result.m_Menarca = DataEncryptor.Encrypt(cita.m_Menarca);
            result.m_G = DataEncryptor.Encrypt(cita.m_G);
            result.m_A = DataEncryptor.Encrypt(cita.m_A);
            result.m_P = DataEncryptor.Encrypt(cita.m_P);
            result.m_C = DataEncryptor.Encrypt(cita.m_C);
            result.m_Ritmo = DataEncryptor.Encrypt(cita.m_Ritmo);
            result.m_Dismenorrea = cita.m_Dismenorrea;
            result.m_F = DataEncryptor.Encrypt(cita.m_F);
            result.m_D = DataEncryptor.Encrypt(cita.m_D);
            result.m_C2 = DataEncryptor.Encrypt(cita.m_C2);
            result.m_FPP = DataEncryptor.Encrypt(cita.m_FPP);
            result.m_FUM = DataEncryptor.Encrypt(cita.m_FUM);
            result.m_FUP = DataEncryptor.Encrypt(cita.m_FUP);
            result.m_IVSA = DataEncryptor.Encrypt(cita.m_IVSA);
            result.m_Menopausia = DataEncryptor.Encrypt(cita.m_Menopausia);
            result.m_Metodo = DataEncryptor.Encrypt(cita.m_Metodo);
            result.m_Estudios = DataEncryptor.Encrypt(cita.m_Estudios);
            result.m_Motivo = DataEncryptor.Encrypt(cita.m_Motivo);
            result.m_fkDoctor = cita.m_fkDoctor;
            return result;
        }
       
        public void InsertarExpedienteHom(ExpedienteHomeopatiaModel expediente)
        {
            var res = EncriptarDatos(expediente);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into Exphomeopatia()  
                                values(Null, @Nombre, @Edad, @Sexo, @EstadoCivil, @Ocupacion, @Domicilio, @Correo, @Telefono, @Movil, @CiudadOrigen,
                                       @CiudadReside, @Religion, @Escolaridad, @AntHeredo, @AntPersonales, @TA, @FC, @FR, @Temp, 
                                       @Peso, @Talla, @Menarca, @G, @A, @P, @C, @Ritmo, @Dismenorrea, @F, @D, @C2, @FPP, @FUM, @FUP,
                                       @IVSA, @Menopausia, @Metodo, @Estudios, @Motivo, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@Nombre", res.m_Nombre));
            cmd.Parameters.Add(new MySqlParameter("@Edad", res.m_Edad));
            cmd.Parameters.Add(new MySqlParameter("@Sexo", res.m_Sexo));
            cmd.Parameters.Add(new MySqlParameter("@EstadoCivil", res.m_EstadoCivil));
            cmd.Parameters.Add(new MySqlParameter("@Ocupacion", res.m_Ocupacion));
            cmd.Parameters.Add(new MySqlParameter("@Domicilio", res.m_Domicilio));
            cmd.Parameters.Add(new MySqlParameter("@Correo", res.m_Correo));
            cmd.Parameters.Add(new MySqlParameter("@Telefono", res.m_Telefono));
            cmd.Parameters.Add(new MySqlParameter("@Movil", res.m_Movil));
            cmd.Parameters.Add(new MySqlParameter("@CiudadOrigen", res.m_CiudadOrigen));
            cmd.Parameters.Add(new MySqlParameter("@CiudadReside", res.m_CiudadReside));
            cmd.Parameters.Add(new MySqlParameter("@Religion", res.m_Religion));
            cmd.Parameters.Add(new MySqlParameter("@Escolaridad", res.m_Escolaridad));
            cmd.Parameters.Add(new MySqlParameter("@AntHeredo", res.m_AntHeredo));
            cmd.Parameters.Add(new MySqlParameter("@AntPersonales", res.m_AntPersonales));
            cmd.Parameters.Add(new MySqlParameter("@TA", res.m_TA));
            cmd.Parameters.Add(new MySqlParameter("@FC", res.m_FC));
            cmd.Parameters.Add(new MySqlParameter("@FR", res.m_FR));
            cmd.Parameters.Add(new MySqlParameter("@Temp", res.m_Temp));
            cmd.Parameters.Add(new MySqlParameter("@Peso", res.m_Peso));
            cmd.Parameters.Add(new MySqlParameter("@Talla", res.m_Talla));
            cmd.Parameters.Add(new MySqlParameter("@Menarca", res.m_Menarca));
            cmd.Parameters.Add(new MySqlParameter("@G", res.m_G));
            cmd.Parameters.Add(new MySqlParameter("@A", res.m_A));
            cmd.Parameters.Add(new MySqlParameter("@P", res.m_P));
            cmd.Parameters.Add(new MySqlParameter("@C", res.m_C));
            cmd.Parameters.Add(new MySqlParameter("@Ritmo", res.m_Ritmo));
            cmd.Parameters.Add(new MySqlParameter("@Dismenorrea", res.m_Dismenorrea));
            cmd.Parameters.Add(new MySqlParameter("@F", res.m_F));
            cmd.Parameters.Add(new MySqlParameter("@D", res.m_D));
            cmd.Parameters.Add(new MySqlParameter("@C2", res.m_C2));
            cmd.Parameters.Add(new MySqlParameter("@FPP", res.m_FPP));
            cmd.Parameters.Add(new MySqlParameter("@FUM", res.m_FUM));
            cmd.Parameters.Add(new MySqlParameter("@FUP", res.m_FUP));
            cmd.Parameters.Add(new MySqlParameter("@IVSA", res.m_IVSA));
            cmd.Parameters.Add(new MySqlParameter("@Menopausia", res.m_Menopausia));
            cmd.Parameters.Add(new MySqlParameter("@Metodo", res.m_Metodo));
            cmd.Parameters.Add(new MySqlParameter("@Estudios", res.m_Estudios));
            cmd.Parameters.Add(new MySqlParameter("@Motivo", res.m_Motivo));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", res.m_fkDoctor));
            Insert(cmd);
        }

        public List<ExpedienteHomeopatiaModel> ConsultaExpedienteHomeopatia(int pk)
        {
            return Select("select * from Exphomeopatia where fkDoctor = " + pk.ToString());
        }

        public List<ExpedienteHomeopatiaModel> ConsultaCitasHomeopaticasbyId(int pk)
        {
            return Select("select * from Exphomeopatia where IdExpHom = " + pk.ToString());
        }

        public List<ExpedienteHomeopatiaModel> DecryptConsultaExpedienteHomeopatia(int pk)
        {
            List<ExpedienteHomeopatiaModel> resultLista = new List<ExpedienteHomeopatiaModel>();
            var lista = ConsultaExpedienteHomeopatia(pk);

            foreach (var item in lista)
            {
                var result = new ExpedienteHomeopatiaModel();

                result.m_IdExpHom = item.m_IdExpHom;
                result.m_Nombre = DataEncryptor.Decrypt(item.m_Nombre);
                result.m_Edad = item.m_Edad;
                result.m_Sexo = item.m_Sexo;
                result.m_EstadoCivil = item.m_EstadoCivil;
                result.m_Ocupacion = DataEncryptor.Decrypt(item.m_Ocupacion);
                result.m_Domicilio = DataEncryptor.Decrypt(item.m_Domicilio);
                result.m_Correo = DataEncryptor.Decrypt(item.m_Correo);
                result.m_Telefono = DataEncryptor.Decrypt(item.m_Telefono);
                result.m_Movil = DataEncryptor.Decrypt(item.m_Movil);
                result.m_CiudadOrigen = DataEncryptor.Decrypt(item.m_CiudadOrigen);
                result.m_CiudadReside = DataEncryptor.Decrypt(item.m_CiudadReside);
                result.m_Religion = DataEncryptor.Decrypt(item.m_Religion);
                result.m_Escolaridad = DataEncryptor.Decrypt(item.m_Escolaridad);
                result.m_AntHeredo = DataEncryptor.Decrypt(item.m_AntHeredo);
                result.m_AntPersonales = DataEncryptor.Decrypt(item.m_AntPersonales);
                result.m_TA = DataEncryptor.Decrypt(item.m_TA);
                result.m_FC = DataEncryptor.Decrypt(item.m_FC);
                result.m_FR = DataEncryptor.Decrypt(item.m_FR);
                result.m_Temp = DataEncryptor.Decrypt(item.m_Temp);
                result.m_Peso = DataEncryptor.Decrypt(item.m_Peso);
                result.m_Talla = DataEncryptor.Decrypt(item.m_Talla);
                result.m_Menarca = DataEncryptor.Decrypt(item.m_Menarca);
                result.m_G = DataEncryptor.Decrypt(item.m_G);
                result.m_A = DataEncryptor.Decrypt(item.m_A);
                result.m_P = DataEncryptor.Decrypt(item.m_P);
                result.m_C = DataEncryptor.Decrypt(item.m_C);
                result.m_Ritmo = DataEncryptor.Decrypt(item.m_Ritmo);
                result.m_Dismenorrea = item.m_Dismenorrea;
                result.m_F = DataEncryptor.Decrypt(item.m_F);
                result.m_D = DataEncryptor.Decrypt(item.m_D);
                result.m_C2 = DataEncryptor.Decrypt(item.m_C2);
                result.m_FPP = DataEncryptor.Decrypt(item.m_FPP);
                result.m_FUM = DataEncryptor.Decrypt(item.m_FUM);
                result.m_FUP = DataEncryptor.Decrypt(item.m_FUP);
                result.m_IVSA = DataEncryptor.Decrypt(item.m_IVSA);
                result.m_Menopausia = DataEncryptor.Decrypt(item.m_Menopausia);
                result.m_Metodo = DataEncryptor.Decrypt(item.m_Metodo);
                result.m_Estudios = DataEncryptor.Decrypt(item.m_Estudios);
                result.m_Motivo = DataEncryptor.Decrypt(item.m_Motivo);
                result.m_fkDoctor = item.m_fkDoctor;

                resultLista.Add(result);
            }
            return resultLista;
        }

        public List<ExpedienteHomeopatiaModel> DecryptCitasHomeopaticasbyId(int pk)
        {
            List<ExpedienteHomeopatiaModel> resultLista = new List<ExpedienteHomeopatiaModel>();
            var lista = ConsultaCitasHomeopaticasbyId(pk);

            foreach(var item in lista)
            {
                var result = new ExpedienteHomeopatiaModel();

                result.m_IdExpHom = item.m_IdExpHom;
                result.m_Nombre = DataEncryptor.Decrypt(item.m_Nombre);
                result.m_Edad = item.m_Edad;
                result.m_Sexo = item.m_Sexo;
                result.m_EstadoCivil = item.m_EstadoCivil;
                result.m_Ocupacion = DataEncryptor.Decrypt(item.m_Ocupacion);
                result.m_Domicilio = DataEncryptor.Decrypt(item.m_Domicilio);
                result.m_Correo = DataEncryptor.Decrypt(item.m_Correo);
                result.m_Telefono = DataEncryptor.Decrypt(item.m_Telefono);
                result.m_Movil = DataEncryptor.Decrypt(item.m_Movil);
                result.m_CiudadOrigen = DataEncryptor.Decrypt(item.m_CiudadOrigen);
                result.m_CiudadReside = DataEncryptor.Decrypt(item.m_CiudadReside);
                result.m_Religion = DataEncryptor.Decrypt(item.m_Religion);
                result.m_Escolaridad = DataEncryptor.Decrypt(item.m_Escolaridad);
                result.m_AntHeredo = DataEncryptor.Decrypt(item.m_AntHeredo);
                result.m_AntPersonales = DataEncryptor.Decrypt(item.m_AntPersonales);
                result.m_TA = DataEncryptor.Decrypt(item.m_TA);
                result.m_FC = DataEncryptor.Decrypt(item.m_FC);
                result.m_FR = DataEncryptor.Decrypt(item.m_FR);
                result.m_Temp = DataEncryptor.Decrypt(item.m_Temp);
                result.m_Peso = DataEncryptor.Decrypt(item.m_Peso);
                result.m_Talla = DataEncryptor.Decrypt(item.m_Talla);
                result.m_Menarca = DataEncryptor.Decrypt(item.m_Menarca);
                result.m_G = DataEncryptor.Decrypt(item.m_G);
                result.m_A = DataEncryptor.Decrypt(item.m_A);
                result.m_P = DataEncryptor.Decrypt(item.m_P);
                result.m_C = DataEncryptor.Decrypt(item.m_C);
                result.m_Ritmo = DataEncryptor.Decrypt(item.m_Ritmo);
                result.m_Dismenorrea = item.m_Dismenorrea;
                result.m_F = DataEncryptor.Decrypt(item.m_F);
                result.m_D = DataEncryptor.Decrypt(item.m_D);
                result.m_C2 = DataEncryptor.Decrypt(item.m_C2);
                result.m_FPP = DataEncryptor.Decrypt(item.m_FPP);
                result.m_FUM = DataEncryptor.Decrypt(item.m_FUM);
                result.m_FUP = DataEncryptor.Decrypt(item.m_FUP);
                result.m_IVSA = DataEncryptor.Decrypt(item.m_IVSA);
                result.m_Menopausia = DataEncryptor.Decrypt(item.m_Menopausia);
                result.m_Metodo = DataEncryptor.Decrypt(item.m_Metodo);
                result.m_Estudios = DataEncryptor.Decrypt(item.m_Estudios);
                result.m_Motivo = DataEncryptor.Decrypt(item.m_Motivo);
                result.m_fkDoctor = item.m_fkDoctor;

                resultLista.Add(result);
            }
            return resultLista;
        }
    }
}