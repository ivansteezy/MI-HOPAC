using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ExpedienteHomeopatiaModel
    {
        #region Propiedades
        public int      m_IdExpHom         { set; get; }
        public string   m_Nombre        { set; get; }
        public          DateTime m_Edad        { set; get; }
        public int      m_Sexo             { set; get; }
        public int      m_EstadoCivil      { set; get; }
        public string   m_Ocupacion     { set; get; }
        public string   m_Domicilio     { set; get; }
        public string   m_Correo        { set; get; }
        public string   m_Telefono      { set; get; }
        public string   m_Movil         { set; get; }
        public string   m_CiudadOrigen  { set; get; }
        public string   m_CiudadReside  { set; get; }
        public string   m_Religion      { set; get; }
        public string   m_Escolaridad   { set; get; }
        public string   m_AntHeredo     { set; get; }
        public string   m_AntPersonales { set; get; }
        public string   m_TA            { set; get; }
        public string   m_FC            { set; get; }
        public string   m_FR            { set; get; }
        public string   m_Temp          { set; get; }
        public string   m_Peso          { set; get; }
        public string   m_Talla         { set; get; }
        public string   m_Menarca       { set; get; }
        public string   m_G             { set; get; }
        public string   m_A             { set; get; }
        public string   m_P             { set; get; }
        public string   m_C             { set; get; }
        public string   m_Ritmo         { set; get; }
        public int      m_Dismenorrea      { set; get; }
        public string   m_F             { set; get; }
        public string   m_D             { set; get; }
        public string   m_C2            { set; get; }
        public string   m_FPP           { set; get; }
        public string   m_FUM           { set; get; }
        public string   m_FUP           { set; get; }
        public string   m_IVSA          { set; get; }
        public string   m_Menopausia    { set; get; }
        public string   m_Metodo        { set; get; }
        public string   m_Estudios      { set; get; }
        public string   m_Motivo        { set; get; }
        public string   m_fkDoctor      { set; get; }
        #endregion
    }
}