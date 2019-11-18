using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    public class RecetaInfoSection
    {
        public int Id{ set; get; }
        public DateTime FechaInicio { set; get; }
        public DateTime FechaFinal { set; get; }
        public int FkReceta{ set; get; }
        public int Frecuencia { set; get; }
        public string Medicamento { set; get; }
        public int Gotas { set; get; }
        public int Alarmas { set; get; }
    }
}
