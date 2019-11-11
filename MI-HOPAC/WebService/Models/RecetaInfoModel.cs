using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class RecetaInfoModel
    {
        #region Propiedades
        public int m_IdRecetaInfo { set; get; }
        public string m_Medicamento  { set; get; }
        public int m_Gotas        { set; get; }
        public string m_Frencuencia  { set; get; }
        public DateTime m_FechaI       { set; get; }
        public DateTime m_FechaF       { set; get; }
        public int m_FkReceta     { set; get; }
        #endregion
    }

}