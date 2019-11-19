using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CitasMovilModel
    {
        #region Propiedades

        public int m_IdCitas { get; set; }
        public DateTime m_Fecha { get; set; }
        public string m_Nombre { get; set; }
        public string m_Apellido { get; set; }
        public int m_fkDoctor { get; set; }
        public int m_Calificado { set; get; }

        #endregion

    }
}