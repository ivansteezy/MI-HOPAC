using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    class InventarioHomeopatica
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Potencia { get; set; }
        public int Cantidad { get; set; }
        public int FkDoctor { get; set; }

        public InventarioHomeopatica(int id, string nombre, double potencia, int cantidad, int fkDoctor)
        {
            Id = id;
            Nombre = nombre;
            Potencia = potencia;
            Cantidad = cantidad;
            FkDoctor = fkDoctor;
        }



    }
}
