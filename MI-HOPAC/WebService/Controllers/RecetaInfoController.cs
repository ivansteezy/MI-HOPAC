using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class RecetaInfoController : DatabaseOperation<RecetaInfoModel>
    {
        public void InsertarRecetaInfo(List<RecetaInfoModel> receta)
        {
            foreach(RecetaInfoModel medi in receta)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"insert into recetainfo() 
                                values(Null, @Medicamento, @Gotas, @Frecuencia, @FechaI, @FechaF, @fkReceta)";

                cmd.Parameters.Add(new MySqlParameter("@Medicamento", medi.m_Medicamento));
                cmd.Parameters.Add(new MySqlParameter("@Gotas", medi.m_Gotas));
                cmd.Parameters.Add(new MySqlParameter("@Frecuencia", medi.m_Frencuencia));
                cmd.Parameters.Add(new MySqlParameter("@FechaI", medi.m_FechaI));
                cmd.Parameters.Add(new MySqlParameter("@FechaF", medi.m_FechaF));
                cmd.Parameters.Add(new MySqlParameter("@fkReceta", medi.m_FkReceta));

                Insert(cmd);
            }
        }


        

        public List<RecetaInfoModel> ConsultaReceta(int fkReceta)
        {
            return Select("select * from recetainfo where fkReceta = " + fkReceta.ToString());
        }


    }
}