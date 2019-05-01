using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PadraoRepositorio
{
    public interface IDB : IDisposable
    {
        IDbConnection GetConnection();
    }

    public class MSSQL : IDB
    {
        private SqlConnection _db;
        
        public void Dispose()
        {
            _db.Close();
            _db.Dispose();
        }

        public IDbConnection GetConnection()
        {
            return _db = new SqlConnection("Server=DESKTOP-23IN36H; database=LTPVI; User=sa; Password=123");
        }
    }

    public class MySql : IDB
    {
        private MySqlConnection _db;

        public void Dispose()
        {
            _db.Close();
            _db.Dispose();
        }

        public IDbConnection GetConnection()
        {
            return _db = new MySqlConnection("ConnectionString");
        }
    }
}
