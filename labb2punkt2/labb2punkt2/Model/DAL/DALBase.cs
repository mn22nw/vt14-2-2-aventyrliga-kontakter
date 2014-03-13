using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using labb2punkt2.Model;
using System.Data.SqlClient;

namespace labb2punkt2.Model.DAL
{
    public abstract class DALBase
    {
        private static readonly string _connectionString;

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["1dv409_AdventureWorksAssignmentConnectionString"].ConnectionString;
        }
    }
}