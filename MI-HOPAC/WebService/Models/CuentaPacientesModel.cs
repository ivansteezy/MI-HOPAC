using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CuentaPacientesModel
    {
        #region Propiedades
        public int m_IdCuenta     { set; get; }
        public string m_Correo    { set; get; }
        public string m_Password  { set; get; }
        public int m_FkPaciente   { set; get; }
        #endregion
    }
}