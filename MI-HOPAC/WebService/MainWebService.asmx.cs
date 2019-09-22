using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.Models;
using WebService.Controllers;
using WebService.Configurations;

namespace WebService
{
    /// <summary>
    /// Descripción breve de MainWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MainWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        /// <summary>
        /// Metodo que realzia una consulta a la tabla de doctores.
        /// </summary>
        /// <param name="pk">Primary key de la tabla doctores</param>
        /// <returns>Una lista de DoctoresModel</returns>
        [WebMethod]
        public List<DoctoresModel> getDoctores(int pk)
        {
            var controlador = new DoctoresControllers();
            return controlador.QueryDoctores(pk);
        }

        [WebMethod]
        public void Caller()
        {
            DatabaseOperation<NotasInformativasModel> db = new DatabaseOperation<NotasInformativasModel>();
            List<NotasInformativasModel> notasList = db.Select("select * from notasinfo");
        }
    }
}
