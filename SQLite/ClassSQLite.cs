using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace SQLite
{
    public class ConexionSQLite
    {
        public string Conectar()
        {//Crea la conexión con la base de datos

            SQLiteConnection cnx = new SQLiteConnection("Data Source=C:\\ubicacion\\dbname.s3db;Version=3;");

            try //manejador de errores
            {
                cnx.Open(); //Se abre la conexión con la base de datos
                return "Conexión exitosa";
            }
            catch (Exception ex)
            {//Devuelve un mensaje con el error que sucedió

                return ex.Message;
            }

            finally
            {//Cierra la conexión con la base de datos

                cnx.Close();
            }
        }

        public string ConsultaSinResulto(string sql) // Son consultas como "Insert, Delete, Update"
        {//Crea la conexión a la base de datos

            SqlConnection cnx = new SqlConnection("Data Source=C:\\ubicacion\\dbname.s3db;Version=3;");
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                cnx.Close();
            }
        }

        public DataTable ConsultaConResultado(string sql) //Son consultas como "Select * From"
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection cnx = new SQLiteConnection("Data Source=C:\\ubicacion\\dbname.s3db;Version=3;");

            try
            {
                cnx.Open();
                SQLiteCommand cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                ad = new SQLiteDataAdapter();
                ad.Fill(dt);
            }
            catch (SQLiteException)
            {

            }

            finally
            {
                cnx.Close();
            }

            return dt;
        }
    }
}
