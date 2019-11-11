using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PacienteEventosModel
    {
        #region Propiedades
        public int m_IdEventos { get; set; }
        public string m_Nombre { get; set; }
        public DateTime m_Fecha { get; set; }
        public string m_Ubicacion { get; set; }
        public string m_Guia { get; set; }
        public int m_fkDoctor { get; set; }
        public int m_Asistencia { get; set; }

        #endregion
    }
}