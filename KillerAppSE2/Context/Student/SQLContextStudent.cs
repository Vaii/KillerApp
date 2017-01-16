using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerAppSE2.Connector;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;

namespace KillerAppSE2.Context.Student
{
    public class SQLContextStudent : IContextStudent
    {
        private MSSQLConnector connector;

        public SQLContextStudent(MSSQLConnector connector)
        {
            this.connector = connector;
        }

        public bool SetBeschikbaar(Beschikbaarheid beschikbaarheid)
        {
            SqlCommand cmd = new SqlCommand("SetBeschikbaar");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentMail", beschikbaarheid.Student.email);
            cmd.Parameters.AddWithValue("@Date", beschikbaarheid.Datum);
            cmd.Parameters.AddWithValue("@Begin", beschikbaarheid.StartTime);
            cmd.Parameters.AddWithValue("@Eind", beschikbaarheid.EindTime);

            try
            {
                connector.ExecuteQueryCommand(cmd);
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                return false;
            }
        }

        public List<Beschikbaarheid> GetPlanning(Models.Student student)
        {
            SqlCommand cmd = new SqlCommand("GetPlanning");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentEmail", student.email);
            List<DataRow> beschikbaarheidOverview = new List<DataRow>();
            List<Beschikbaarheid> beschikbaarheden = new List<Beschikbaarheid>();

            try
            {
                beschikbaarheidOverview.AddRange(connector.ExecuteQueryCommand(cmd));

                foreach (DataRow dr in beschikbaarheidOverview)
                {
                    Beschikbaarheid beschikbaarheid = new Beschikbaarheid(Convert.ToString(dr["BeginTijd"]),
                        Convert.ToString(dr["EindTijd"]), Convert.ToDateTime(dr["Date"]));
                    beschikbaarheden.Add(beschikbaarheid);
                }
                return beschikbaarheden;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                return null;
            }
        }
    }
}