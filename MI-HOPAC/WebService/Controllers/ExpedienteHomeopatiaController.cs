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
        public List<ExpedienteHomeopatiaModel> ConsultaInventarioAcupuntura(int pk)
        {
            return Select("select * from Exphomeopatia where fkDoctor = " + pk.ToString());
        }
       
        public void InsertarExpedienteHom(ExpedienteHomeopatiaModel expediente)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into Exphomeopatia()  
                                values(Null, @Nombre, @Edad, @Sexo, @EstadoCivil, @Ocupacion, @Domicilio, @Correo, @Telefono, @Movil, @CiudadOrigen,
                                       @CiudadReside, @Religion, @Escolaridad, @AntHeredo, @AntPersonales, @TA, @FC, @FR, @Temp, 
                                       @Peso, @Talla, @Menarca, @G, @A, @P, @C, @Ritmo, @Dismenorrea, @F, @D, @C2, @FPP, @FUM, @FUP,
                                       @IVSA, @Menopausia, @Metodo, @Estudios, @Motivo, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@Nombre", expediente.m_Nombre));
            cmd.Parameters.Add(new MySqlParameter("@Edad", expediente.m_Edad));
            cmd.Parameters.Add(new MySqlParameter("@Sexo", expediente.m_Sexo));
            cmd.Parameters.Add(new MySqlParameter("@EstadoCivil", expediente.m_EstadoCivil));
            cmd.Parameters.Add(new MySqlParameter("@Ocupacion", expediente.m_Ocupacion));
            cmd.Parameters.Add(new MySqlParameter("@Domicilio", expediente.m_Domicilio));
            cmd.Parameters.Add(new MySqlParameter("@Correo", expediente.m_Correo));
            cmd.Parameters.Add(new MySqlParameter("@Telefono", expediente.m_Telefono));
            cmd.Parameters.Add(new MySqlParameter("@Movil", expediente.m_Movil));
            cmd.Parameters.Add(new MySqlParameter("@CiudadOrigen", expediente.m_CiudadOrigen));
            cmd.Parameters.Add(new MySqlParameter("@CiudadReside", expediente.m_CiudadReside));
            cmd.Parameters.Add(new MySqlParameter("@Religion", expediente.m_Religion));
            cmd.Parameters.Add(new MySqlParameter("@Escolaridad", expediente.m_Escolaridad));
            cmd.Parameters.Add(new MySqlParameter("@AntHeredo", expediente.m_AntHeredo));
            cmd.Parameters.Add(new MySqlParameter("@AntPersonales", expediente.m_AntPersonales));
            cmd.Parameters.Add(new MySqlParameter("@TA", expediente.m_TA));
            cmd.Parameters.Add(new MySqlParameter("@FC", expediente.m_FC));
            cmd.Parameters.Add(new MySqlParameter("@FR", expediente.m_FR));
            cmd.Parameters.Add(new MySqlParameter("@Temp", expediente.m_Temp));
            cmd.Parameters.Add(new MySqlParameter("@Peso", expediente.m_Peso));
            cmd.Parameters.Add(new MySqlParameter("@Talla", expediente.m_Talla));
            cmd.Parameters.Add(new MySqlParameter("@Menarca", expediente.m_Menarca));
            cmd.Parameters.Add(new MySqlParameter("@G", expediente.m_G));
            cmd.Parameters.Add(new MySqlParameter("@A", expediente.m_A));
            cmd.Parameters.Add(new MySqlParameter("@P", expediente.m_P));
            cmd.Parameters.Add(new MySqlParameter("@C", expediente.m_C));
            cmd.Parameters.Add(new MySqlParameter("@Ritmo", expediente.m_Ritmo));
            cmd.Parameters.Add(new MySqlParameter("@Dismenorrea", expediente.m_Dismenorrea));
            cmd.Parameters.Add(new MySqlParameter("@F", expediente.m_F));
            cmd.Parameters.Add(new MySqlParameter("@D", expediente.m_D));
            cmd.Parameters.Add(new MySqlParameter("@C2", expediente.m_C2));
            cmd.Parameters.Add(new MySqlParameter("@FPP", expediente.m_FPP));
            cmd.Parameters.Add(new MySqlParameter("@FUM", expediente.m_FUM));
            cmd.Parameters.Add(new MySqlParameter("@FUP", expediente.m_FUP));
            cmd.Parameters.Add(new MySqlParameter("@IVSA", expediente.m_IVSA));
            cmd.Parameters.Add(new MySqlParameter("@Menopausia", expediente.m_Menopausia));
            cmd.Parameters.Add(new MySqlParameter("@Metodo", expediente.m_Metodo));
            cmd.Parameters.Add(new MySqlParameter("@Estudios", expediente.m_Estudios));
            cmd.Parameters.Add(new MySqlParameter("@Motivo", expediente.m_Motivo));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", expediente.m_fkDoctor));


            Insert(cmd);
        }


    }
}