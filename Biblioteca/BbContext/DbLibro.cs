using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.BbContext
{
    public class DbLibro:Models.Libro
    {
        public  DbLibro() { }
        public DataSet Libro_Get()
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey;Port=3050;Dialect=3;character set=ASCII;Role=;Packet Size=8192;ServerType=0");
            try
            {
                oConn.Open();
                if (oConn.State !=ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "LIBRO_GET";
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
        public DataSet Libro_GetById(Int32 ID)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Libro_GetById";
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
        public DataSet Libro_Autor(String NombreAutor)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Libro_Autor";
                    oCommd.Parameters.Add("@NombreAutor", FbDbType.VarChar).Value = NombreAutor;
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
        public DataSet Libro_Editorial(String NombreEditorial)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Libro_Editorial";
                    oCommd.Parameters.Add("@NombreEditorial", FbDbType.VarChar).Value = NombreEditorial;
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
        public DataSet Libro_Genero(String NombreGenero)
        {
            DataSet oDS = new DataSet();
            FbConnection oConn = new FbConnection("Data Source=Localhost;Initial Catalog=Biblioteca;Database=C:\\Users\\ANGEL\\source\\repos\\Biblioteca\\Biblioteca\\DataBase\\BIBLIOTECA.FDB;User Id=SYSDBA;Password=masterkey");
            try
            {
                oConn.Open();
                if (oConn.State != ConnectionState.Open) { throw new Exception("No se pudo conectar con la Base de datos."); }
                using (FbCommand oCommd = oConn.CreateCommand())
                {
                    oCommd.CommandText = "Libro_Genero";
                    oCommd.Parameters.Add("@NombreGenero", FbDbType.VarChar).Value = NombreGenero;
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
        public Int32 Libro_Ins()
        {
            Int32 IdLibro = 0;
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
                            using (FbCommand oCommd = new FbCommand("Libro_Ins", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@Editorial", FbDbType.VarChar).Value = Editorial;
                                oCommd.Parameters.Add("@Inventario", FbDbType.Integer).Value = Inventario;
                                oCommd.Parameters.Add("@Genero", FbDbType.VarChar).Value = Genero;
                                oCommd.Parameters.Add("@Autor", FbDbType.VarChar).Value = Autor;
                                FbDataAdapter da = new FbDataAdapter(oCommd);
                                da.Fill(oDS, "Result");
                                if (!string.IsNullOrEmpty(oDS.Tables[0].Rows[0].ToString()))
                                {
                                    IdLibro = Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString());
                                }
                                else
                                {
                                    throw new Exception("No pudo ingresar el registro.");
                                }
                                oTrans.Commit();
                            }
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
            return IdLibro;
        }
        public void Libro_Upd()
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
                            using (FbCommand oCommd = new FbCommand("Libro_Upd", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdLibro0", FbDbType.Integer).Value = IdLibro;
                                oCommd.Parameters.Add("@Nombre", FbDbType.VarChar).Value = Nombre;
                                oCommd.Parameters.Add("@Editorial", FbDbType.VarChar).Value = Editorial;
                                oCommd.Parameters.Add("@Inventario", FbDbType.Integer).Value = Inventario;
                                oCommd.Parameters.Add("@Genero", FbDbType.VarChar).Value = Genero;
                                oCommd.Parameters.Add("@Autor", FbDbType.VarChar).Value = Autor;
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
        public void Libro_UpdStock(Int32 IdLibro,Int32 LibrosExtra)
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
                            using (FbCommand oCommd = new FbCommand("Libro_UpdStock", oConn, oTrans))
                            {
                                oCommd.CommandType = CommandType.StoredProcedure;
                                oCommd.Parameters.Add("@IdLibro0", FbDbType.Integer).Value = IdLibro; 
                                oCommd.Parameters.Add("@LibrosExtra", FbDbType.Integer).Value = LibrosExtra; 
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
