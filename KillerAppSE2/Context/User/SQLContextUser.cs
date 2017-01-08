using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using KillerAppSE2.Connector;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;
using System.Data.SqlClient;

namespace KillerAppSE2.Context
{
    public class SQLContextUser : IContextUser
    {
        private MSSQLConnector _connector;
        private Models.Student Student { get; set; }
        private Ouder Ouder { get; set; }

        public SQLContextUser(MSSQLConnector connector)
        {
            this._connector = connector;
        }

        public bool RegisterUser(Ouder User)
        {
            SqlCommand cmd = new SqlCommand("RegisterOuder");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Initialen", User.initialen);
            cmd.Parameters.AddWithValue("@Achternaam", User.achternaam);
            cmd.Parameters.AddWithValue("@LoginPin", User.loginPin);
            cmd.Parameters.AddWithValue("@MobielNr", User.mobielNr);
            cmd.Parameters.AddWithValue("@TelNr", User.telNr);
            cmd.Parameters.AddWithValue("@Email", User.email);
            cmd.Parameters.AddWithValue("@ThuisAdres", User.thuisAdres);
            cmd.Parameters.AddWithValue("@Leeftijd", User.leeftijd);

            try
            {
                _connector.ExecuteQueryCommand(cmd);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool RegisterUser(Models.Student User)
        {
            SqlCommand cmd = new SqlCommand("RegisterStudent");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Init", User.initialen);
            cmd.Parameters.AddWithValue("@Achter", User.achternaam);
            cmd.Parameters.AddWithValue("@Login", User.loginPin);
            cmd.Parameters.AddWithValue("@Email", User.email);
            cmd.Parameters.AddWithValue("@Telnr", User.telNr);
            cmd.Parameters.AddWithValue("@ThuisAdres", User.thuisAdres);
            cmd.Parameters.AddWithValue("@StudLoc", User.studeerLocatie);

            try
            {
                _connector.ExecuteQueryCommand(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Models.Student LoginStudent(string email, string wachtwoord)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM UserStudent WHERE Email = @Email AND LoginPin = @Login";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Login", wachtwoord);

            try
            {
                var studentInfo = new List<DataRow>();
                studentInfo.AddRange(_connector.ExecuteQueryCommand(cmd));


                if (studentInfo.Count != 0)
                {
                    foreach (DataRow dr in studentInfo)
                    {
                        Models.Student stu = new Models.Student(Convert.ToString(dr["Initialen"]),
                            Convert.ToString(dr["Achternaam"]), Convert.ToString(dr["Email"]),
                            Convert.ToString(dr["Telnr"]), Convert.ToString(dr["ThuisAdres"]),
                            Convert.ToString(dr["StudeerLocatie"]));
                        Student = stu;
                    }
                    return Student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Ouder LoginOuder(string email, string wachtwoord)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM UserOuder WHERE Email = @Email AND LoginPin = @Login";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("Login", wachtwoord);

            try
            {
                var ouderInfo = new List<DataRow>();
                ouderInfo.AddRange(_connector.ExecuteQueryCommand(cmd));


                if (ouderInfo.Count != 0)
                {
                    foreach (DataRow dr in ouderInfo)
                    {
                        Ouder oud = new Ouder(Convert.ToString(dr["Initialen"]), Convert.ToString(dr["Achternaam"]), Convert.ToString(dr["Email"]),
                            Convert.ToString(dr["TelNr"]), Convert.ToString(dr["MobielNr"]), Convert.ToString(dr["ThuisAdres"]), 
                            Convert.ToInt32(dr["Leeftijd"]));
                        Ouder = oud;
                    }
                    return Ouder;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}