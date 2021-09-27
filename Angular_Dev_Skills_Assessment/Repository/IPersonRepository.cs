using Angular_Dev_Skills_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular_Dev_Skills_Assessment.Repository
{
    interface IPersonRepository 
    {
        string AddPersonDetails();
        string AddPerson(Person person);
        string PutPerson(Person person);
        string PutPersonDetails();
        string DeletePersonDetails(int code);
        string DeletePerson(int code);

    }
}
