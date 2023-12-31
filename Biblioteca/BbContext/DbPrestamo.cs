﻿using Biblioteca.Models;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Biblioteca.BbContext
{
    public class DbPrestamo:Prestamo
    {
        public DataSet Prestamo_Get()
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Prestamo_Get";
                    oCommd.CommandType = CommandType.StoredProcedure;
                    FbDataAdapter da = new FbDataAdapter(oCommd);
                    da.Fill(oDS, "Result");
                }
                oConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
            }
            return oDS;
        }
        public DataSet Prestamo_GetById(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Prestamo_GetById";
                    oCommd.Parameters.Add("@ID", FbDbType.Integer).Value = ID;
                    oCommd.CommandType = CommandType.StoredProcedure;
                    FbDataAdapter da = new FbDataAdapter(oCommd);
                    da.Fill(oDS, "Result");
                }
                oConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
            }
            return oDS;
        }
        public DataSet Prestamo_GetByCliente(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Prestamo_GetByCliente";
                    oCommd.Parameters.Add("@ID", FbDbType.Integer).Value = ID;
                    oCommd.CommandType = CommandType.StoredProcedure;
                    FbDataAdapter da = new FbDataAdapter(oCommd);
                    da.Fill(oDS, "Result");
                }
                oConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
            }
            return oDS;
        }
        public Int32 Prestamo_Ins()
        {
            Int32 IdPrestamo = 0;
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            using (oConn)
            {
                try
                {
                    oConn.Open();
                    if (oConn.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar con la Base de Datos.");
                    }
                    using (FbTransaction oTrans = oConn.BeginTransaction())
                    {
                        try
                        {
                            using (FbCommand oCommd = new FbCommand("Prestamo_Ins", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@FechaPrestamo", FbDbType.Date).Value = FechaPrestamo;
                                oCommd.Parameters.Add("@FechaEsperada", FbDbType.Date).Value = FechaEsperada;
                                oCommd.Parameters.Add("@IdCliente", FbDbType.Date).Value = IdCliente;
                                oCommd.Parameters.Add("@IdBibliotecario", FbDbType.Date).Value = IdBibliotecario;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                da.Fill(oDS, "Result");
                                if (!string.IsNullOrEmpty(oDS.Tables[0].Rows[0].ToString()))
                                {
                                    IdPrestamo = Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString());
                                }
                                else
                                {
                                    throw new Exception("No pudo ingresar el registro.");
                                }
                                oTrans.Commit();
                                oConn.Close();
                            }
                        }
                        catch (System.Exception ex)
                        {
                            oTrans.Rollback();
                            //throw ex;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    oConn.Close();
                    throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
            return IdPrestamo;
        }
        public void Prestamo_Upd(Int32 ID,DateTime Fecha)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            using (oConn)
            {
                try
                {
                    oConn.Open();
                    if (oConn.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar con la Base de Datos.");
                    }
                    using (FbTransaction oTrans = oConn.BeginTransaction())
                    {
                        try
                        {
                            using (FbCommand oCommd = new FbCommand("Prestamo_Upd", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdPrestamo0", FbDbType.Integer).Value = ID;
                                oCommd.Parameters.Add("@Devolucion", FbDbType.Date).Value = Fecha;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                oCommd.ExecuteScalar();
                            }
                            oTrans.Commit();
                            oConn.Close();
                        }
                        catch (System.Exception ex)
                        {
                            oTrans.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    oConn.Close();
                    throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
        }
        public void Prestamo_Cancel(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            using (oConn)
            {
                try
                {
                    oConn.Open();
                    if (oConn.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar con la Base de Datos.");
                    }
                    using (FbTransaction oTrans = oConn.BeginTransaction())
                    {
                        try
                        {
                            using (FbCommand oCommd = new FbCommand("Prestamo_Cancel", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@ID", FbDbType.Integer).Value = ID;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                oCommd.ExecuteScalar();
                            }
                            oTrans.Commit();
                            oConn.Close();
                        }
                        catch (System.Exception ex)
                        {
                            oTrans.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    oConn.Close();
                    throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
        }
    }
}
