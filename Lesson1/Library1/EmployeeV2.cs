using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class EmployeeV2 : PersonV2
    {
        public void DoProcess()
        {
            Name = "My name";
            Birthday = DateTime.Now;
        }

    }
}
