using PhoneNrLists.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Phone
{
    public class Get
    {
        private ApplicationDbContext _ctx;
        public Get(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Request Do(int id)
        {
            return _ctx.PhoneNrs.Where(x=>x.Id==id).Select(x => new Request
            {
                Id=x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                NrType = x.NrType,
                Number = x.Number
            }).FirstOrDefault();
        }
        public class Request
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string NrType { get; set; }
            public string Number { get; set; }
        }
    }
}
