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
        public void InsertarRecetaInfo(RecetaInfoModel receta)
        {
            int alarma = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into recetainfo() 
                            values(Null, @Medicamento, @Gotas, @Frecuencia, @FechaI, @FechaF, @Alarmas, @fkReceta)";

            cmd.Parameters.Add(new MySqlParameter("@Medicamento", receta.m_Medicamento));
            cmd.Parameters.Add(new MySqlParameter("@Gotas", receta.m_Gotas));
            cmd.Parameters.Add(new MySqlParameter("@Frecuencia", receta.m_Frencuencia));
            cmd.Parameters.Add(new MySqlParameter("@FechaI", receta.m_FechaI));
            cmd.Parameters.Add(new MySqlParameter("@FechaF", receta.m_FechaF));
            cmd.Parameters.Add(new MySqlParameter("@Alarmas", alarma));
            cmd.Parameters.Add(new MySqlParameter("@fkReceta", receta.m_FkReceta));

            Insert(cmd);
        }


        

        public List<RecetaInfoModel> ConsultaReceta(int fkReceta)
        {
            return Select("select * from recetainfo where fkReceta = " + fkReceta.ToString());
        }


        public void UpdateReceta(int FkRecetaInfo, int Alarma)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update recetainfo set Alarmas = @Alarmas where idRecetaInfo = " + FkRecetaInfo.ToString();

            cmd.Parameters.Add(new MySqlParameter("@Alarmas", Alarma));

            Update(cmd);
        }


    }
}