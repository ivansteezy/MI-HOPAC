using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class InventarioAcupunturaModel
    {
        public int m_IdInventarioAcupuntura { set; get; }
        public string m_Nombre              { set; get; }
        public int m_Cantidad               { set; get; }
        public int m_FkDoctor               { set; get; }
    }
}