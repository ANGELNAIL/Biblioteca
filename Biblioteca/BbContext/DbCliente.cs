using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.BbContext
{
    public class DbCliente:Models.Cliente
    {
        public  DbCliente() { }
        public DataSet Cliente_Get()
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State !=ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Cliente_Get";
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
        public DataSet Cliente_GetById(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Cliente_GetById";
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
        public Int32 Cliente_Ins()
        {
            Int32 IdCliente = 0;
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
                            using (FbCommand oCommd = new FbCommand("Cliente_Ins", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@APaterno", FbDbType.VarChar).Value = APaterno;
                                oCommd.Parameters.Add("@AMaterno", FbDbType.VarChar).Value = AMaterno;
                                oCommd.Parameters.Add("@IdUsuario", FbDbType.Integer).Value = IdUsuario;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                da.Fill(oDS, "Result");
                                if (!string.IsNullOrEmpty(oDS.Tables[0].Rows[0].ToString()))
                                {
                                    IdCliente = Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString());
                                }
                                else
                                {
                                    throw new Exception("No pudo ingresar el registro.");
                                }
                                oTrans.Commit();
                                oConn.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            oTrans.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    oConn.Close();
                    //throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
            return IdCliente;
        }
        public void Cliente_Upd()
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
                            using (FbCommand oCommd = new FbCommand("Cliente_Upd", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdCliente0", FbDbType.Integer).Value = IdCliente;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@APaterno", FbDbType.VarChar).Value = APaterno;
                                oCommd.Parameters.Add("@AMaterno", FbDbType.VarChar).Value = AMaterno;
                                FbDataAdapter da = new FbDataAdapter(oCommd);                               
                                oCommd.ExecuteScalar();
                            }
                            oTrans.Commit();
                            oConn.Close();
                        }
                        catch (Exception ex)
                        {
                            oTrans.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    oConn.Close();
                    //throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
        }
    }
}
