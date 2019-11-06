using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PacienteEventosModel
    {
        #region Propiedades
        public int m_IdPacienteEventos { set; get; }
        public int m_FkPaciente { set; get; }
        public int m_FkEvento          { set; get; }
        public int m_Asistencia        { set; get; }
        #endregion
    }
}