using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KillerAppSE2.Connector
{
    public class MSSQLConnector : IConnector
    {
        public MSSQLConnector()
        {
            dbCon =
                ConfigurationManager.ConnectionStrings["KillerappSE2.Properties.Settings.Connectionstring"]
                    .ConnectionString;
        }

        public string dbCon { get; }

        public List<DataRow> ExecuteQueryCommand(SqlCommand command)
        {
            var con = new SqlConnection(dbCon);
            command.Connection = con;

            SqlDataAdapter dAtapter = new SqlDataAdapter(command);
            DataTable dTable = new DataTable();
            dAtapter.Fill(dTable);
            var dList = dTable.AsEnumerable().ToList();

            con.Close();

            return dList;
        }
    }

}