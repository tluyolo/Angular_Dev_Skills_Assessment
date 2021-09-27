using Angular_Dev_Skills_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Angular_Dev_Skills_Assessment.Repository
{
    public class PersonRepository
    {
     
        private SqlCommand cmd;


        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //int code, string name, string surname, string id_number
        public string AddPerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (cmd = new SqlCommand("INSERT INTO Persons (code,Name, Surname,id_number) VALUES (@code,@Name, @Surname,@id_number)"))
                {
                    cmd.Parameters.AddWithValue("@code", person.code);
                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@Surname", person.Surname);
                    cmd.Parameters.AddWithValue("@id_number", person.id_number);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "New data Added Successfully";

                }
                else
                {
                    return "data Not Added";

                }
            }
        }
        public string PutPerson(Person person)
        {

            string query = "UPDATE Persons SET code=@code, Name=@Name, Surname=@Surname , Surname=@Surname,id_number=@id_number  WHERE code=@code";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@code", person.code);
                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@Surname", person.Surname);
                    cmd.Parameters.AddWithValue("@id_number", person.id_number);
                    cmd.Connection = con;
                    con.Open();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "Updated Successfully";

                }
                else
                {
                    return "data Not Updated";

                }
            }
        }

        public string DeletePerson(int code)
        {
            string query = "DELETE FROM Persons WHERE code=@code";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Connection = con;
                    con.Open();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "Updated Successfully";

                }
                else
                {
                    return "data Not Updated";

                }
            }
        }
        public string AddPersonDetails()

        {
            Accounts acc = new Accounts();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (cmd = new SqlCommand("INSERT INTO Acc (code,person_code,account_number, outstanding_balance) VALUES (@code,@person_code,@account_number, @outstanding_balance)"))
                {
                    cmd.Parameters.AddWithValue("@code", acc.code);
                    cmd.Parameters.AddWithValue("@person_code", acc.person_code);                
                    cmd.Parameters.AddWithValue("@account_number", acc.account_number);
                    cmd.Parameters.AddWithValue("@outstanding_balance", acc.outstanding_balance);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "New data Added Successfully";

                }
                else
                {
                    return "data Not Added";

                }
            }
        }
        public string PutPersonDetails()
        {
            Accounts acc = new Accounts();

            string query = "UPDATE Persons SET code=@code, person_code=@person_code, account_number=@account_number , outstanding_balance=@outstanding_balance  WHERE code=@code";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@code", acc.code);
                    cmd.Parameters.AddWithValue("@person_code", acc.code);
                    cmd.Parameters.AddWithValue("@account_number", acc.account_number);
                    cmd.Parameters.AddWithValue("@outstanding_balance", acc.outstanding_balance);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "Updated Successfully";

                }
                else
                {
                    return "data Not Updated";

                }
            }
        }
        

        public string DeletePersonDetails(int code)
        {
            string query = "DELETE FROM Accounts WHERE code=@code";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Connection = con;
                    con.Open();
                }

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "Updated Successfully";

                }
                else
                {
                    return "data Not Updated";

                }
            }
        }
    }
}