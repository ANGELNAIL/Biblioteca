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
                                oCommd.Parameters.Add("@APaterno", FbDbType.VarChar).Value = Contrasenia;
                                oCommd.Parameters.Add("@AMaterno", FbDbType.VarChar).Value = Rol;
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
    }
}
