using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ForoPrivadoPacienteModel
    {
        #region Propiedades
        public int m_IdCForoPrivado { set; get; }
        public string m_Texto { set; get; }
        public string m_Fecha { set; get; }
        public int fkPaciente { set; get; }
        public int fkDoctor { set; get; }

        #endregion


    }
}