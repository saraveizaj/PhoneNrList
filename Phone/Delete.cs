using PhoneNrLists.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNrLists.Phone
{
    public class Delete
    {
        private ApplicationDbContext _ctx;
        public Delete(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool Do(int id)
        {
            try
            {
                var PhoneNr = _ctx.PhoneNrs.FirstOrDefault(x => x.Id == id);
                _ctx.PhoneNrs.Remove(PhoneNr);
                _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
