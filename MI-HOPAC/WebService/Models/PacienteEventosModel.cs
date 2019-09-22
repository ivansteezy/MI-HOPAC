using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PacienteEventosModel
    {
        public int m_IdPacienteEventos { set; get; }
        public int m_FkEvento          { set; get; }
        public int m_Asistencia        { set; get; }
    }
}