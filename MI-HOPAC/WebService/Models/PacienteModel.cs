using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PacienteModel
    {
        public int m_IdPaciente         { set; get; }
        public string m_Nombre          { set; get; }
        public int m_FkDoctorHomeopatia { set; get; }
        public int m_FkDoctorAcupuntura { set; get; }
        public int m_FkReceta           { set; get; }
    }
}