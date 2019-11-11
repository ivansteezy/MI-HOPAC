using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CodigosModel
    {

        public int m_idCodigos { set; get; }
        public double m_Codigo { set; get; }
        public int m_fkDoctor { set; get; }
        public int m_fkReceta { set; get; }

    }
}