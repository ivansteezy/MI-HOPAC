using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class InventarioHomeopatiaModel
    {
        #region Propiedades
        public int m_IdInventarioHomeopatia { set; get; }
        public string m_Nombre              { set; get; }
        public double m_Potencia            { set; get; }
        public int m_Cantidad               { set; get; }
        public int m_FkDoctor               { set; get; }
        #endregion
    }
}