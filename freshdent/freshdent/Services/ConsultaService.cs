using Dapper;
using freshdent.Conexion;
using freshdent.Iservices;
using freshdent.Models;
using freshdent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Services
{
    public class ConsultaService
    {
        Consulta _oConsulta = new Consulta();
        List<Consulta> _oConsultas = new List<Consulta>();

        public Consulta Add(Consulta oConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsulta = con.Query<Consulta>("InsertConsulta", this.setParameters(oExpediente),
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

        public string Delete(int ConsultaId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdConsulta", ConsultaId);
                        con.Query("DeleteConsulta", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta.Error;
        }
        public Consulta Get(int ConsultaId)
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
                        param.Add("@IdConsulta", ConsultaId);
                        var oConsulta = con.Query<Expediente>("SelectConsulta", param, commandType: CommandType.StoredProcedure).ToList();
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
        public List<Consulta> Gets()
        {
            _oConsultas = new List<Consulta>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<Consulta>("SelectConsultaAll", commandType: CommandType.StoredProcedure).ToList();
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
        public Consulta Update(Consulta oConsulta)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpedientes = con.Query<Consulta>("UpdateConsulta", this.setParameters(oExpediente),
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
