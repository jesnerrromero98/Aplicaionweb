using freshdent.Conexion;
using freshdent.Iservicies;
using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Service
{
    public class RecetaMedicaService : IRecetaService
    {
        RecetaMedica _oRecetaMedica = new RecetaMedica();
        List<RecetaMedica> _oRecetaMedicas = new List<RecetaMedica>();
        public RecetaMedica Add(RecetaMedica oRecetaMedica)
        {
            _oRecetaMedica = new RecetaMedica();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oRecetaMedicas = con.Query<RecetaMedica> ("InsertReceta", this.setParameters(oRecetaMedica),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oRecetaMedica.Error = ex.Message;
            }
            return _oRecetaMedica;
        }
        public string Delete(int RecetaMedicaId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@Id", RecetaMedicaId);
                        con.Query("DeleteReceta", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRecetaMedica.Error = ex.Message;
            }
            return _oRecetaMedica.Error;
        }
        public RecetaMedica Get(int RecetaMedicaId)
        {
            _oRecetaMedica = new RecetaMedica();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", RecetaMedicaId);
                    var oRecetaMedica = con.Query<RecetaMedica>("SelectReceta", param, commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oRecetaMedica != null && oRecetaMedica.Count() > 0)
                    {
                        _oRecetaMedica = oRecetaMedica.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRecetaMedica.Error = ex.Message;
            }
            return _oRecetaMedica;
        }
        public List<RecetaMedica> Gets()
        {
            RecetaMedica _oRecetaMedicas = new List<RecetaMedica>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oRecetaMedicas = con.Query<RecetaMedica>("SelectRecetaAll", commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oRecetaMedicas != null && oRecetaMedicas.Count() > 0)
                    {
                        _oRecetaMedicas = oRecetaMedicas;
                    }
                }
            }
            catch (Exception ex)
            {
                _oRecetaMedica.Error = ex.Message;
            }
            return _oRecetaMedica;
        }
        public RecetaMedica Update(RecetaMedica oRecetaMedica)
        {
            _oRecetaMedica = new RecetaMedica();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oRecetaMedicas = con.Query<Consulta>("UpdateReceta", this.setParameters(oRecetaMedica),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oRecetaMedica.Error = ex.Message;
            }
            return _oRecetaMedica;
        }
        private DynamicParameters setParameters(RecetaMedica oRecetaMedica)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oRecetaMedica.IdReceta!= 0) parameters.Add("@Id", oRecetaMedica.IdReceta);
            parameters.Add("@Nombre", oRecetaMedica.Nombre);
            parameters.Add("@Presentacion", oRecetaMedica.Presentacion);
            parameters.Add("@Cantidad", oRecetaMedica.Cantidad);
            parameters.Add("@Descripcion", oRecetaMedica.Descripcion);
            return parameters;
        }
    }
}
