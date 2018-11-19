using MySql.Data.MySqlClient;
using System;

namespace DAL
{
    public static class DBAccess
    {
        static MySqlConnection Connection = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;UID=root;persistsecurityinfo=True;DATABASE=task_management;SslMode=none;Allow User Variables=True");

        public static int? RunNonQuery(string query)
        {
            lock (Connection)
            {
                try
                {
                    if (Connection.State != System.Data.ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }
        }

        public static object RunScalar(string query)
        {
            lock (Connection)
            {
                try
                {
                    if (Connection.State != System.Data.ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteScalar();
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }
        } 

        public static T RunReader<T>(string query, Func<MySqlDataReader, T> func)
        {
            lock (Connection)
            {
                try
                {
                    if (Connection.State != System.Data.ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }
        }

    }
}
