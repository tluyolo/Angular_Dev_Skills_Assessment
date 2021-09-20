using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular_Dev_Skills_Assessment.Models
{
    public class Person
    {

        public float code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string id_number { get; set; }
    }
    public class Accounts : Person
    {
        public  float acc_code { get; set; }
        public string account_number { get; set; }
        public double outstanding_balance { get; set; }      
    }
    public class Transactions : Accounts
    {
        public float t_code { get; set; }
        public string Name { get; set; }
        public string transaction_date { get; set; }
        public string capture_date { get; set; }

    }
}