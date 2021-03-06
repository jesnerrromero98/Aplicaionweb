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
    public class MedicoService : IMedicoService
    {
        Medico _oMedico = new Medico();
        List<MedExp> _oMedicos = new List<MedExp>();

        public Medico MedicoAdd(Medico oMedico)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMedicos = con.Query<Medico>("dbo.InsertMedico", this.setParameters(oMedico),
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

        public string MedicoDelete(int IdMedico)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@IdMedico", IdMedico);
                        con.Query("dbo.DeleteMedico", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oMedico.Error = ex.Message;
            }
            return _oMedico.Error;
        }
        public Medico MedicoGet(int IdMedico)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)con.Open();


                    var param = new DynamicParameters();
                        param.Add("@IdMedico", IdMedico);
                        var oMedico = con.Query<Medico>("dbo.SelectMedico", param, commandType: 
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
        public List<MedExp> MedicoGets()
        {
            _oMedicos = new List<MedExp>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();   

                        var oMedicos = con.Query<MedExp>("dbo.SelectMdicoAll", commandType: 
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
            return _oMedicos;
        }
        public Medico MedicoUpdate(Medico oMedico)
        {
            _oMedico = new Medico();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMedicos = con.Query<Medico>("dbo.UpdateMedico", this.setParameters(oMedico),
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
            if (oMedico.IdMedico != 0) parameters.Add("@IdMedico", oMedico.IdMedico);
            parameters.Add("@NombreMedico", oMedico.NombreMedico);
            parameters.Add("@Telefono_Celular", oMedico.Telefono_Celular);
            parameters.Add("@IdEspecialidad", oMedico.IdEspecialidad);
            return parameters;
        }
    }
}
