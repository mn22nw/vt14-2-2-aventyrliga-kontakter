using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using sistalabben.MODEL;
using System.Data.SqlClient;

namespace sistalabben.MODEL.DAL
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
            _connectionString =  WebConfigurationManager.ConnectionStrings["1dv406_AdventureWorksAssignmentConnectionString"].ConnectionString;
        }
    }
}