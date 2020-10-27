using freshdent.Conexion;
using freshdent.Iservicies;
using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Service
{
    public class ConsultaService : IConsultaService
    {
        Consulta _oConsulta = new Consulta();
        List<Consulta> _oConsultas = new List<Consulta>();
        public Medico Add(Consulta oConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<Consulta>("InsertConsulta", this.setParameters(oConsulta),
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
                        param.Add("@Id", ConsultaId);
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
        public Medico Get(int ConsultaId)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", ConsultaId);
                    var oConsulta = con.Query<Consulta>("SelectConsulta", param, commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oConsulta != null && oConsulta.Count() > 0)
                    {
                        _oConsulta = oConsulta.SingleOrDefault();
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
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oConsultas = con.Query<Consulta>("SelectConsultaAll", commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oConsultas != null && oConsultas.Count() > 0)
                    {
                        _oConsultas = oConsultas;
                    }
                }
            }
            catch (Exception ex)
            {
                _oConsulta.Error = ex.Message;
            }
            return _oConsulta;
        }
        public Medico Update(Consulta oConsulta)
        {
            _oConsulta = new Consulta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oConsultas = con.Query<Consulta>("UpdateConsulta", this.setParameters(oConsulta),
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
            if (oConsulta.IdConsulta != 0) parameters.Add("@Id", oConsulta.IdConsulta);
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
