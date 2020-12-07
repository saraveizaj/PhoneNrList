using PhoneNrLists.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Phone
{
    public class GetAll
    {
        private ApplicationDbContext _ctx;
        public GetAll(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Request> Do()
        {
            return _ctx.PhoneNrs.ToList().Select(x=>new Request
            {
                Id=x.Id,
                Firstname=x.Firstname,
                Lastname=x.Lastname,
                NrType=x.NrType,
                Number=x.Number
            });
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
