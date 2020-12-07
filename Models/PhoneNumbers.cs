using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Models
{
    public class PhoneNumbers
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NrType { get; set; }
        public string Number { get; set; }
    }
}
