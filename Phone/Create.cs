using PhoneNrLists.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Phone
{
    public class Create
    {
        private ApplicationDbContext _ctx;
        public Create(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Response Do(Request request) 
        {
            
                _ctx.PhoneNrs.Add(new Models.PhoneNumbers
                {
                    
                    Firstname= request.Firstname,
                    Lastname= request.Lastname,
                    NrType= request.NrType,
                    Number= request.Number
            }
                );
                _ctx.SaveChanges();
                return new Response
                {
                    
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    NrType = request.NrType,
                    Number = request.Number
                };
            
           
            
        }

        public class Request
        {
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
