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
        public List<CuentaDoctoresModel> GetCuentaDoctores(string correo, string contrasena)
        {
            var controlador = new CuentaDoctoresController();
            return controlador.ConsultaCuentaDoctores(correo, contrasena);
        }

        [WebMethod]
        public List<CuentaDoctoresModel> GetCuentaDoctoresById(int pk)
        {
            var controlador = new CuentaDoctoresController();
            return controlador.ConsultaCuentaDoctoresById(pk);
        }

        [WebMethod]
        public void DeleteCuentaDoctores(int pk)
        {
            var controlador = new CuentaDoctoresController();
            controlador.EliminarCuentadoctores(pk);
        }

        [WebMethod]
        public int InsertCuentaDoctores(string nombre, string appellidos, string Correo, string Contrasena, int Medicina)
        {
            var controlador = new CuentaDoctoresController();
            var res = controlador.InsertaCuentaDoctor(nombre, appellidos, Correo, Contrasena, Medicina);
            return res;
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

        [WebMethod]
        public void DeleteDoctores(int pk)
        {
            var controlador = new DoctoresControllers();
            controlador.EliminarDoctores(pk);
        }

        [WebMethod]
        public void UpdateDoctres(int pk, string ubicacion = "", long cedula = 0)
        {
            var controlador = new DoctoresControllers();
            controlador.ActualizarDoctores(pk, ubicacion, cedula);
        }

        #endregion

        #region Eventos
        [WebMethod]
        public List<EventosModel> GetEventos(int pk)
        {
            var controlador = new EventosController();
            return controlador.ConsultaEvento(pk);
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

        #region NotasDigitales
        [WebMethod]
        public List<NotasDigitalesModel> GetNotasDig(int fk)
        {
            var controlador = new NotasDigitalesController();
            return controlador.ConsultaNotasDig(fk);
        }

        [WebMethod]
        public void DeleteNotaDig(int pk)
        {
            var controlador = new NotasDigitalesController();
            controlador.EliminarNotaDig(pk);
        }

        [WebMethod]
        public void InsertNotaDig(string texto, string color, int fkDoctor)
        {
            var controlador = new NotasDigitalesController();
            controlador.InsertarNotaDig(texto, color, fkDoctor);
        }

        
        [WebMethod]
        public void UpdateNotaDig(int pk, string texto, string color)
        {
            var controlador = new NotasDigitalesController();
            controlador.ActualizarEvento(pk, texto, color);
        }
        #endregion

    }
}
