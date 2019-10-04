using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CitasModel
    {
        #region Propiedades
        public int m_IdCitas     { set; get; }
        public DateTime m_Fecha  { set; get; }
        public int m_FkPaciente  { set; get; }
        public int m_FkDoctor    { set; get; }
        #endregion
    }
}