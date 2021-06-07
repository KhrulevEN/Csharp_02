using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class PersonV2
    {
        public string Name { get; set; }

        private protected DateTime Birthday { get; set; }

        protected internal int Age {get; set;}
    }
}
