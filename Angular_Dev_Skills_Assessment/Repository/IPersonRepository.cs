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
        Person SelectFicaStatusByFicaId(string id);
        List<Person> PersonSelectListByCode(string id);
        List<Person> SelectDetails(string ids);

    }
}
