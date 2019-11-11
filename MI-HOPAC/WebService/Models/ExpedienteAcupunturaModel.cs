using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ExpedienteAcupunturaModel
    {
        public int m_IdExpedienteAcupuntura { set; get; }
        public string m_Nombre              { set; get; }
        public int m_FkDoctor               { set; get; }

    }
}