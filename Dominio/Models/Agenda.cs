﻿
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dominio.Models
{
    public class Agenda : Persona
    {
        private string stringConnection = ConfigurationManager.ConnectionStrings["ConnectionProduccion"].ConnectionString;

        public string Extension { get; set; }
        public string Sucursal { get; set; }
        public string PostBox { get; set; }
        public string Fax { get; set; }
        public string LineaCelular { get; set; }
        public string LineaCelularAdicional { get; set; }

        public bool Estado { get; set; }
    
        public List<Agenda> ConsultarAgenda()
        {
            List<Agenda> _listado = new List<Agenda>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[ConsultarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TipoConsulta", 0);
                    //cmd.Parameters.AddWithValue("@Sucursal", 0);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var persona = new Agenda
                        {
                            FirstName = dr["nombres"].ToString(),
                            LastName = dr["apellidos"].ToString(),
                            Extension = dr["extension"].ToString(),
                            Email = dr["email"].ToString(),
                            Estado = (dr["estado"].ToString()) == "1" ? true : false,
                            Id = int.Parse(dr["id"].ToString())
                        };

                        _listado.Add(persona);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return _listado;
        }

        public List<Agenda> ConsultarAgenda(string nombre)
        {
            List<Agenda> listado = new List<Agenda>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[ConsultarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoConsulta", 2);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        var _agenda = new Agenda
                        {
                            Id = int.Parse(dr["id"].ToString()),
                            FirstName = dr["nombres"].ToString(),
                            LastName = dr["apellidos"].ToString(),
                            Extension = dr["extension"].ToString(),
                            Email = dr["email"].ToString(),
                            Estado = (dr["estado"].ToString()) == "1" ? true : false,
                            PostBox = dr["pbx"].ToString(),
                            Sucursal = dr["sucursal"].ToString(),
                            Address = dr["direccion"].ToString(),
                            Fax = dr["fax"].ToString(),
                            LineaCelular = dr["lineaCelular"].ToString(),
                            LineaCelularAdicional = dr["lineaCelularAdicional"].ToString(),
                            AdmissionDate = DateTime.Parse(dr["fechaCreacion"].ToString())
                        };
                        listado.Add(_agenda);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return listado;
        }

        public Agenda ConsultarAgendaPersona(int id)
        {
            Agenda _agenda = new Agenda();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[ConsultarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoConsulta", 1);
                    cmd.Parameters.AddWithValue("@IdAgenda", id);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        _agenda = new Agenda
                        {
                            Id = int.Parse(dr["id"].ToString()),
                            FirstName = dr["nombres"].ToString(),
                            LastName = dr["apellidos"].ToString(),
                            Extension = dr["extension"].ToString(),
                            Email = dr["email"].ToString(),
                            Estado = (dr["estado"].ToString()) == "1" ? true : false,
                            PostBox = dr["pbx"].ToString(),
                            Sucursal = dr["sucursal"].ToString(),
                            Address = dr["direccion"].ToString(),
                            Fax = dr["fax"].ToString(),
                            LineaCelular = dr["lineaCelular"].ToString(),
                            LineaCelularAdicional = dr["lineaCelularAdicional"].ToString(),
                            AdmissionDate = DateTime.Parse(dr["fechaCreacion"].ToString())
                        };
                    }
                }
            }
            catch (Exception e)
            {

            }
            return _agenda;
        }

        public bool Guardar()
        {
            bool _respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[CrearModificarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoOperacion", (Id == 0 ? 0 : 1));
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@nombres", FirstName != null ? FirstName.ToUpper() : string.Empty);
                    cmd.Parameters.AddWithValue("@apellidos", LastName != null ? LastName.ToUpper() : string.Empty);
                    cmd.Parameters.AddWithValue("@extension", Extension != null ? Extension : string.Empty);
                    cmd.Parameters.AddWithValue("@email", Email != null ? Email : string.Empty);
                    cmd.Parameters.AddWithValue("@sucursal", Sucursal != null ? Sucursal : string.Empty);
                    cmd.Parameters.AddWithValue("@direccion", string.Empty);
                    cmd.Parameters.AddWithValue("@pbx", PostBox != null ? PostBox : string.Empty);
                    cmd.Parameters.AddWithValue("@fax", Fax != null ? Fax : string.Empty);
                    cmd.Parameters.AddWithValue("@lineaCelular", LineaCelular != null ? LineaCelular : string.Empty);
                    cmd.Parameters.AddWithValue("@lineaCelularAdicional", LineaCelularAdicional != null ? LineaCelularAdicional : string.Empty);
                    cmd.Parameters.AddWithValue("@estado", Estado ? 1 : 0);

                    cmd.ExecuteReader();

                    _respuesta = true;
                }
            }
            catch (Exception e)
            {

            }
            return _respuesta;
        }
    }

    public enum TipoEstado
    {
        Inactivo = 0,
        Activo = 1
    }
}
