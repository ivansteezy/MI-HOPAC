using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class HorariosModel
    {
        public int m_IdHorario  { set; get; }
        public DateTime m_HoraI { set; get; }
        public DateTime m_HoraF { set; get; }
        public int m_FkDia      { set; get; }
        public int m_FkDoctor   { set; get; }
    }
}