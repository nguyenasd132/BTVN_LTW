using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace LAB12.DAL
{
    public static class Database
    {
        private static readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
