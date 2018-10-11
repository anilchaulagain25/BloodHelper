using System;
using System.Data;
using System.Data.SqlClient;

namespace BLOOD_HELP.Dal
{
    public class dao
    {
        private readonly SqlConnection connection;
        public dao()
        {
            this.connection = new SqlConnection(GetConnectionString());
        }
        public string GetConnectionString()
        {
            return $"Server=DESKTOP-B4RLPLM\\SQLEXPRESS;Database=BLOOD_HELP;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        public IDbConnection GetConnection()
        {
            return connection;
        }
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Open) connection.Close();
            connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }
        public DataTable GetTable(SqlParameter[] commandParameterCollection, string commandText, bool isProc = true)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = GetConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
                    cmd.CommandText = commandText;
                    if (null != commandParameterCollection)
                    {
                        foreach (SqlParameter item in commandParameterCollection)
                            item.Value = item.Value == null ? DBNull.Value : (object)item.Value.ToString().Trim();
                        cmd.Parameters.AddRange(commandParameterCollection);
                    }
                    OpenConnection();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }
                    CloseConnection();
                }
            }
            return dataTable;
        }
        public DataSet GetDataSet(SqlParameter[] commandParameterCollection, string commandText, bool isProc = true)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = GetConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
                    cmd.CommandText = commandText;
                    if (null != commandParameterCollection)
                    {
                        foreach (SqlParameter item in commandParameterCollection)
                            item.Value = item.Value == null ? DBNull.Value : (object)item.Value.ToString().Trim();
                        cmd.Parameters.AddRange(commandParameterCollection);
                    }
                    OpenConnection();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dataSet);
                    }
                    CloseConnection();
                }
            }
            return dataSet;
        }
        public void ExecuteQuery(SqlParameter[] commandParameterCollection, string commandText, bool isProc = true)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = GetConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
                    cmd.CommandText = commandText;
                    if (null != commandParameterCollection)
                    {
                        foreach (SqlParameter item in commandParameterCollection)
                            item.Value = item.Value == null ? DBNull.Value : (object)item.Value.ToString().Trim();
                        cmd.Parameters.AddRange(commandParameterCollection);
                    }
                    OpenConnection();
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
        }
    }
}