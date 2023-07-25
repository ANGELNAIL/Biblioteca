using Biblioteca.Models;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Biblioteca.BbContext
{
    public class DbDetallePrestamo:DetallePrestamo
    {
        public DataSet DetallePrestamo_Get()
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "DetallePrestamo_Get";
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
        public DataSet DetallePrestamo_GetById(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "DetallePrestamo_GetById";
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
        public DataSet DetallePrestamo_GetByCliente(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "DetallePrestamo_GetByCliente";
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
        public Int32 DetallePrestamo_Ins()
        {
            Int32 IdDetallePrestamo = 0;
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
                            using (FbCommand oCommd = new FbCommand("DetallePrestamo_Ins", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdPrestamo", FbDbType.Integer).Value = IdPrestamo;
                                oCommd.Parameters.Add("@IdLibro", FbDbType.Integer).Value = IdLibro;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                da.Fill(oDS, "Result");
                                if (!string.IsNullOrEmpty(oDS.Tables[0].Rows[0].ToString()))
                                {
                                    IdDetallePrestamo = Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString());
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
            return IdDetallePrestamo;
        }
        public void DetallePrestamo_Upd()
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
                            using (FbCommand oCommd = new FbCommand("DetallePrestamo_Upd", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdPrestamo", FbDbType.Integer).Value = IdPrestamo;
                                oCommd.Parameters.Add("@IdLibro", FbDbType.Integer).Value = IdLibro;
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
