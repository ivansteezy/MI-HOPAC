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
        public int m_Medicamento  { set; get; }
        public int m_Gotas        { set; get; }
        public int m_Frencuencia  { set; get; }
        public int m_FechaI       { set; get; }
        public int m_FechaF       { set; get; }
        public int m_FkReceta     { set; get; }
        #endregion
    }
}