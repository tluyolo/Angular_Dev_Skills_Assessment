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
    public class Accounts 
    {
        public  float code { get; set; }
        public float person_code { get; set; }
        public string account_number { get; set; }
        public double outstanding_balance { get; set; }      
    }
    public class Transactions 
    {
        public float code { get; set; }
        public float account_code { get; set; }        
        public string amount { get; set; }
        public string transaction_date { get; set; }
        public string capture_date { get; set; }
        public string description { get; set; }
    }
}