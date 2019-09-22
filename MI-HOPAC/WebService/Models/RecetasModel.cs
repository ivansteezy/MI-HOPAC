using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class RecetasModel
    {
        public int m_IdReceta           { set; get; }
        public string m_Nombre          { set; get; }
        public DateTime m_FechaCreacion { set; get; }
        public int m_Clave              { set; get; }
    }
}