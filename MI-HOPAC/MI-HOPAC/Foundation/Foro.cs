using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    class Foro
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }

        public Foro(int id, string texto, string nombre, string fecha)
        {
            Id = id;
            Texto = texto;
            Nombre = nombre;
            Fecha = fecha;

        }

    }
}
