using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CitasModel
    {
        public int m_IdPacientes { set; get; }
        public DateTime m_Fechas { set; get; }
        public int m_FkPaciente  { set; get; }
        public int m_FkDoctor    { set; get; }
    }
}