using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Configurations;

namespace WebService.Models
{
    public class NotasInformativasModel
    {
        
        public int m_IdNotas   { set; get; }
        public string m_Titulo { set; get; }
        public string m_Texto  { set; get; }
        public int m_FkDoctor  { set; get; }
    }
}