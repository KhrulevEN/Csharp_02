using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Person // internal
    {
        int Age { get; set; } // private

        internal string FirstName { get; set; }

        protected string SecondName { get; set; }

        private DateTime Birthday { get; set; }
    }
}
