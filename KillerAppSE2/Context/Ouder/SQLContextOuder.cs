using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using KillerAppSE2.Connector;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;

namespace KillerAppSE2.Context.Ouder
{
    public class SQLContextOuder : IContextOuder
    {
        private MSSQLConnector Connector;

        public SQLContextOuder(MSSQLConnector Connector)
        {
            this.Connector = Connector;
        }

        public List<Rit> AangevraagdeRitten(Models.Ouder ouder)
        {
            SqlCommand cmd = new SqlCommand("GetRitten");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("OuderEmail", ouder.email);

            try
            {
                List<DataRow> ritOverview = new List<DataRow>();
                ritOverview.AddRange(Connector.ExecuteQueryCommand(cmd));
                List<Rit> aangevraagdeRitten = new List<Rit>();
                foreach (DataRow dr in ritOverview)
                {
                    Rit rit = new Rit(Convert.ToDateTime(dr["Date"]), Convert.ToString(dr["BeginTijd"]),
                        Convert.ToString(dr["Beginlocatie"]), Convert.ToString(dr["EindLocatie"]),
                        Convert.ToInt32(dr["RitDuur"]));
                    aangevraagdeRitten.Add(rit);
                }
                return aangevraagdeRitten;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                return null;
            }
        }

        public bool VraagRitAan(Rit rit)
        {
            SqlCommand cmd = new SqlCommand("RitAanvraag");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OuderEmail", rit.ouder.email);
            cmd.Parameters.AddWithValue("@BeginTijd", rit.beginTijd);
            cmd.Parameters.AddWithValue("@BeginAdres", rit.beginAdres);
            cmd.Parameters.AddWithValue("@Date", rit.date);
            cmd.Parameters.AddWithValue("@EindAdres", rit.eindAdres);
            cmd.Parameters.AddWithValue("@RitDuratie", rit.ritDurate);

            try
            {
                Connector.ExecuteQueryCommand(cmd);
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                return false;
            }
        }
    }
}