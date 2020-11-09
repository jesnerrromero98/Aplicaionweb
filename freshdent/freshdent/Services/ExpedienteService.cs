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
    public class ExpedienteService : IExpedienteService
    {
        Expediente _oExpediente = new Expediente();
        List<Expediente> _oExpedientes = new List<Expediente>();

        public Expediente ExpedienteAdd(Expediente oExpediente)
        {
            _oExpediente = new Expediente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpedientes = con.Query<Expediente>("InsertExpediente", this.setParameters(oExpediente),
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
        
        public string ExpedienteDelete (int IdExpediente)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdExpediente", IdExpediente);
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
        public Expediente ExpedienteGet(int IdExpediente)
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
                        param.Add("@IdExpediente", IdExpediente);
                        var oExpediente = con.Query<Expediente>("SelectExpediente", param, commandType: 
                            CommandType.StoredProcedure).ToList();
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
        public List <Expediente> ExpedienteGets()
        {
            _oExpedientes = new List<Expediente>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oExpedientes = con.Query<Expediente>("SelectExpedienteAll", commandType: 
                            CommandType.StoredProcedure).ToList();
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
        public Expediente ExpedienteUpdate(Expediente oExpediente)
        {
            _oExpediente = new Expediente();
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
        private DynamicParameters setParameters(Expediente oExpediente)
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
