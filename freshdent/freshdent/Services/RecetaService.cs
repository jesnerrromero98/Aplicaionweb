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
    public class RecetaService : IRecetaService
    {
        Receta _oReceta = new Receta();
        List<Receta> _oRecetas = new List<Receta>();

        public Receta RecetaAdd(Receta oReceta)
        {
            _oReceta = new Receta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oRecetas = con.Query<Receta>("InsertReceta", this.setParameters(oReceta),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oReceta.Error = ex.Message;
            }
            return _oReceta;
        }

        public string RecetaDelete(int IdReceta)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdReceta", IdReceta);
                        con.Query("DeleteReceta", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oReceta.Error = ex.Message;
            }
            return _oReceta.Error;
        }
        public Receta RecetaGet(int IdReceta)
        {
            _oReceta = new Receta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdReceta", IdReceta);
                        var oReceta = con.Query<Receta>("SelectReceta", param, commandType: 
                            CommandType.StoredProcedure).ToList();
                        if (oReceta != null && oReceta.Count() > 0)
                        {
                            _oReceta = oReceta.SingleOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oReceta.Error = ex.Message;
            }
            return _oReceta;
        }
        public List<Receta> RecetaGets()
        {
            _oRecetas = new List<Receta>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oRecetas = con.Query<Receta>("SelectRecetaAll", commandType: 
                            CommandType.StoredProcedure).ToList();
                        if (oRecetas != null && oRecetas.Count() > 0)
                        {
                            _oRecetas = oRecetas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oReceta.Error = ex.Message;
            }
            return _oRecetas;
        }
        public Receta RecetaUpdate(Receta oReceta)
        {
            _oReceta = new Receta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oRecetas = con.Query<Expediente>("UpdateReceta", this.setParameters(oReceta),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oReceta.Error = ex.Message;
            }
            return _oReceta;
        }
        private DynamicParameters setParameters(Receta oReceta)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oReceta.IdReceta != 0) parameters.Add("@IdReceta", oReceta.IdReceta);
            parameters.Add("@Nombre", oReceta.Nombre);
            parameters.Add("@Presentacion", oReceta.Presentacion);
            parameters.Add("@Cantidad", oReceta.Cantidad);
            parameters.Add("@Descripcion", oReceta.Descripcion);
            return parameters;
        }
    }
}
