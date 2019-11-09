using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    class ComentarioPrivado
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Color { get; set; }

        public ComentarioPrivado(int id, string texto, string fecha, string nombre, string color)
        {
            Id = id;
            Mensaje = texto;
            Fecha = fecha;
            Nombre = nombre;
            Color = color;
        }

    }
}
