using Library1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    public class OtherFactory
    {

        public void DoProcess()
        {
            var personV2 = new PersonV2();
            personV2.Name = "My Name";


            var otherEmployee = new OtherEmployee();
            //otherEmployee

        }

    }
}
