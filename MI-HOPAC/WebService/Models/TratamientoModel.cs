using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class TratamientoModel
    {

        #region Propiedades
        public int m_IdTratamiento { set; get; }
        public DateTime m_Fecha { set; get; }
        public int m_Calificaion { set; get; }
        public int m_FkPregunta { set; get; }
        public int m_FkDoctor { set; get; }
        public int m_FkPaciente { set; get; }
        public int m_FkReceta { set; get; }
        #endregion

    }
}