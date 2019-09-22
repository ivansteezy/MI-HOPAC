using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class EventosModel
    {
        public int m_IdEventos    { get; set; }
        public string m_Nombre    { get; set; }
        public DateTime m_Fecha   { get; set; }
        public string m_Ubicacion { get; set; }
        public string m_Guia      { get; set; }
    }
}