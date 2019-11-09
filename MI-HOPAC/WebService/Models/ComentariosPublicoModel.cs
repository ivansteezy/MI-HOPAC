using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ComentariosPublicoModel
    {

        #region Propiedades
        public int m_IdComentariosPublico { set; get; }
        public string m_Texto { set; get; }
        public string m_Fecha { set; get; }
        public int m_fkPaciente { set; get; }
        public int m_FkForo { set; get; }

        #endregion

    }
}