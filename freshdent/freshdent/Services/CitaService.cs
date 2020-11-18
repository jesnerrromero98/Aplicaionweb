using Dapper;
using freshdent.Conexion;
using freshdent.Iservices;
using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Services
{
    public class CitaService : ICitaService
    {
        Cita _oCita = new Cita();
        List<Cita> _oCitas = new List<Cita>();

        public Cita CitaAdd(Cita oCita)
        {
            _oCita = new Cita();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCitas = con.Query<Cita>("dbo.InsertCita", this.setParameters(oCita),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita;
        }

        public string CitaDelete(int IdCita)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdCita", IdCita);
                        con.Query("dbo.DeleteCita", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita.Error;
        }
        public Cita CitaGet(int IdCita)
        {
            _oCita = new Cita();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdCita", IdCita);
                        var oCita = con.Query<Cita>("dbo.SelectCita", param, commandType:
                            CommandType.StoredProcedure).ToList();
                        if (oCita != null && oCita.Count() > 0)
                        {
                            _oCita = oCita.SingleOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita;
        }
        public List<Cita> CitaGets()
        {
            _oCitas = new List<Cita>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCitas = con.Query<Cita>("dbo.SelectCitaAll", commandType: CommandType.StoredProcedure).ToList();
                        if (oCitas != null && oCitas.Count() > 0)
                        {
                            _oCitas = oCitas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCitas;
        }
        public Cita CitaUpdate(Cita oCita)
        {
            _oCita = new Cita();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCitas = con.Query<Cita>("dbo.UpdateCita", this.setParameters(oCita),
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCita.Error = ex.Message;
            }
            return _oCita;
        }
        private DynamicParameters setParameters(Cita oCita)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oCita.IdCita != 0) parameters.Add("@IdCita", oCita.IdCita);
            parameters.Add("@FechaCita", oCita.FechaCita);
            parameters.Add("@HoraDisponible", oCita.HoraDisponible);
            parameters.Add("@Precio", oCita.Precio);
            parameters.Add("@Tipo", oCita.Tipo);
            parameters.Add("@IdExpediente", oCita.IdExpediente);
            parameters.Add("@Nombres", oCita.Nombres);
            parameters.Add("@IdMedico", oCita.IdMedico);
            parameters.Add("@NombreMedico", oCita.NombreMedico);
            return parameters;
        }
    }
}
