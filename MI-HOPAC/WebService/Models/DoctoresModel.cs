using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class DoctoresModel
    {
        #region Propiedades
        public int m_Pk                 { set; get; }
        public string m_Nombre          { set; get; }
        public string m_Apellidos { set; get; }
        public int m_Cedula             { set; get; }
        public string m_Ubicacion       { set; get; }
        #endregion
    }
}