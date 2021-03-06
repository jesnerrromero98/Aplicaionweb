﻿using Dapper;
using freshdent.Conexion;
using freshdent.Iservices;
using freshdent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Services
{
    public class ConsultaService : IConsultaService
    {
        Consulta _oConsulta = new Consulta();
        List<ConsMedExp> _oConsultas = new List<ConsMedExp>();

        public Consulta ConsultaAdd(Consulta oConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<Consulta>("dbo.InsertConsulta", this.setParameters(oConsulta),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta;
        }

        public string ConsultaDelete(int IdConsulta)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdConsulta", IdConsulta);
                        con.Query("dbo.DeleteConsulta", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta.Error;
        }
        public Consulta ConsultaGet(int IdConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdConsulta", IdConsulta);
                        var oConsulta = con.Query<Consulta>("dbo.SelectConsulta", param, commandType: 
                            CommandType.StoredProcedure).ToList();
                        if (oConsulta != null && oConsulta.Count() > 0)
                        {
                            _oConsulta = oConsulta.SingleOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta;
        }
        public List<ConsMedExp> ConsultaGets()
        {
            _oConsultas = new List<ConsMedExp>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<ConsMedExp>("dbo.SelectConsultaAll", commandType: CommandType.StoredProcedure).ToList();
                        if (oConsultas != null && oConsultas.Count() > 0)
                        {
                            _oConsultas = oConsultas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsultas;
        }
        public Consulta ConsultaUpdate(Consulta oConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<Consulta>("dbo.UpdateConsulta", this.setParameters(oConsulta),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta;
        }
        private DynamicParameters setParameters(Consulta oConsulta)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oConsulta.IdConsulta != 0) parameters.Add("@IdConsulta", oConsulta.IdConsulta);
            parameters.Add("@Fecha", oConsulta.Fecha);
            parameters.Add("@Hora", oConsulta.Hora);
            parameters.Add("@Sintoma", oConsulta.Sintoma);
            parameters.Add("@Diagnostico", oConsulta.Diagnostico);
            parameters.Add("@IdExpediente", oConsulta.IdExpediente);
            parameters.Add("@IdMedico", oConsulta.IdMedico);
            return parameters;
        }
    }
}
