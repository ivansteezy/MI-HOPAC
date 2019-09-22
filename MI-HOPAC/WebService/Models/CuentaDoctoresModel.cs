using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CuentaDoctoresModel
    {
        public int m_IdCuentaDoctores { get; set; }
        public string m_Correo        { set; get; }
        public string m_Password      { set; get; }
        public string m_FkDoctor      { set; get; }
    }
}