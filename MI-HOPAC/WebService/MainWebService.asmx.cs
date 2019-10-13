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

        #region Citas
        [WebMethod]
        public List<CitasModel> GetCitas(int pk)
        {
            var controlador = new CitasController();
            return controlador.ConsultaCitas(pk);
        }

        [WebMethod]
        public void DeleteCitas(int pk)
        {
            var controlador = new CitasController();
            controlador.EliminarCitas(pk);
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
        public void DeleteCuentaDoctores(int pk)
        {
            var controlador = new CuentaDoctoresController();
            controlador.EliminarCuentadoctores(pk);
        }
        #endregion

        #region CuentaPacientes
        [WebMethod]
        public List<CuentaPacientesModel> GetCuentaPacientes(int pk)
        {
            var controlador = new CuentaPacientesController();
            return controlador.ConsultaCuentaPacientes(pk);
        }

        [WebMethod]
        public void DeleteCuentaPacientes(int pk)
        {
            var controlador = new CuentaPacientesController();
            controlador.EliminarCuentaPacientes(pk);
        }
        #endregion

        #region Dias
        [WebMethod]
        public List<DiasModel> GetDias(int pk)
        {
            var controlador = new DiasController();
            return controlador.ConsultaDias(pk);
        }
        #endregion

        #region Doctores
        [WebMethod]
        public List<DoctoresModel> GetDoctores(int pk)
        {
            var controlador = new DoctoresControllers();
            return controlador.ConsultaDoctores(pk);
        }

        public void DeleteDoctores(int pk)
        {
            var controlador = new DoctoresControllers();
            controlador.EliminarDoctores(pk);
        }
        #endregion

        #region Eventos
        [WebMethod]
        public List<EventosModel> GetEventos()
        {
            var controlador = new EventosController();
            return controlador.ConsultaEvento();
        }

        [WebMethod]
        public List<EventosModel> GetEventosByName(string name)
        {
            var controlador = new EventosController();
            return controlador.ConsultaEvento(name);
        }

        [WebMethod]
        public void DeleteEventos(int pk)
        {
            var controlador = new EventosController();
            controlador.EliminarEvento(pk);
        }

        [WebMethod]
        public void InsertEventos(string nombre, DateTime fecha, string ubicacion, string guia, int fkDoctor)
        {
            var controlador = new EventosController();
            controlador.InsertarEvento(nombre, fecha, ubicacion, guia, fkDoctor);
        }

        [WebMethod]
        public void UpdateEventos(int pk, string nombre)
        {
            var controlador = new EventosController();
            controlador.ActualizarEvento(pk, nombre);
        }
        #endregion
    }
}
