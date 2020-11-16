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
    public class EspecialidadService: IEspecialidadService
    {
        Especialidad _oEspecialidad = new Especialidad();
        List<Especialidad> _oEspecialidades = new List<Especialidad>();

        public Especialidad EspecialidadAdd(Especialidad oEspecialidad)
        {
            _oEspecialidad = new Especialidad();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEspecialidades = con.Query<Especialidad>("dbo.InsertEspecialidad", this.setParameters(oEspecialidad),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oEspecialidad.Error = ex.Message;
            }
            return _oEspecialidad;
        }

        public string EspecialidadDelete(int IdEspecialidad)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdEspecialidad", IdEspecialidad);
                        con.Query("dbo.DeleteEspecialidad", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oEspecialidad.Error = ex.Message;
            }
            return _oEspecialidad.Error;
        }
        public Especialidad EspecialidadGet(int IdEspecialidad)
        {
            _oEspecialidad = new Especialidad();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdEspecialidad", IdEspecialidad);
                        var oEspecialidad = con.Query<Especialidad>("dbo.SelectEspecialidad", param, commandType:
                            CommandType.StoredProcedure).ToList();
                        if (oEspecialidad != null && oEspecialidad.Count() > 0)
                        {
                            _oEspecialidad = oEspecialidad.SingleOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oEspecialidad.Error = ex.Message;
            }
            return _oEspecialidad;
        }
        public List<Especialidad> EspecialidadGets()
        {
            _oEspecialidades = new List<Especialidad>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEspecialidades = con.Query<Especialidad>("dbo.SelectEspecalidadAll", commandType: CommandType.StoredProcedure).ToList();
                        if (oEspecialidades != null && oEspecialidades.Count() > 0)
                        {
                            _oEspecialidades = oEspecialidades;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oEspecialidad.Error = ex.Message;
            }
            return _oEspecialidades;
        }
        public Especialidad EspecialidadUpdate(Especialidad oEspecialidad)
        {
            _oEspecialidad = new Especialidad();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEspecialidads = con.Query<Especialidad>("dbo.UpdateEspecialidad", this.setParameters(oEspecialidad),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oEspecialidad.Error = ex.Message;
            }
            return _oEspecialidad;
        }
        private DynamicParameters setParameters(Especialidad oEspecialidad)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oEspecialidad.IdEspecialidad != 0) parameters.Add("@IdEspecialidad", oEspecialidad.IdEspecialidad);
            parameters.Add("@NombreEspecialidad", oEspecialidad.NombreEspecialidad);
            parameters.Add("@DescpEspecialidad", oEspecialidad.DescpEspecialidad);
            return parameters;
        }
    }
}
