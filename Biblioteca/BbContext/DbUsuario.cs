using Biblioteca.Models;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Biblioteca.BbContext
{
    public class DbUsuario:Models.Usuario
    {
        public DbUsuario() { }
        public Int32 Usuario_Ins()
        {
            Int32 IdUsuario = 0;
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            using (oConn)
            {
                try
                {
                    oConn.Open();
                    if (oConn.State != System.Data.ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar con la Base de Datos.");
                    }
                    using (FbTransaction oTrans = oConn.BeginTransaction())
                    {
                        try
                        {
                            using (FbCommand oCommd = new FbCommand("Usuario_Ins", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@Contrasenia", FbDbType.VarChar).Value = Contrasenia;
                                oCommd.Parameters.Add("@Rol", FbDbType.VarChar).Value = Rol;
                                oCommd.Parameters.Add("@Correo", FbDbType.VarChar).Value = Correo;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                da.Fill(oDS, "Result");
                                if (!string.IsNullOrEmpty(oDS.Tables[0].Rows[0].ToString()))
                                {
                                    IdUsuario = Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString());
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
                    //throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
            return IdUsuario;
        }
        public void Usuario_Upd()
        {
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            using (oConn)
            {
                try
                {
                    oConn.Open();
                    if (oConn.State != System.Data.ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar con la Base de Datos.");
                    }
                    using (FbTransaction oTrans = oConn.BeginTransaction())
                    {
                        try
                        {
                            using (FbCommand oCommd = new FbCommand("Usuario_Upd", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdUsuario", FbDbType.Integer).Value = IdUsuario;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@Contrasenia", FbDbType.VarChar).Value = Contrasenia;
                                oCommd.Parameters.Add("@Correo", FbDbType.VarChar).Value = Correo;
                                oCommd.ExecuteScalar();
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
                    //throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
        }
        public DataSet Login(String Entrada)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Login";
                    oCommd.Parameters.Add("@Entrada", FbDbType.VarChar).Value = Entrada;
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
        public DataSet Usuario_GetById(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Usuario_GetById";
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
    }
}
