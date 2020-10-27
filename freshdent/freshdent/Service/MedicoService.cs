using freshdent.Conexion;
using freshdent.Iservicies;
using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Service
{
    public class MedicoService:IMedicoSevice
    {
        Medico _oMedico = new Medico();
        List<Medico> _oMedicos = new List<Medico>();
        public Medico Add(Medico oMedico)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Medico>("InsertMedico", this.setParameters(oMedico),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico;
        }
        public string Delete(int MedicoId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@Id", MedicoId);
                        con.Query("DeleteMedico", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico.Error;
        }
        public Medico Get(int MedicoId)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", MedicoId);
                    var oMedico = con.Query<Medico>("SelectMedico", param, commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oMedico != null && oMedico.Count() > 0)
                    {
                        _oMedico = oMedico.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico;
        }
        public List<Medico> Gets()
        {
            _oMedicos = new List<Medico>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oExpedientes = con.Query<Medico>("SelectMedicoAll", commandType:
                    CommandType.StoredProcedure).ToList();
                    if (oMedicos != null && oMedicos.Count() > 0)
                    {
                        _oMedicos = oMedicos;
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico;
        }
        public Medico Update(Medico oMedico)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMedicos = con.Query<Medico>("UpdateMedico", this.setParameters(oMedico),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico;
        }
        private DynamicParameters setParameters(Medico oMedico)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oMedico.IdMedico != 0) parameters.Add("@Id", oMedico.IdMedico);
            parameters.Add("@NombreMedico", oMedico.NombreMedico);
            parameters.Add("@Telefono_Celular", oMedico.Telefono_Celular);
            return parameters;
        }
    }
}
