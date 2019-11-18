using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;
using WebService.Models;
using MySql.Data.MySqlClient;

namespace WebService.Controllers
{
    public class InventarioHomeopatiaController : DatabaseOperation<InventarioHomeopatiaModel>
    {
        
        public List<InventarioHomeopatiaModel> ConsultaInventarioHomeopatia(int pk)
        {
            return Select("select * from invhomeopatia where fkDoctor = " + pk.ToString());
        }

        public List<InventarioHomeopatiaModel> ConsultaMayorInventarioHomeopatia(int pk)
        {
            return Select("select * from invhomeopatia where Cantidad > 0 AND fkDoctor = " + pk.ToString());
        }

        public void EliminarInventarioHomeopatia(int pk)
        {
            Delete("delete from invhomeopatia where idInvHom = " + pk.ToString());
        }

        public void InsertarInvetarioHomeopatia(string nombre, int potencia, int cantidad, int fkDoctor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"insert into invhomeopatia(Nombre, Potencia, Cantidad, fkDoctor) 
                                values(@nombre, @potencia, @cantidad, @fkDoctor)";

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@potencia", potencia));
            cmd.Parameters.Add(new MySqlParameter("@cantidad", cantidad));
            cmd.Parameters.Add(new MySqlParameter("@fkDoctor", fkDoctor));

            Insert(cmd);
        }

        public void ActualizarInventarioHomeopatia(string nombre, int potencia, int cantidad, int pk)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"update invhomeopatia set Nombre = @nombre, Potencia = @potencia, Cantidad = @cantidad where idInvHom = " + pk.ToString();

            cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new MySqlParameter("@potencia", potencia));
            cmd.Parameters.Add(new MySqlParameter("@cantidad", cantidad));

            Update(cmd);
        }


        public void RestarInventario(List<int> pks)
        {
            foreach (int i in pks)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"UPDATE invHomeopatia
                                SET Cantidad = (Cantidad - 1) 
                                WHERE idInvHom = " + i.ToString();
                Update(cmd);
            }
        }


        public List<InventarioHomeopatiaModel> CheckInventarioHomeopatico(int pk)
        {
            return Select("select * from invHomeopatia where fkDoctor = " + pk.ToString() + " AND Cantidad < 9 ");
        }



    }
}