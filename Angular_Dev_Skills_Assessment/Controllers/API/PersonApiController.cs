using Angular_Dev_Skills_Assessment.Models;
using Angular_Dev_Skills_Assessment.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


namespace Angular_Dev_Skills_Assessment.Controllers.API
{
	public class PersonApiController : ApiController
	{
		string sConnString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
		public IHttpActionResult GetPersons(bool includeAddress = false)
		{
			IList<Accounts> person = new List<Accounts>();

			using (SqlConnection con = new SqlConnection(sConnString))
			{
				SqlCommand objComm = new SqlCommand("SELECT per.code,per.Surname,per.id_number,Ac.account_number FROM Persons per,Accounts Ac where per.code = Ac.person_code", con);
				con.Open();
				SqlDataReader reader = objComm.ExecuteReader();
				while (reader.Read())
				{
					person.Add(new Accounts
					{
						code  = Convert.ToInt32(reader["code"]),
						Surname = reader["Surname"].ToString(),
						id_number = reader["id_number"].ToString(),
						account_number = reader["account_number"].ToString()
					});
				}
				con.Close();

				if (person.Count == 0)
				{
					return NotFound();
				}

				return Ok(person);
			}
		}

		[System.Web.Http.HttpPost]
		public string InsertPerson()

		{ 
			Person person = new Person();
			PersonRepository repository = new PersonRepository(); 
				var response = repository.AddPerson(person);
				return response;
		}
		public string updatePerson()
		{
			Person person = new Person();
			PersonRepository repository = new PersonRepository(); 
			var response = repository.PutPerson(person);
			return response;
		}
		public string deletePerson(int code)
		{
			PersonRepository repository = new PersonRepository();  
			var response = repository.DeletePerson(code);
			return response;
		}
		public string insertPersonDetail()
		{
			Accounts acc = new Accounts();
			PersonRepository repository = new PersonRepository();
			var response = repository.AddPerson(acc);
			return response;
		}
		public string updatePersonDetail()
		{
			Accounts acc = new Accounts();
			PersonRepository repository = new PersonRepository();
			var response = repository.PutPerson(acc);
			return response;
		}
		public string deletePersonDetail(int code)
		{
			PersonRepository repository = new PersonRepository();
			var response = repository.DeletePerson(code);
			return response;
		}

	}
}

