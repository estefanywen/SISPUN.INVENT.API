using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.DataAccess.Context
{
    public partial class SISPUNDbContext
    {
        public void SaveChanges(string jsonAuthN)
        {
            //TODO
        }

        public async Task SaveChangesAsync(string jsonAuthN)
        {
            //TODO
            await Task.Delay(0);
        }

        public void SaveAudit()
        {
            //TODO
        }
    }
}
