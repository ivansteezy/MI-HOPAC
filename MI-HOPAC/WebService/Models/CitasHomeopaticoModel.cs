using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CitasHomeopaticoModel
    {

        public int m_idcitasaHomeopatia { set; get; }
        public string m_Sintomas { set; get; }
        public string m_Repertorizacion { set; get; }
        public string m_Fecha { set; get; }
        public int m_FkPaciente { set; get; }

    }
}