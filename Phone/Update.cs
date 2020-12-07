using PhoneNrLists.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Phone
{
    public class Update
    {
        private ApplicationDbContext _ctx;
        public Update(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Response Do(Request request)
        {

            var phonenrs = _ctx.PhoneNrs.FirstOrDefault(x => x.Id == request.Id);

            phonenrs.Firstname = request.Firstname;
            phonenrs.Lastname = request.Lastname;
            phonenrs.NrType = request.NrType;
            phonenrs.Number = request.Number;

                _ctx.SaveChanges();
            return new Response
            {
                Id=phonenrs.Id,
                Firstname=phonenrs.Firstname,
                Lastname=phonenrs.Lastname,
                NrType=phonenrs.NrType,
                Number=phonenrs.Number
            };
                
            
           
        
        }
        public class Request
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string NrType { get; set; }
            public string Number { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string NrType { get; set; }
            public string Number { get; set; }
        }
    }
   
    }
