using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class InventarioAcupunturaController : DatabaseOperation<InventarioAcupunturaModel>
    {
        public List<InventarioAcupunturaModel> ConsultaInventarioAcupuntura(int pk)
        {
            return Select("select * from invacupuntura where fkDoctor = " + pk.ToString());
        }

        public void EliminarInventarioAcupuntura(int pk)
        {
            Delete("delete from invacupuntura where idInvAcu = " + pk.ToString());
        }

        public void InsertarInvetarioAcupuntura(string nombre, int cantidad, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into invacupuntura(Nombre, Cantidad, fkDoctor) 
                                values(@nombre, @cantidad, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }

        public void ActualizarInventarioAcupuntura(string nombre, int cantidad, int pk)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update invacupuntura set Nombre = @nombre, Cantidad = @cantidad where idInvAcu = " + pk.ToString();

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@cantidad", cantidad));

            Update(cmd);
        }

        public void RestarInventario(List<AcupunturaPair> pks)
        {
            foreach (var i in pks)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"UPDATE invAcupuntura
                                SET Cantidad = (Cantidad - " + i.Cantidad.ToString() +")"+ 
                                "WHERE IdInvAcu = " + i.Id.ToString();
                Update(cmd);
            }
        }

        public List<InventarioAcupunturaModel> ChecInventarioAcupuntura(int pk)
        {
            return Select("select * from InvAcupuntura where fkDoctor = " + pk.ToString() + " AND Cantidad < 16 ");
        }


        

    }
}