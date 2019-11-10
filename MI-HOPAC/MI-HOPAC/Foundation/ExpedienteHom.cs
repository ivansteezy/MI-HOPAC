using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    class ExpedienteHom
    {
        public int Id { set; get; }
        public string Nombre { set; get; }


        public ExpedienteHom(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

    }
}
