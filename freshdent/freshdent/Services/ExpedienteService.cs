using Dapper;
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
    public class ExpedienteService
    {
        Expediente _oExpediente = new Expediente();
        List<Expediente> _oExpedientes = new List<Expediente>();

        public Expediente Add(Expediente oExpediente)
        {
            _oExpediente = new Expediente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpediente = con.Query<Expediente>("InsertExpediente", this.setParameters(oExpediente),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oExpediente.Error = ex.Message;
            }
            return _oExpediente;
        }
        
        public string Delete (int ExpedienteId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdExpediente", ExpedienteId);
                        con.Query("DeleteExpediente", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oExpediente.Error = ex.Message;
            }
            return _oExpediente.Error;
        }
        public Expediente Get(int ExpedienteId)
        {
            _oExpediente = new Expediente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdExpediente", ExpedienteId);
                        var oExpediente = con.Query<Expediente>("SelectExpediente", param, commandType: CommandType.StoredProcedure).ToList();
                        if (oExpediente != null && oExpediente.Count()>0)
                        {
                            _oExpediente = oExpediente.SingleOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oExpediente.Error = ex.Message;
            }
            return _oExpediente;
        }
        public List <Expediente> Gets()
        {
            _oExpedientes = new List<Expediente>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpedientes = con.Query<Expediente>("SelectExpedienteAll", commandType: CommandType.StoredProcedure).ToList();
                        if (oExpedientes != null && oExpedientes.Count()>0)
                        {
                            _oExpedientes = oExpedientes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oExpediente.Error = ex.Message;
            }
            return _oExpedientes;
        }
        public Expediente Update(Expediente oExpediente)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpedientes = con.Query<Expediente>("UpdateExpediente", this.setParameters(oExpediente),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oExpediente.Error = ex.Message;
            }
            return _oExpediente;
        }
        private DynamicParameters setParameters (Expediente oExpediente)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oExpediente.IdExpediente != 0) parameters.Add("@IdExpediente", oExpediente.IdExpediente);
            parameters.Add("@Cedula", oExpediente.Cedula);
            parameters.Add("@Nombres", oExpediente.Nombres);
            parameters.Add("@Apellidos", oExpediente.Apellidos);
            parameters.Add("@Fecha_Nacimiento", oExpediente.Fecha_Nacimiento);
            parameters.Add("@Telefono_Celular", oExpediente.Telefono_Celular);
            parameters.Add("@Municipio", oExpediente.Municipio);
            parameters.Add("@Departamento", oExpediente.Departamento);
            return parameters;
        }
    }
}
