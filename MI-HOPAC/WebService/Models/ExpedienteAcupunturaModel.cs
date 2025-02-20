﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ExpedienteAcupunturaModel
    {
        #region Propiedades
        public int m_IdExpedienteAcupuntura { set; get; }
        public string m_Nombre              { set; get; }
        public DateTime m_Fecha             { set; get; }
        public string m_Shen                { set; get; }
        public string m_Color               { set; get; }
        public string m_Tonicidad           { set; get; }
        public string m_Longitud            { set; get; }
        public string m_Grietas             { set; get; }
        public string m_Saburra             { set; get; }
        public string m_Humectacion         { set; get; }
        public string m_PulsoD              { set; get; }
        public string m_PulsoI              { set; get; }

        #endregion
    }
}