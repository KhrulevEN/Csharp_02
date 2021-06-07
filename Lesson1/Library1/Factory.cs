using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Factory
    {
        public void DoProcess()
        {

            var person = new Person();
            person.FirstName = "First Name";

            var personV2 = new PersonV2();
            personV2.Name = "My Name";
            

        }
    }
}
