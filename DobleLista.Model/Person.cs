using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobleLista.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Traceability { get; set; }

        public Person(int id, string traceability)
        {
            this.Id = id;
            this.Traceability = traceability;
        }
    }
}
