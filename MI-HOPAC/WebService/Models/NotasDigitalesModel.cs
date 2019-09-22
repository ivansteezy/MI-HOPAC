using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class NotasDigitalesModel
    {
        public int m_IdNota   { set; get; }
        public string Text    { set; get; }
        public int m_FkDoctor { set; get; }
    }
}