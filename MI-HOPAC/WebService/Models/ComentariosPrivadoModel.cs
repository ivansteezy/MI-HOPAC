using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ComentariosPrivadoModel
    {

        #region Propiedades
        public int m_IdComentariosPrivado { set; get; }
        public string m_Texto { set; get; }
        public string m_Fecha { set; get; }
        public int m_TipoDeCuenta { set; get; }
        public int m_FkForo { set; get; }

        #endregion


    }
}