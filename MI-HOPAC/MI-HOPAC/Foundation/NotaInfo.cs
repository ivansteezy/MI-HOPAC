using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_HOPAC.Foundation
{
    class NotaInfo
    {

        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }

        public NotaInfo(int id, string titulo, string texto, string link)
        {
            Titulo = titulo;
            Texto = texto;
            Id = id;
            Link = link;
        }


    }
}
