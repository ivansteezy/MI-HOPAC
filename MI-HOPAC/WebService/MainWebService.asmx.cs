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
        
        [WebMethod]
        public List<DoctoresModel> Caller()
        {
            DatabaseOperation<DoctoresModel> db = new DatabaseOperation<DoctoresModel>();
            List<DoctoresModel> notasList = db.Select("select * from doctores");
            return notasList;
        }

        #region Citas
        [WebMethod]
        public List<CitasModel> GetCitas(int pk)
        {
            var controlador = new CitasController();
            return controlador.ConsultaCitas(pk);
        }
        #endregion

        #region CuentaDoctores
        [WebMethod]
        public List<CuentaDoctoresModel> GetCuentaDoctores(int pk)
        {
            var controlador = new CuentaDoctoresController();
            return controlador.ConsultaCuentaDoctores(pk);
        }

        [WebMethod]
        public void DeleteDoctores(int pk)
        {
            var controlador = new CuentaDoctoresController();
            controlador.EliminarCuentadoctores(pk);
        }
        #endregion
    }
}
